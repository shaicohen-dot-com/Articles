using ExceptionLogging.SkeletonClasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExceptionLogging
{
	class SampleExceptionLogging
	{
		public void CreateBookings(string[] people)
		{
			try
			{
				foreach (string person in people)
				{
					CreateBookingForPerson(person);
				}
			}
			catch (Exception e)
			{
				Logger.LogError(e);
			}
		}

		public void CreateBookingForPerson(string person)
		{
			BookingRepo.CreateBooking(person);
		}
	}
}
