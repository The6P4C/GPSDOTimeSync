using System.Collections.Generic;
using System.Diagnostics;
using System.IO.Ports;
using System.Linq;
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

			ThunderboltSerialPort tbsp = new ThunderboltSerialPort(new SerialPort("COM3"));

			tbsp.PacketReceived += (ThunderboltPacket packet) => {
				if (packet.IsPacketValid) {
					if (packet.ID == 0x8F && packet.Data.Count == 17 && packet.Data[0] == 0xAB) {
						ushort year = (ushort) (packet.Data[15] << 8 | packet.Data[16]);
						Debug.WriteLine(year);
					}
				}
			};

			tbsp.Open();
		}
	}
}
