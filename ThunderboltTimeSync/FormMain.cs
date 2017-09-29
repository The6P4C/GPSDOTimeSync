using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO.Ports;
using System.Windows.Forms;
using ThunderboltTimeSync.Devices.Thunderbolt;
using ThunderboltTimeSync.TimeProviders;
using ThunderboltTimeSync.TimeProviders.Thunderbolt;

namespace ThunderboltTimeSync {
	public partial class FormMain : Form {
		private static readonly Dictionary<LogLevel, Color> LOG_LEVEL_TO_COLOR = new Dictionary<LogLevel, Color>() {
			{ LogLevel.Info, Color.Black },
			{ LogLevel.Warning, Color.Yellow },
			{ LogLevel.Error, Color.Red }
		};

		private ITimeProvider timeProvider;

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

			latestLogMessage.Text = "";

			ThunderboltSerialPort thunderboltSerialPort = new ThunderboltSerialPort(new SerialPort("COM3"));
			timeProvider = new ThunderboltTimeProvider(thunderboltSerialPort);

			timeProvider.TimeAvailable += (DateTime dateTime) => {
				Invoke(new Action(() => {
					labelTimestamps.Text += string.Format("{0} {1} @ {2}\n", dateTime.ToLongDateString(), dateTime.ToLongTimeString(), DateTime.Now.ToLongTimeString());
				}));
			};

			timeProvider.Log += (string message, LogLevel logLevel) => {
				Invoke(new Action(() => {
					latestLogMessage.Text = message;
					latestLogMessage.ForeColor = LOG_LEVEL_TO_COLOR[logLevel];
				}));
			};

			timeProvider.Start();
		}

		private void FormMain_FormClosing(object sender, FormClosingEventArgs e) {
			timeProvider.Stop();
		}
	}
}
