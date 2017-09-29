using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO.Ports;
using System.Windows.Forms;
using GPSDOTimeSync.Devices.Thunderbolt;
using GPSDOTimeSync.TimeProviders;
using GPSDOTimeSync.TimeProviders.Thunderbolt;
using System.Diagnostics;

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

		private int lastSystemTimeUpdate;
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

			lastSystemTimeUpdate = 0;

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

			maximumCorrectionUnit.SelectedIndex = 0;
		}

		private void AddMessageToLog(string message, LogLevel logLevel) {
			latestLogMessage.Text = message;
			latestLogMessage.ForeColor = LOG_LEVEL_TO_COLOR[logLevel];
		}

		private void start_Click(object sender, EventArgs e) {
			string serialPortName = (string) serialPortNames.SelectedItem;
			string deviceName = (string) deviceNames.SelectedItem;

			SerialPort serialPort = new SerialPort(serialPortName);		
			timeProvider = TIME_PROVIDER_CONSTRUCTORS[deviceName](serialPort);

			timeProvider.TimeAvailable += (DateTime dateTime) => {
				int minimumUpdateIntervalValue = 0;

				Invoke(new Action(() => {
					minimumUpdateIntervalValue = (int) minimumUpdateInterval.Value;
				}));

				if (Environment.TickCount - lastSystemTimeUpdate < minimumUpdateIntervalValue * 1000) {
					return;
				}

				if (maximumCorrectionEnabled.Checked) {
					// Positive error means system clock is ahead, negative error means system clock is behind
					TimeSpan error = SystemTimeUtils.GetSystemTime().Subtract(dateTime).Duration();

					TimeSpan maximumError = new TimeSpan();
					int maximumCorrectionValue = (int) maximumCorrection.Value;
					string maximumCorrectionUnitString = "";

					Invoke(new Action(() => {
						maximumCorrectionUnitString = (string) maximumCorrectionUnit.SelectedItem;
					}));

					if (maximumCorrectionUnitString == "hour(s)") {
						maximumError = TimeSpan.FromHours(maximumCorrectionValue);
					} else if (maximumCorrectionUnitString == "minute(s)") {
						maximumError = TimeSpan.FromMinutes(maximumCorrectionValue);
					} else if (maximumCorrectionUnitString == "second(s)") {
						maximumError = TimeSpan.FromSeconds(maximumCorrectionValue);
					}

					if (error >= maximumError) {
						Invoke(new Action(() => {
							AddMessageToLog("System time error exceeded maximum correction: time not set.", LogLevel.Info);
						}));

						return;
					}
				}

				SystemTimeUtils.SetSystemTime(dateTime);

				Invoke(new Action(() => {
					AddMessageToLog(
						string.Format(
							"System time set to {0}.",
							dateTime.ToString("HH:mm:ss dd\\/MM\\/yyyy")
						),
						LogLevel.Info
					);
				}));

				lastSystemTimeUpdate = Environment.TickCount;
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

		private void maximumCorrectionEnabled_CheckedChanged(object sender, EventArgs e) {
			maximumCorrection.Enabled = maximumCorrectionEnabled.Checked;
			maximumCorrectionUnit.Enabled = maximumCorrectionEnabled.Checked;
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
