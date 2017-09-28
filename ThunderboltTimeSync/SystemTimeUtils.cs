using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ThunderboltTimeSync {
	class SystemTimeUtils {
		[StructLayout(LayoutKind.Sequential)]
		private struct SYSTEMTIME {
			public short wYear;
			public short wMonth;
			public short wDayOfWeek;
			public short wDay;
			public short wHour;
			public short wMinute;
			public short wSecond;
			public short wMilliseconds;
		};

		[DllImport("kernel32.dll")]
		private static extern uint GetLastError();

		[DllImport("kernel32.dll", SetLastError = true)]
		private static extern bool SetSystemTime(ref SYSTEMTIME lpSystemTime);

		[DllImport("kernel32.dll")]
		private static extern void GetSystemTime(ref SYSTEMTIME lpSystemTime);

		/// <summary>
		/// Sets the system time.
		/// </summary>
		/// <param name="dateTime">The date and time to set the system clock to.</param>
		public static void SetTime(DateTime dateTime) {
			SYSTEMTIME systemTime = new SYSTEMTIME();

			systemTime.wYear = (short) dateTime.Year;
			systemTime.wMonth = (short) dateTime.Month;
			// wDayOfWeek is ignored by SetSystemTime
			systemTime.wDay = (short) dateTime.Day;
			systemTime.wHour = (short) dateTime.Hour;
			systemTime.wMinute = (short) dateTime.Minute;
			systemTime.wSecond = (short) dateTime.Second;
			systemTime.wMilliseconds = (short) dateTime.Millisecond;

			bool setSucceeded = SetSystemTime(ref systemTime);

			if (!setSucceeded) {
				Debug.WriteLine(string.Format("Call failed: error = {0}", GetLastError()));
			}
		}

		/// <summary>
		/// Retrieves the current system time.
		/// </summary>
		/// <returns>The current system time.</returns>
		public static DateTime GetTime() {
			SYSTEMTIME systemTime = new SYSTEMTIME();
			GetSystemTime(ref systemTime);

			DateTime systemDateTime = new DateTime(
				systemTime.wYear, systemTime.wMonth, systemTime.wDay,
				systemTime.wHour, systemTime.wMinute, systemTime.wSecond, systemTime.wMilliseconds
			);

			return systemDateTime;
		}
	}
}
