using System;

namespace GPSDOTimeSync.TimeProviders.Thunderbolt {
	class ThunderboltTimeProvider : ITimeProvider {
		private ThunderboltSerialPort thunderboltSerialPort;

		public event TimeAvailableEventHandler TimeAvailable;
		public event LogEventHandler Log;

		/// <summary>
		/// Creates an instance of the ThunderboltTimeProvider class, which provides time information through the ITimeProvider interface.
		/// The ThunderboltSerialPort instance passed into this function must not be open.
		/// </summary>
		/// <param name="thunderboltSerialPort">The ThunderboltSerialPort instance to use when communicating with the Thunderbolt.</param>
		public ThunderboltTimeProvider(ThunderboltSerialPort thunderboltSerialPort) {
			this.thunderboltSerialPort = thunderboltSerialPort;

			thunderboltSerialPort.PacketReceived += PacketReceived;
		}

		public void Start() {
			thunderboltSerialPort.Open();
		}

		public void Stop() {
			thunderboltSerialPort.Close();
		}

		private void PacketReceived(ThunderboltPacket packet) {
			if (packet.IsPacketValid) {
				if (packet.ID == 0x8F && packet.Data.Count == 17 && packet.Data[0] == 0xAB) {
					int timeOfWeek = packet.Data[1] << 24 | packet.Data[2] << 16 | packet.Data[3] << 8 | packet.Data[4];
					ushort weekNumber = (ushort) (packet.Data[5] << 8 | packet.Data[6]);
					short utcOffset = (short) (packet.Data[7] << 8 | packet.Data[8]);

					// The Thunderbolt can take up to 12.5 minutes to receive the UTC offset
					if (utcOffset == 0) {
						Log?.Invoke("Thunderbolt has not yet recieved UTC offset.", LogLevel.Error);
						return;
					}

					// Current epoch for GPS week numbers is the morning of 22/8/1999
					DateTime dateTime = new DateTime(1999, 8, 22, 0, 0, 0);

					dateTime = dateTime.AddDays(7 * weekNumber);
					dateTime = dateTime.AddSeconds(timeOfWeek);

					dateTime = dateTime.AddSeconds(-utcOffset);

					TimeAvailable?.Invoke(dateTime);
				}
			} else {
				Log?.Invoke("An invalid packet was received.", LogLevel.Warning);
			}
		}
	}
}
