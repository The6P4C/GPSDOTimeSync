using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Text;

namespace GPSDOTimeSync.TimeProviders.NMEA {
	public class NMEASentence {
		/// <summary>
		/// The validity of the NMEA sentence.
		/// If <code>false</code>, the values of <code>Talker</code>, <code>MessageType</code>, <code>Data</code>, <code>Checksum</code> and <code>RawSentence</code> must not be used.
		/// If <code>true</code>, the sentence may still contain invalid values.
		/// </summary>
		public bool IsSentenceValid { get; }

		/// <summary>
		/// The talker of the NMEA sentence.
		/// </summary>
		public string Talker { get; }

		/// <summary>
		/// The NMEA message type.
		/// </summary>
		public string MessageType { get; }

		/// <summary>
		/// The data fields of the NMEA message.
		/// </summary>
		public List<string> Data { get; }

		/// <summary>
		/// The checksum of the message, if present.
		/// If the message did not contain a checksum, <code>Checksum</code> equals -1.
		/// </summary>
		public int Checksum { get; }

		/// <summary>
		/// The raw, unparsed NMEA sentence.
		/// </summary>
		public string RawSentence { get; }

		public NMEASentence(bool isSentenceValid, string talker, string messageType, List<string> data, int checksum, string rawSentence) {
			IsSentenceValid = isSentenceValid;

			Talker = talker;
			MessageType = messageType;
			Data = data;
			Checksum = checksum;

			RawSentence = rawSentence;
		}
	}

	class NMEASerialPort : SerialPortProcessor {
		private StringBuilder sentenceBuffer;
		private bool inSentence;

		/// <summary>
		/// A delegate which is used for the <code>SentenceReceived</code> event.
		/// </summary>
		/// <param name="sentence">The parsed NMEA sentence which was received.</param>
		public delegate void SentenceReceivedEventHandler(NMEASentence sentence);

		/// <summary>
		/// An event which is called when a sentence is received over the serial port.
		/// </summary>
		public event SentenceReceivedEventHandler SentenceReceived;

		public NMEASerialPort(SerialPort serialPort) : base(serialPort) {
			sentenceBuffer = new StringBuilder();
			inSentence = false;
		}

		private void ProcessSentence() {
			string sentence = sentenceBuffer.ToString();

			List<string> components = new List<string>(sentence.Split(','));

			string talkerAndMessageType = components[0];
			string talker = talkerAndMessageType.Substring(0, 2);
			string messageType = talkerAndMessageType.Substring(2);

			List<string> data = components.GetRange(1, components.Count - 1);

			string lastEntry = data[data.Count - 1];

			int checksum = -1;

			// Check if last entry is long enough to have a checksum at the end, and if so,
			// if there's a star character there
			if (lastEntry.Length >= 3 && lastEntry[lastEntry.Length - 3] == '*') {
				// Fix last entry by removing checksum
				data[data.Count - 1] = lastEntry.Substring(0, lastEntry.Length - 3);

				string checksumString = lastEntry.Substring(lastEntry.Length - 2);
				checksum = Convert.ToInt32(checksumString, 16);
			}

			SentenceReceived?.Invoke(new NMEASentence(true, talker, messageType, data, checksum, sentence));
		}

		protected override void ProcessByte(byte b) {
			char c = (char) b;

			if (inSentence) {
				if (c != '\r') {
					sentenceBuffer.Append(c);
				} else {
					ProcessSentence();

					sentenceBuffer = new StringBuilder();
					inSentence = false;
				}
			} else {
				if (c == '$') {
					inSentence = true;
				}
			}
		}
	}
}
