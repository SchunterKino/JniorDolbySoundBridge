using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using Microsoft.VisualBasic.ApplicationServices;

namespace JniorDolbySoundBridge
{
	static class Program
	{
		/// <summary>
		/// Der Haupteinstiegspunkt für die Anwendung.
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			SingleInstanceController controller = new SingleInstanceController();
			string[] args = Environment.GetCommandLineArgs();
			controller.Run(args);
		}

		// http://www.hanselman.com/blog/TheWeeklySourceCode31SingleInstanceWinFormsAndMicrosoftVisualBasicdll.aspx
		public class SingleInstanceController : WindowsFormsApplicationBase
		{
			public SingleInstanceController()
			{
				IsSingleInstance = true;

				StartupNextInstance += this_StartupNextInstance;
			}

			void this_StartupNextInstance(object sender, StartupNextInstanceEventArgs e)
			{
				Form1 form = MainForm as Form1; //My derived form type
				// Make it visible right away.
				form.Visible = true;
			}

			protected override void OnCreateMainForm()
			{
				MainForm = new Form1();
			}
		}
	}
}
