using ExceptionLogging.SkeletonClasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExceptionLogging
{
	class ExceptionLoggingWithDetails
	{
		public void CreateBookings(string[] people)
		{
			try
			{
				foreach (string person in people)
					CreateBookingForPerson(person);
			}
			catch (Exception e) when (!e.IsLogged())
			{
				string errorMsg = "An error occurred while creating bookings.";
				e.Log(errorMsg);
				throw;
			}
		}

		public void CreateBookingForPerson(string person)
		{
			try
			{
				BookingRepo.CreateBooking(person);
			}
			catch (Exception e) when (!e.IsLogged())
			{
				string errorMsg = $"An error occurred while creating a booking for person {person}.";
				e.Log(errorMsg);
				throw;
			}
		}
	}
}
