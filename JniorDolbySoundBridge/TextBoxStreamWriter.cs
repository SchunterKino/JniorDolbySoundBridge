using System;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace ConsoleRedirection
{
	public class TextBoxStreamWriter : TextWriter
	{
		TextBox _output = null;
		bool printTimeStamp_ = true;

		public TextBoxStreamWriter(TextBox output)
		{
			_output = output;
		}

		public override void Write(char value)
		{
			base.Write(value);
			
			_output.Parent.Invoke((MethodInvoker)delegate
			{
				if (_output.IsDisposed)
					return;

				if (printTimeStamp_)
				{
					_output.AppendText(DateTime.Now.ToString("hh:mm:ss") + ": ");
					printTimeStamp_ = false;
				}
				if (value == '\n')
				{
					printTimeStamp_ = true;
				}
				_output.AppendText(value.ToString()); // When character data is written, append it to the text box.
			});
		}

		public override Encoding Encoding
		{
			get { return System.Text.Encoding.UTF8; }
		}
	}
}