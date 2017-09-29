using GPSDOTimeSync.TimeProviders;
using GPSDOTimeSync.TimeProviders.NMEA;
using GPSDOTimeSync.TimeProviders.Thunderbolt;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO.Ports;
using System.Windows.Forms;

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
			},
			{
				"NMEA Device (e.g. BG7TBL GPSDO)",
				new Func<SerialPort, ITimeProvider>((serialPort) => {
					NMEASerialPort nmeaSerialPort = new NMEASerialPort(serialPort);
					ITimeProvider timeProvider = new NMEATimeProvider(nmeaSerialPort);

					return timeProvider;
				})
			}
		};

		private int lastSystemTimeUpdate;
		private ITimeProvider timeProvider;

		Properties.Settings settings;

		public FormMain() {
			InitializeComponent();
			PopulateDropDowns();

			settings = Properties.Settings.Default;
			LoadSettings();

			lastSystemTimeUpdate = 0;

			statusStrip.Renderer = new TruncatedTextEllipsisRenderer();
			labelLatestLogMessage.Text = "";

			timerClockDisplayUpdate.Start();
		}

		private void PopulateDropDowns() {
			foreach (string portName in SerialPort.GetPortNames()) {
				comboBoxSerialPortNames.Items.Add(portName);
			}

			if (comboBoxSerialPortNames.Items.Count > 0) {
				comboBoxSerialPortNames.SelectedIndex = 0;
			}

			foreach (string deviceName in TIME_PROVIDER_CONSTRUCTORS.Keys) {
				comboBoxDeviceNames.Items.Add(deviceName);
			}

			if (comboBoxDeviceNames.Items.Count > 0) {
				comboBoxDeviceNames.SelectedIndex = 0;
			}

			comboBoxMaximumCorrectionUnit.SelectedIndex = 0;
		}

		private void AddMessageToLog(string message, LogLevel logLevel) {
			labelLatestLogMessage.Text = message;
			labelLatestLogMessage.ForeColor = LOG_LEVEL_TO_COLOR[logLevel];
		}

		private void ConfigureTimeProvider() {
			timeProvider.TimeAvailable += (DateTime dateTime) => {
				int minimumUpdateIntervalSeconds = 0;

				Invoke(new Action(() => {
					minimumUpdateIntervalSeconds = (int) numericUpDownMimimumUpdateInterval.Value;
				}));

				if (Environment.TickCount - lastSystemTimeUpdate < minimumUpdateIntervalSeconds * 1000) {
					return;
				}

				// Positive error means system clock is ahead, negative error means system clock is behind
				TimeSpan error = SystemTimeUtils.GetSystemTime().Subtract(dateTime).Duration();

				if (checkBoxMaximumCorrectionEnabled.Checked) {
					TimeSpan maximumCorrection = new TimeSpan();
					int maximumCorrectionValue = (int) numericUpDownMaximumCorrection.Value;
					string maximumCorrectionUnit = "";

					Invoke(new Action(() => {
						maximumCorrectionUnit = (string) comboBoxMaximumCorrectionUnit.SelectedItem;
					}));

					if (maximumCorrectionUnit == "hour(s)") {
						maximumCorrection = TimeSpan.FromHours(maximumCorrectionValue);
					} else if (maximumCorrectionUnit == "minute(s)") {
						maximumCorrection = TimeSpan.FromMinutes(maximumCorrectionValue);
					} else if (maximumCorrectionUnit == "second(s)") {
						maximumCorrection = TimeSpan.FromSeconds(maximumCorrectionValue);
					}

					if (error >= maximumCorrection) {
						Invoke(new Action(() => {
							AddMessageToLog("System time error exceeded maximum correction: time not set.", LogLevel.Info);
						}));

						return;
					}
				}

				SystemTimeUtils.SetSystemTime(dateTime);

				Invoke(new Action(() => {
					AddMessageToLog(string.Format(
						"System time set to {0} ({1}).",
						dateTime.ToString("HH:mm:ss dd\\/MM\\/yyyy"), error.ToString()
					), LogLevel.Info);
				}));

				lastSystemTimeUpdate = Environment.TickCount;
			};

			timeProvider.Log += (string message, LogLevel logLevel) => {
				Invoke(new Action(() => {
					AddMessageToLog(message, logLevel);
				}));
			};
		}

		private void buttonStart_Click(object sender, EventArgs e) {
			string serialPortName = (string) comboBoxSerialPortNames.SelectedItem;
			string deviceName = (string) comboBoxDeviceNames.SelectedItem;

			SerialPort serialPort = new SerialPort(serialPortName);
			timeProvider = TIME_PROVIDER_CONSTRUCTORS[deviceName](serialPort);

			ConfigureTimeProvider();

			timeProvider.Start();

			AddMessageToLog("Time sync started.", LogLevel.Info);

			buttonStart.Enabled = false;
			buttonStop.Enabled = true;
		}

		private void buttonStop_Click(object sender, EventArgs e) {
			timeProvider.Stop();

			AddMessageToLog("Time sync stopped.", LogLevel.Info);

			buttonStop.Enabled = false;
			buttonStart.Enabled = true;
		}

		private void FormMain_FormClosing(object sender, FormClosingEventArgs e) {
			timeProvider?.Stop();
		}

		private void checkBoxMaximumCorrectionEnabled_CheckedChanged(object sender, EventArgs e) {
			numericUpDownMaximumCorrection.Enabled = checkBoxMaximumCorrectionEnabled.Checked;
			comboBoxMaximumCorrectionUnit.Enabled = checkBoxMaximumCorrectionEnabled.Checked;
		}

		private void timerClockDisplayUpdate_Tick(object sender, EventArgs e) {
			DateTime systemTime = SystemTimeUtils.GetSystemTime();
			labelCurrentDateTime.Text = systemTime.ToString("HH:mm:ss\ndd\\/MM\\/yyyy\nUTC");
		}

		#region Settings Management
		private int GetIndexOfComboBoxStringItem(ComboBox comboBox, string itemText) {
			for (int i = 0; i < comboBox.Items.Count; ++i) {
				if ((string) comboBox.Items[i] == itemText) {
					return i;
				}
			}

			return 0;
		}

		private void LoadSettings() {
			// Populate values
			comboBoxDeviceNames.SelectedIndex = GetIndexOfComboBoxStringItem(comboBoxDeviceNames, settings.deviceName);
			comboBoxSerialPortNames.SelectedIndex = GetIndexOfComboBoxStringItem(comboBoxSerialPortNames, settings.serialPortName);

			checkBoxMaximumCorrectionEnabled.Checked = settings.maximumCorrectionEnabled;
			numericUpDownMaximumCorrection.Value = settings.maximumCorrection;
			comboBoxMaximumCorrectionUnit.SelectedIndex = GetIndexOfComboBoxStringItem(comboBoxMaximumCorrectionUnit, settings.maximumCorrectionUnit);

			numericUpDownMimimumUpdateInterval.Value = settings.minimumUpdateInterval;

			// Add event listeners
			comboBoxDeviceNames.SelectedIndexChanged += comboBoxDeviceNames_SelectedIndexChanged_UpdateSettings;
			comboBoxSerialPortNames.SelectedIndexChanged += comboBoxSerialPortNames_SelectedIndexChanged_UpdateSettings;

			checkBoxMaximumCorrectionEnabled.CheckedChanged += checkBoxMaximumCorrectionEnabled_CheckedChanged_UpdateSettings;
			numericUpDownMaximumCorrection.ValueChanged += numericUpDownMaximumCorrection_ValueChanged_UpdateSettings;
			comboBoxMaximumCorrectionUnit.SelectedIndexChanged += comboBoxMaximumCorrectionUnit_SelectedIndexChanged_UpdateSettings;

			numericUpDownMimimumUpdateInterval.ValueChanged += numericUpDownMimimumUpdateInterval_ValueChanged_UpdateSettings;

			// Push possible changes through
			comboBoxDeviceNames_SelectedIndexChanged_UpdateSettings(null, null);
			comboBoxSerialPortNames_SelectedIndexChanged_UpdateSettings(null, null);
			comboBoxMaximumCorrectionUnit_SelectedIndexChanged_UpdateSettings(null, null);
		}

		private void comboBoxDeviceNames_SelectedIndexChanged_UpdateSettings(object sender, EventArgs e) {
			settings.deviceName = (string) comboBoxDeviceNames.SelectedItem;
			settings.Save();
		}

		private void comboBoxSerialPortNames_SelectedIndexChanged_UpdateSettings(object sender, EventArgs e) {
			settings.serialPortName = (string) comboBoxSerialPortNames.SelectedItem;
			settings.Save();
		}

		private void checkBoxMaximumCorrectionEnabled_CheckedChanged_UpdateSettings(object sender, EventArgs e) {
			settings.maximumCorrectionEnabled = checkBoxMaximumCorrectionEnabled.Checked;
			settings.Save();
		}

		private void numericUpDownMaximumCorrection_ValueChanged_UpdateSettings(object sender, EventArgs e) {
			settings.maximumCorrection = numericUpDownMaximumCorrection.Value;
			settings.Save();
		}

		private void comboBoxMaximumCorrectionUnit_SelectedIndexChanged_UpdateSettings(object sender, EventArgs e) {
			settings.maximumCorrectionUnit = (string) comboBoxMaximumCorrectionUnit.SelectedItem;
			settings.Save();
		}

		private void numericUpDownMimimumUpdateInterval_ValueChanged_UpdateSettings(object sender, EventArgs e) {
			settings.minimumUpdateInterval = numericUpDownMimimumUpdateInterval.Value;
			settings.Save();
		}
		#endregion
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
