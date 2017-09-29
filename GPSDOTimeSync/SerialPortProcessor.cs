using System.IO.Ports;
using System.Threading;

namespace GPSDOTimeSync {
	abstract class SerialPortProcessor {
		private SerialPort serialPort;

		private bool running;
		private Thread readThread;

		/// <summary>
		/// Initializes the class with a serial port to communicate with.
		/// The serial port passed into this function must not be opened.
		/// </summary>
		/// <param name="serialPort">The serial port to communicate with.</param>
		public SerialPortProcessor(SerialPort serialPort) {
			this.serialPort = serialPort;

			readThread = new Thread(ReadSerialPort);
			readThread.Name = "Unnamed SerialPortProcessor Read";
		}

		/// <summary>
		/// Begins processing serial data and firing SentenceReceived events.
		/// </summary>
		public void Open() {
			running = true;

			serialPort.Open();
			readThread.Start();
		}

		/// <summary>
		/// Stops processing serial data and firing SentenceReceived events.
		/// </summary>
		public void Close() {
			running = false;

			readThread.Join();
			serialPort.Close();
		}

		protected abstract void ProcessByte(byte b);

		private void ReadSerialPort() {
			while (running) {
				if (serialPort.BytesToRead > 0) {
					int possibleCurrentByte = serialPort.ReadByte();

					if (possibleCurrentByte != -1) {
						ProcessByte((byte) possibleCurrentByte);
					}
				}
			}
		}
	}
}
