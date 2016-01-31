using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using JniorDll.Net;
using System.IO;

namespace JniorDolbySoundBridge
{
	public partial class Form1 : Form
	{
		private const string JNIOR_IP = "10.100.152.12";
		private const int JNIOR_PORT = 9200;

		private const string JNIOR_USER = "jnior";
		private const string JNIOR_PASSWORD = "jnior";

		private const int JNIOR_INCREASE_INPUT = 7;
		private const int JNIOR_DECREASE_INPUT = 6;

		private Jnior jnior_;
		private DolbyCP750 dolby_;

		public Form1()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			// Setup Dolby CP750 wrapper
			dolby_ = new DolbyCP750();
			dolby_.DisconnectedEvent += OnDolbyConnectionChanged;

			// Access the jnior box!
			jnior_ = new Jnior();
			jnior_.AddConnectionCallback(new jnior_dll_calls.StatusCallback(OnJniorConnectionNotify));
			jnior_.AddLoginCallback(new jnior_dll_calls.StatusCallback(OnJniorLoginNotify));
			jnior_.AddMonitorCallback(new jnior_dll_calls.MonitorCallback(OnJniorMonitorNotify));

			// Connect to Dolby
			dolby_.Connect();

			// Instantiate the writer
			ConsoleRedirection.TextBoxStreamWriter _writer = new ConsoleRedirection.TextBoxStreamWriter(textBox1);
			// Redirect the out Console stream
			Console.SetOut(_writer);

			// Connect to jnior
			ConnectJnior();
		}

		private void Form1_FormClosing(object sender, FormClosingEventArgs e)
		{
			// Don't allow closing by normal means. Just put us in the tray.
			if (e.CloseReason == CloseReason.UserClosing)
			{
				e.Cancel = true;
				Visible = false;
			}
			else
			{
				// Stop redirecting console output to the form textbox.
				StreamWriter standardOutput = new StreamWriter(Console.OpenStandardOutput());
				Console.SetOut(standardOutput);

				// Can't unregister from jnior events :(
				dolby_.DisconnectedEvent -= OnDolbyConnectionChanged;

				dolby_.Reset(true);
				if (jnior_.IsConnected())
				{
					jnior_.Disconnect();
				}
			}
		}

		private void OnDolbyConnectionChanged(DolbyCP750 dolby, EventArgs args)
		{
			this.Invoke((MethodInvoker)delegate
			{
				if (dolbyStatus.IsDisposed)
					return;

				if (dolby.Disconnected)
					dolbyStatus.Text = "Disconnected";

				else
					dolbyStatus.Text = "Connected";

				updateIcon();
			});
		}

		public void ConnectJnior()
		{
			ConnectionProperties cp = new ConnectionProperties(JNIOR_IP, JNIOR_PORT, 1000, 30);
			jnior_.ConnectAsync(cp);
		}

		private void OnJniorConnectionNotify(Jnior jnior, StatusArgs args)
		{
			updateIcon();

			// Don't spam
			if (args.Status == jnior_dll_calls.STATUS_CONNECTING || args.Status == jnior_dll_calls.STATUS_RECONNECTING)
				return;

			Console.WriteLine("Jnior > " + args.Message);

			this.Invoke((MethodInvoker)delegate
			{
				if (jniorStatus.IsDisposed)
					return;

				jniorStatus.Text = args.Message;
			});

			if (args.Status == jnior_dll_calls.STATUS_CONNECTED)
			{
				// Login to jnior box!
				LoginProperties lp = new LoginProperties(JNIOR_USER, JNIOR_PASSWORD);
				jnior_.LoginAsync(lp);
			}
			else if (args.Status == jnior_dll_calls.STATUS_CONNECTION_FAILED || args.Status == jnior_dll_calls.STATUS_DISCONNECTED)
			{
				// Reconnect right away.
				ConnectJnior();
			}
		}

		private void OnJniorLoginNotify(Jnior jnior, StatusArgs args)
		{
			Console.WriteLine("Jnior > " + args.Message);
			this.Invoke((MethodInvoker)delegate
			{
				if (jniorStatus.IsDisposed)
					return;

				jniorStatus.Text = args.Message;
			});
		}

