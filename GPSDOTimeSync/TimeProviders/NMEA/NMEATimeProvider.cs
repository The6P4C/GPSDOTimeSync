using System;

namespace GPSDOTimeSync.TimeProviders.NMEA {
	class NMEATimeProvider : ITimeProvider {
		private NMEASerialPort nmeaSerialPort;

		public event TimeAvailableEventHandler TimeAvailable;
		public event LogEventHandler Log;

		/// <summary>
		/// Creates an instance of the NMEATimeProvider class, which provides time information through the <code>ITimeProvider</code> interface.
		/// The <code>NMEASerialPort</code> instance passed into this function must not be open.
		/// </summary>
		/// <param name="nmeaSerialPort">The <code>NMEASerialPort</code> instance to use when communicating with the NMEA device.</param>
		public NMEATimeProvider(NMEASerialPort nmeaSerialPort) {
			this.nmeaSerialPort = nmeaSerialPort;

			nmeaSerialPort.SentenceReceived += SentenceReceived;
		}

		public void Start() {
			nmeaSerialPort.Open();
		}

		public void Stop() {
			nmeaSerialPort.Close();
		}

		private void SentenceReceived(NMEASentence sentence) {
			if (sentence.IsSentenceValid) {
				if (sentence.Talker == "GP" && sentence.MessageType == "RMC") {
					string timeString = sentence.Data[0];
					int hour = int.Parse(timeString.Substring(0, 2));
					int minute = int.Parse(timeString.Substring(2, 2));
					int second = int.Parse(timeString.Substring(4, 2));

					string dateString = sentence.Data[8];
					int day = int.Parse(dateString.Substring(0, 2));
					int month = int.Parse(dateString.Substring(2, 2));
					int year = 2000 + int.Parse(dateString.Substring(4, 2));

					TimeAvailable?.Invoke(new DateTime(year, month, day, hour, minute, second));
				}
			} else {
				Log?.Invoke("An invalid packet was received.", LogLevel.Warning);
			}
		}
	}
}
