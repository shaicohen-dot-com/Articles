using System;

namespace ExceptionLogging
{
	public static class ExceptionExtensions
	{
		/// <summary>
		/// the key element of the logged state key/value pair
		/// </summary>
		private const string __IsLoggedKey = "IsLogged";

		/// <summary>
		/// Logs the current exception. 
		/// <para>A new log will not be created if this exception has already been logged. The parameter <paramref name="forceLog"/> can be used to force logging of the exception.</para>
		/// </summary>
		/// <param name="exception">The exception being logged</param>
		/// <param name="message">The message that describes the error</param>
		/// <param name="forceLog">Forces logging of exception</param>
		public static void Log(this Exception exception, string message, bool forceLog = false)
		{
			if (exception.IsLogged() && !forceLog)
				return;

			//use logging framework of choice here

			exception.MarkAsLogged();
		}

		/// <summary>
		/// If this exception has been logged.
		/// </summary>
		/// <param name="exception">The exception being logged</param>
		/// <returns></returns>
		public static bool IsLogged(this Exception exception) => exception.Data?.Contains(__IsLoggedKey) ?? false;

		/// <summary>
		/// Mark the exception as logged.
		/// </summary>
		/// <param name="exception">The exception being logged</param>
		private static void MarkAsLogged(this Exception exception) => exception.Data?.[__IsLoggedKey] = true; // we are able to avoid the messy coding for creating/updating keys, because (MSDN) "If the specified key is not found a set operation creates a new element with the specified key."

		/// <summary>
		/// SHOWN AS EXAMPLE VS SINGLE-LINE VERSION (beautiful, isn't it?)
		/// Mark the exception as logged.
		/// </summary>
		/// <param name="exception">The exception being logged</param>
		private static void MarkAsLoggedLongForm(this Exception exception)
		{
			// can't wait for non-nullable reference types
			if (exception.Data == null) 
				return;

			if (exception.Data.Contains(__IsLoggedKey))
			{
				exception.Data[__IsLoggedKey] = true;
				return;
			}
			exception.Data.Add(__IsLoggedKey, true);


		}

	}
}