		private void OnJniorMonitorNotify(Jnior jnior, MonitorArgs args)
		{
			StringBuilder sbInputs = new StringBuilder();
			StringBuilder sbOutputs = new StringBuilder();
			int inputs = jnior.GetInputs();
			int outputs = jnior.GetOutputs();
			for (int i = 7; i >= 0; i--)
			{
				sbInputs.Append(jnior.GetInput(i));
				sbOutputs.Append(jnior.GetOutput(i));
			}
			DateTime jniorTime = Jnior.EPOCH.AddMilliseconds(args.Monitor.jniorTime);
			string timeString = jniorTime.ToLocalTime().ToString("dd.MM.yyyy HH:mm:ss.fff");

			this.Invoke((MethodInvoker)delegate
			{
				if (jniorInputs.IsDisposed || jniorOutputs.IsDisposed || lastUpdated.IsDisposed)
					return;

				jniorInputs.Text = sbInputs.ToString();
				jniorOutputs.Text = sbOutputs.ToString();
				lastUpdated.Text = timeString;
			});
			
			//Console.WriteLine("Inputs: " + sbInputs.ToString() + ", Outputs: " + sbOutputs.ToString() + ", Time : " + timeString);

			// Handle volume inputs
			// TODO: Don't increase when multiple monitor events come in without setting this back to 0.
			if (jnior.GetInput(JNIOR_INCREASE_INPUT) == 1)
			{
				dolby_.IncreaseVolume();
			}
			else if (jnior.GetInput(JNIOR_DECREASE_INPUT) == 1)
			{
				dolby_.DecreaseVolume();
			}
		}

		private void updateIcon()
		{
			if (dolby_.Disconnected || !jnior_.IsConnected())
			{
				trayIcon_.Icon = Properties.Resources.dolby_jnior_error;
				if (!logoBox.IsDisposed)
					logoBox.Image = Properties.Resources.dolby_jnior_error_128;

			}
			else
			{
				trayIcon_.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
				if (!logoBox.IsDisposed)
					logoBox.Image = Properties.Resources.dolby_jnior_128;
			}
		}

		private void trayIcon__MouseDoubleClick(object sender, MouseEventArgs e)
		{
			Visible = true;
		}

		private void openToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Visible = true;
		}

		private void exitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Close();
			Application.Exit();
		}

		private void increaseVolumeButton_Click(object sender, EventArgs e)
		{
			dolby_.IncreaseVolume();
		}

		private void decreaseVolumeButton_Click(object sender, EventArgs e)
		{
			dolby_.DecreaseVolume();
		}

		private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			Close();
			Application.Exit();
		}

		private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
		{
			MessageBox.Show("Jnior to Dolby CP750 Fader Bridge\n\n"+
				"Increases or decreases the fader volume of the Dolby CP750\n"+
				"when an input is triggered in the Jnior Box.\n\n"+
				"Dolby CP750 connection through telnet on "+DolbyCP750.DOLBY_IP+":"+DolbyCP750.DOLBY_PORT+"\n"+
				"sending \"cp750.sys.fader ?|X\" commands.\n\n"+
				"Jnior Box 310 connection using JNIOR Protocol .NET wrappper:\n"+
				"http://www.integpg.com/support/sdk/\n" +
				"Connecting to " + JNIOR_IP + ":" + JNIOR_PORT + " listening on Input " + (JNIOR_INCREASE_INPUT + 1) + " to increase\n" +
				"the volume and Input " + (JNIOR_DECREASE_INPUT + 1) + " to decrease it.\n\n" +
				"Performed by Mike Klimek & Jannik Hartung\n"+
				"November 2015", "About", MessageBoxButtons.OK);
		}

		private void lights_0_Click(object sender, EventArgs e)
		{
			if (!jnior_.IsConnected())
				return;

			// Close relay 1 for 500msec
			jnior_.PulseOutput(0, 500);
		}

		private void lights_33_Click(object sender, EventArgs e)
		{
			if (!jnior_.IsConnected())
				return;

			// Close relay 2 for 500msec
			jnior_.PulseOutput(1, 500);
		}

		private void lights_66_Click(object sender, EventArgs e)
		{
			if (!jnior_.IsConnected())
				return;

			// Close relay 3 for 500msec
			jnior_.PulseOutput(2, 500);
		}

		private void lights_100_Click(object sender, EventArgs e)
		{
			if (!jnior_.IsConnected())
				return;

			// Close relay 4 for 500msec
			jnior_.PulseOutput(3, 500);
		}
	}
}
