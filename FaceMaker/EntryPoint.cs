using FaceMaker.UI;
using System;
using System.Windows.Forms;

namespace FaceMaker
{
	internal static class EntryPoint
	{
		[STAThread]
		private static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new MainForm());
		}
	}
}
