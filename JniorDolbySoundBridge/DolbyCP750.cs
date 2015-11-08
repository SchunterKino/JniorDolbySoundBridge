using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Text.RegularExpressions;
using De.Mud.Telnet;
using Net.Graphite.Telnet;

namespace JniorDolbySoundBridge
{
	public class DolbyCP750
	{
		enum Task
		{
			None,
			Increase,
			Decrease
		}

		public const string DOLBY_IP = "10.100.152.16";
		public const int DOLBY_PORT = 61408;

		public event ConnectionStatusChangeEventHandler DisconnectedEvent;

		private bool waitingForReply_;
		private TelnetWrapper telnet_;
		private volatile bool disconnected_;

		public bool Disconnected
		{
			get { return disconnected_; }
			set 
			{ 
				disconnected_ = value;

				// Events could race with other threads and are null if have no subscribers.
				ConnectionStatusChangeEventHandler temp = DisconnectedEvent;
				if (temp != null)
					temp(this, new EventArgs());
			}
		}

		private Task task_;
		private Regex faderRegex_ = new Regex(@"cp750\.sys\.fader (\d+)", RegexOptions.IgnoreCase);

		private Connector connector_;
		private Thread connectorThread_;

		private CommandSender listener_;
		private Thread listenerThread_;

		private string replyBuffer_;

		public TelnetWrapper Telnet
		{
			get { return telnet_; }
		}

		public bool WaitingForReply
		{
			set
			{
				waitingForReply_ = value;
			}
		}

		public DolbyCP750()
		{
			task_ = Task.None;
			waitingForReply_ = false;
			replyBuffer_ = "";
			disconnected_ = true;
			connector_ = new Connector(this);
			listener_ = new CommandSender(this);
			telnet_ = new TelnetWrapper();

			telnet_.Disconnected += new DisconnectedEventHandler(this.OnDisconnect);
			telnet_.DataAvailable += new DataAvailableEventHandler(this.OnDataAvailable);

			telnet_.TerminalType = "NETWORK-VIRTUAL-TERMINAL";
			telnet_.Hostname = DOLBY_IP;
			telnet_.Port = DOLBY_PORT;
		}

		public void Connect()
		{
			if (!disconnected_)
				return;

			if (connectorThread_ != null && connectorThread_.IsAlive)
				return;

			connectorThread_ = new Thread(new ThreadStart(connector_.Run));
			connectorThread_.Start();
		}

		public void Reset(bool shutdown = false)
		{
			waitingForReply_ = false;
			task_ = Task.None;
			replyBuffer_ = "";
			telnet_.Disconnect();
			Disconnected = true;

			// Restart the connection, if the program is still running.
			if (!shutdown)
			{
				Connect();
			}
			else
			{
				if (listenerThread_ != null && listenerThread_.IsAlive)
				{
					listenerThread_.Abort();
				}
				if (connectorThread_ != null && connectorThread_.IsAlive)
				{
					connectorThread_.Abort();
				}
			}

		}

		public void IncreaseVolume()
		{
			task_ = Task.Increase;
			SendCommand("cp750.sys.fader ?");
		}

		public void DecreaseVolume()
		{
			task_ = Task.Decrease;
			SendCommand("cp750.sys.fader ?");
		}

		private void SendCommand(string cmd)
		{
			// Didn't get a response from the server yet for the last command.
			if (waitingForReply_)
				return;

			listener_.Command = cmd;

			waitingForReply_ = true;
			listenerThread_ = new Thread(new ThreadStart(listener_.Run));
			listenerThread_.Start();
		}

		private void OnDisconnect(object sender, EventArgs e)
		{
			Disconnected = true;
			Console.WriteLine("\nDisconnected from CP750.");
			// Reconnect right away!
			Connect();
		}

		private void OnDataAvailable(object sender, DataAvailableEventArgs e)
		{
			replyBuffer_ += e.Data;
			//Console.WriteLine("Full: " + replyBuffer_);

			// Don't do anything with this stuff.
			if (task_ == Task.None)
			{
				waitingForReply_ = false;
				replyBuffer_ = "";
				return;
			}

			Match match = faderRegex_.Match(replyBuffer_);
			if (match.Success)
			{
				Group g = match.Groups[1];
				uint faderLevel = 0;
				if (!UInt32.TryParse(g.ToString(), out faderLevel))
				{
					Console.WriteLine("Failed to parse fader level.");
					Reset();
					return;
				}

				// Increase or decrease the current fader level.
				switch (task_)
				{
					case Task.Increase:
						faderLevel++;
						break;
					case Task.Decrease:
						faderLevel--;
						break;

					default:
						break;
				}

				// Tell the cp750 to change volume.
				waitingForReply_ = false;
				SendCommand("cp750.sys.fader " + faderLevel);
				task_ = Task.None;
				replyBuffer_ = "";
			}
		}
	}

	class Connector
	{
		private DolbyCP750 dolby_;

		public Connector(DolbyCP750 dolby)
		{
			this.dolby_ = dolby;
		}

		public void Run()
		{
			try
			{
				Console.WriteLine("Connecting to Dolby CP750 at " + DolbyCP750.DOLBY_IP + ":" + DolbyCP750.DOLBY_PORT);
				while (dolby_.Disconnected)
				{
					dolby_.Telnet.Connect();
					if (dolby_.Telnet.Connected)
					{
						Console.WriteLine("Telnet connection established!");
						dolby_.Disconnected = false;
						break;
					}
					// Wait 30 seconds until retry.
					Thread.Sleep(30000);
				}
			}
			catch (Exception e)
			{
				dolby_.Reset();
				Console.WriteLine("Error connecting to telnet: " + e.Message);
			}
		}
	}

	class CommandSender
	{
		private DolbyCP750 dolby_;
		private string command_;

		public string Command
		{
			set
			{
				command_ = value;
			}
			get { return command_; }
		}

		public CommandSender(DolbyCP750 dolby)
		{
			this.dolby_ = dolby;
		}

		public void Run()
		{
			try
			{
				if (dolby_.Disconnected)
				{
					dolby_.WaitingForReply = false;
					Console.WriteLine("Can't send command. Not connected.");
					return;
				}

				if (dolby_.Telnet.Connected)
				{
					dolby_.Disconnected = false;
					dolby_.Telnet.Receive();

					Console.WriteLine("Executing command on CP750: " + command_);
					dolby_.Telnet.Send(command_ + dolby_.Telnet.CRLF);
				}
				else
				{
					dolby_.Reset();
				}
			}
			catch (Exception e)
			{
				dolby_.Reset();
				Console.WriteLine("Error sending command to telnet: " + e.Message);
			}
		}
	}

	public delegate void ConnectionStatusChangeEventHandler(DolbyCP750 sender, EventArgs e);
}
