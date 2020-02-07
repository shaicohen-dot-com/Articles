using System;
using System.Collections.Generic;
using System.Text;

namespace ExceptionLogging.SkeletonClasses
{
	internal static class Logger
	{
		internal static void LogError(Exception e) { }
	}

	internal static class BookingRepo
	{
		internal static void CreateBooking(string person) { }
	}

}
