using System.Collections.Generic;
using System.IO.Ports;

namespace ThunderboltTimeSync {
	public class ThunderboltSerialPort {
		private static readonly byte CHAR_DLE = 0x10;
		private static readonly byte CHAR_ETX = 0x03;

		private List<byte> packetBuffer;
		private bool inPacket;

		private SerialPort serialPort;

		/// <summary>
		/// A delegate which is called when a full packet is received over the serial port.
		/// The byte buffer passed in contains the initial [DLE], and final [DLE][ETX]. The buffer is completely unparsed and remains stuffed.
		/// </summary>
		/// <param name="packetBuffer">A byte buffer which contains the packet.</param>
		public delegate void PacketReceivedEventHandler(List<byte> packetBuffer);

		/// <summary>
		/// An event which is called when a full packet is received over the serial port.
		/// Refer to <see cref="PacketReceivedEventHandler"/> for more information.
		/// </summary>
		public event PacketReceivedEventHandler PacketReceived;

		/// <summary>
		/// Creates an instance of the ThunderboltSerialPort class, which processes serial data from a Thunderbolt and 
		/// The serial port passed into the function must not be opened, or have a delegate already attached to the DataReceived event.
		/// </summary>
		/// <param name="serialPort">The serial port on which to communicate with the Thunderbolt.</param>
		public ThunderboltSerialPort(SerialPort serialPort) {
			packetBuffer = new List<byte>();
			inPacket = false;

			this.serialPort = serialPort;
			serialPort.DataReceived += DataReceived;
		}

		/// <summary>
		/// Begins processing serial data.
		/// </summary>
		public void Open() {
			serialPort.Open();
		}

		private void DataReceived(object sender, SerialDataReceivedEventArgs e) {
			int possibleCurrentByte;

			while ((possibleCurrentByte = serialPort.ReadByte()) != -1) {
				// Once we're sure the byte that was read wasn't -1 (which signifies the end of the read), we're safe to cast to a byte
				byte currentByte = (byte) possibleCurrentByte;

				if (inPacket) {
					packetBuffer.Add(currentByte);

					// Check buffer length to ensure we've reached a plausible end of packet.
					// 5 bytes is [DLE]<id><1 byte of data>[DLE][ETX]
					if (currentByte == CHAR_ETX && packetBuffer.Count >= 5) {
						int numberOfPrecedingDLEs = 0;

						// Count number of DLEs, excluding the first two bytes (initial DLE and id)
						for (int i = 2; i < packetBuffer.Count; ++i) {
							if (packetBuffer[i] == CHAR_DLE) {
								++numberOfPrecedingDLEs;
							}
						}

						// Odd number of DLEs means the ETX does in fact signify the end of the packet
						if (numberOfPrecedingDLEs % 2 == 1) {
							PacketReceived?.Invoke(packetBuffer);

							packetBuffer.Clear();
							inPacket = false;
						}
					}
				} else {
					// A DLE received when not currently in a packet signifies the beginning of a packet
					if (currentByte == CHAR_DLE) {
						packetBuffer.Add(currentByte);

						inPacket = true;
					}
				}
			}
		}
	}
}