using System;
using System.Runtime.InteropServices;

namespace ThunderboltTimeSync {
	class SystemTimeUtils {
		public class SystemTimeException : Exception {
			public SystemTimeException(int hresult) : base(string.Format("The system time could not be set (HRESULT 0x{0:X8}).", hresult)) {
				HResult = hresult;
			}
		}

		private class WindowsAPI {
			[StructLayout(LayoutKind.Sequential)]
			public struct SYSTEMTIME {
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
			public static extern int GetLastError();

			[DllImport("kernel32.dll", SetLastError = true)]
			public static extern bool SetSystemTime(ref SYSTEMTIME lpSystemTime);

			[DllImport("kernel32.dll")]
			public static extern void GetSystemTime(ref SYSTEMTIME lpSystemTime);
		}

		/// <summary>
		/// Sets the system time.
		/// </summary>
		/// <param name="dateTime">The date and time to set the system clock to.</param>
		public static void SetSystemTime(DateTime dateTime) {
			WindowsAPI.SYSTEMTIME systemTime = new WindowsAPI.SYSTEMTIME();

			systemTime.wYear = (short) dateTime.Year;
			systemTime.wMonth = (short) dateTime.Month;
			// wDayOfWeek is ignored by SetSystemTime
			systemTime.wDay = (short) dateTime.Day;
			systemTime.wHour = (short) dateTime.Hour;
			systemTime.wMinute = (short) dateTime.Minute;
			systemTime.wSecond = (short) dateTime.Second;
			systemTime.wMilliseconds = (short) dateTime.Millisecond;

			bool setSucceeded = WindowsAPI.SetSystemTime(ref systemTime);

			if (!setSucceeded) {
				throw new SystemTimeException(WindowsAPI.GetLastError());
			}
		}

		/// <summary>
		/// Retrieves the current system time.
		/// </summary>
		/// <returns>The current system time.</returns>
		public static DateTime GetSystemTime() {
			WindowsAPI.SYSTEMTIME systemTime = new WindowsAPI.SYSTEMTIME();
			WindowsAPI.GetSystemTime(ref systemTime);

			DateTime systemDateTime = new DateTime(
				systemTime.wYear, systemTime.wMonth, systemTime.wDay,
				systemTime.wHour, systemTime.wMinute, systemTime.wSecond, systemTime.wMilliseconds
			);

			return systemDateTime;
		}
	}
}
