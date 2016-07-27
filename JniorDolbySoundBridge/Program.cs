using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace JniorDolbySoundBridge
{
	static class Program
	{
		static Mutex _m;

		// http://www.dotnetperls.com/mutex
		static bool IsSingleInstance()
		{
			try
			{
				// Try to open existing mutex.
				Mutex.OpenExisting("SchunterKinoBridge");
			}
			catch
			{
				// If exception occurred, there is no such mutex.
				Program._m = new Mutex(true, "SchunterKinoBridge");

				// Only one instance.
				return true;
			}
			// More than one instance.
			return false;
		}

		/// <summary>
		/// Der Haupteinstiegspunkt für die Anwendung.
		/// </summary>
		[STAThread]
		static void Main()
		{
			if (!IsSingleInstance())
			{
				MessageBox.Show("Das Programm läuft bereits.\nSchau im Traybereich der Taskleiste nach.", "Programm läuft bereits", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new Form1());
		}
	}
}
