using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace ThunderboltTimeSync {
	public partial class FormMain : Form {
		public FormMain() {
			// Check for admin rights
			// If running as admin:
			//     Ask for COM port with dialog
			//     Connect to COM port
			//     When time message received:
			//         If (time in UTC) AND (last time change was more than $MIN_UPDATE_INTERVAL ago) AND (error is less than $ERROR_THRESHOLD)
			//             Change system time to GPS time
			// Else:
			//     Display message to tell user to run as admin
			//     Quit

			InitializeComponent();

			Debug.WriteLine(SystemTimeUtils.GetSystemTime().ToString("yyyy-MM-ddTHH:mm:ssK.ffff"));
			try {
				SystemTimeUtils.SetSystemTime(new DateTime(
					2000, 1, 1,
					10, 0, 0, 0
				));
			} catch (SystemTimeUtils.SystemTimeException stEx) {
				Debug.WriteLine(string.Format("Setting system time failed: \"{0}\"", stEx.Message));
			}
			Debug.WriteLine(SystemTimeUtils.GetSystemTime().ToString("yyyy-MM-ddTHH:mm:ssK.ffff"));
		}
	}
}
