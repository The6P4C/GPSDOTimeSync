using System;
using System.Diagnostics;
using System.IO.Ports;
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

			ThunderboltSerialPort tbsp = new ThunderboltSerialPort(new SerialPort("COM8"));

			tbsp.PacketReceived += (ThunderboltPacket packet) => {
				if (packet.IsPacketValid) {
					if (packet.ID == 0x8F && packet.Data.Count == 17 && packet.Data[0] == 0xAB) {
						int timeOfWeek = packet.Data[1] << 24 | packet.Data[2] << 16 | packet.Data[3] << 8 | packet.Data[4];
						ushort weekNumber = (ushort) (packet.Data[5] << 8 | packet.Data[6]);
						short utcOffset = (short) (packet.Data[7] << 8 | packet.Data[8]);

						// Current epoch for GPS week numbers is the morning of 22/8/1999
						DateTime dateTime = new DateTime(1999, 8, 22, 0, 0, 0);

						dateTime = dateTime.AddDays(7 * weekNumber);
						dateTime = dateTime.AddSeconds(timeOfWeek);

						dateTime = dateTime.AddSeconds(-utcOffset);

						labelTimestamps.Invoke(new Action(() => {
							labelTimestamps.Text += string.Format("{0} {1}\n", dateTime.ToLongDateString(), dateTime.ToLongTimeString());
						}));
					}
				}
			};

			tbsp.Open();
		}
	}
}
