using System;
using System.Security.Principal;
using System.Windows.Forms;

namespace ThunderboltTimeSync {
	static class Program {
		/// <summary>
		/// Checks if the application is currently running with administrator privileges.
		/// </summary>
		/// <returns>True if the application is running with administrator privileges, false otherwise.</returns>
		private static bool IsRunningAsAdministrator() {
			WindowsIdentity identity = WindowsIdentity.GetCurrent();
			WindowsPrincipal principal = new WindowsPrincipal(identity);
			return principal.IsInRole(WindowsBuiltInRole.Administrator);
		}

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() {
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

			if (!IsRunningAsAdministrator()) {
				MessageBox.Show(
					"This application must be run with administrative privileges. Without administrative privileges, the system time cannot be set.\n\nPlease restart the application as administrator.",
					"Administrative Privileges Required",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error
				);
			} else {
				Application.Run(new FormMain());
			}
		}
	}
}
