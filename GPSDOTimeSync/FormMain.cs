using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO.Ports;
using System.Windows.Forms;
using GPSDOTimeSync.Devices.Thunderbolt;
using GPSDOTimeSync.TimeProviders;
using GPSDOTimeSync.TimeProviders.Thunderbolt;

namespace GPSDOTimeSync {
	public partial class FormMain : Form {
		private static readonly Dictionary<LogLevel, Color> LOG_LEVEL_TO_COLOR = new Dictionary<LogLevel, Color>() {
			{ LogLevel.Info, Color.Black },
			{ LogLevel.Warning, Color.Orange },
			{ LogLevel.Error, Color.Red }
		};

		private static readonly Dictionary<string, Func<SerialPort, ITimeProvider>> TIME_PROVIDER_CONSTRUCTORS = new Dictionary<string, Func<SerialPort, ITimeProvider>>() {
			{
				"Trimble Thunderbolt",
				new Func<SerialPort, ITimeProvider>((serialPort) => {
					ThunderboltSerialPort thunderboltSerialPort = new ThunderboltSerialPort(serialPort);
					ITimeProvider timeProvider = new ThunderboltTimeProvider(thunderboltSerialPort);

					return timeProvider;
				})
			}
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
			PopulateDropDowns();

			statusStrip.Renderer = new TruncatedTextEllipsisRenderer();
			latestLogMessage.Text = "";

			timeAndDateDisplayUpdate.Start();
		}

		private void PopulateDropDowns() {
			foreach (string portName in SerialPort.GetPortNames()) {
				serialPortNames.Items.Add(portName);
			}

			if (serialPortNames.Items.Count > 0) {
				serialPortNames.SelectedIndex = 0;
			}

			foreach (string deviceName in TIME_PROVIDER_CONSTRUCTORS.Keys) {
				deviceNames.Items.Add(deviceName);
			}

			if (deviceNames.Items.Count > 0) {
				deviceNames.SelectedIndex = 0;
			}
		}

		private void AddMessageToLog(string message, LogLevel logLevel) {
			latestLogMessage.Text = string.Format("{0} ({1})", message, DateTime.Now.ToString("G"));
			latestLogMessage.ForeColor = LOG_LEVEL_TO_COLOR[logLevel];
		}

		private void start_Click(object sender, EventArgs e) {
			string serialPortName = (string) serialPortNames.SelectedItem;
			string deviceName = (string) deviceNames.SelectedItem;

			SerialPort serialPort = new SerialPort(serialPortName);		
			timeProvider = TIME_PROVIDER_CONSTRUCTORS[deviceName](serialPort);

			timeProvider.TimeAvailable += (DateTime dateTime) => {
				Invoke(new Action(() => {
					
				}));
			};

			timeProvider.Log += (string message, LogLevel logLevel) => {
				Invoke(new Action(() => {
					AddMessageToLog(message, logLevel);
				}));
			};

			timeProvider.Start();

			AddMessageToLog("Time sync started.", LogLevel.Info);

			start.Enabled = false;
			stop.Enabled = true;
		}

		private void stop_Click(object sender, EventArgs e) {
			timeProvider.Stop();

			AddMessageToLog("Time sync stopped.", LogLevel.Info);

			stop.Enabled = false;
			start.Enabled = true;
		}

		private void FormMain_FormClosing(object sender, FormClosingEventArgs e) {
			timeProvider?.Stop();
		}

		private void timeAndDateDisplayUpdate_Tick(object sender, EventArgs e) {
			DateTime systemTime = SystemTimeUtils.GetSystemTime();
			currentTime.Text = systemTime.ToString("HH:mm:ss");
			currentDate.Text = systemTime.ToString("dd\\/MM\\/yyyy");
		}
	}

	public class TruncatedTextEllipsisRenderer : ToolStripProfessionalRenderer {
		protected override void OnRenderItemText(ToolStripItemTextRenderEventArgs e) {
			if (e.Item is ToolStripStatusLabel) {
				TextRenderer.DrawText(e.Graphics, e.Text, e.TextFont, e.TextRectangle, e.TextColor, Color.Transparent, e.TextFormat | TextFormatFlags.EndEllipsis);
			} else {
				base.OnRenderItemText(e);
			}
		}
	}
}
