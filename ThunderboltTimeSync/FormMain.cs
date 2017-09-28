using System;
using System.Diagnostics;
using System.Security.Principal;
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

			Debug.WriteLine(SystemTimeUtils.GetTime().ToString("yyyy-MM-ddTHH:mm:ssK.ffff"));
			SystemTimeUtils.SetTime(new DateTime(
				2000, 1, 1,
				10, 0, 0, 0
			));
			Debug.WriteLine(SystemTimeUtils.GetTime().ToString("yyyy-MM-ddTHH:mm:ssK.ffff"));
		}
	}
}
