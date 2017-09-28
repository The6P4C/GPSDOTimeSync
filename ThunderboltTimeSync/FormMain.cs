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

			tbsp.PacketReceived += (List<byte> packetBuffer) => {
				List<string> byteStrings = packetBuffer.Select(x => string.Format("{0:X2}", x)).ToList();
				Debug.WriteLine(
					string.Format(
						"Packet received: {0}",
						string.Join(" ", byteStrings)
					)
				);
			};

			tbsp.Open();
		}
	}
}
