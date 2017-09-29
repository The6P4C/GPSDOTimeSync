using System;

namespace GPSDOTimeSync.TimeProviders {
	/// <summary>
	/// Called when the time provider has a new time and date available.
	/// </summary>
	/// <param name="time">The current time and date, according to the time provider.</param>
	public delegate void TimeAvailableEventHandler(DateTime dateTime);

	/// <summary>
	/// Called when the time provider wishes to log a message or an error.
	/// </summary>
	/// <param name="message">The message for the log.</param>
	/// <param name="isError">True if the message constitutes an error, false otherwise.</param>
	public delegate void LogEventHandler(string message, LogLevel logLevel);

	public enum LogLevel {
		Info,
		Warning,
		Error
	}

	public interface ITimeProvider {
		/// <summary>
		/// Called when the time provider has a new time and date available.
		/// </summary>
		event TimeAvailableEventHandler TimeAvailable;

		/// <summary>
		/// Called when the time provider wishes to log a message or an error.
		/// </summary>
		event LogEventHandler Log;

		/// <summary>
		/// Begins providing time information by firing the TimeAvailable event, and log information through the Log event.
		/// </summary>
		void Start();

		/// <summary>
		/// Stops providing time information through the TimeAvailable event, and log information through the Log event.
		/// </summary>
		void Stop();
	}
}
