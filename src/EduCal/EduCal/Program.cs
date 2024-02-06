using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EduCal {
	internal static class Program {
		//This is my QA Branch
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main () {
			Application.EnableVisualStyles ();
			Application.SetCompatibleTextRenderingDefault ( false );
			Application.Run ( new frmMain () );
		}
	}
}
