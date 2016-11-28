// Utils.cs in David Knoble's Project 

using System;

namespace Knoble.Utils
{
	public static class Utils
	{
		static Random rng = new Random ();

		/// <summary>
		/// Returns a random date in the specified range.
		/// </summary>
		/// <returns>The date in range.</returns>
		/// <param name="from">From.</param>
		/// <param name="to">To.</param>
		public static DateTime RandomDateInRange (DateTime from, DateTime to)
		{
			//code and ideas found here: http://stackoverflow.com/questions/194863/random-date-in-c-sharp
			int range = (from - to).Days;
			return from.AddDays (rng.Next (range));
		}

		/// <summary>
		/// Returns a random date between start date and now. By default, uses DateTime.Now, but setting
		/// Utc to true will use DateTime.UtcNow.
		/// </summary>
		/// <returns>The date.</returns>
		/// <param name="start">Start.</param>
		/// <param name="Utc">Utc</param>
		public static DateTime RandomDate (DateTime start, bool Utc = false)
		{
			if (Utc)
			{
				return RandomDateInRange (start, DateTime.UtcNow);
			}
			return RandomDateInRange (start, DateTime.Now);
		}

		/// <summary>
		/// Returns a random date between 1/1/0001 and now.
		/// </summary>
		/// <returns>The date.</returns>
		/// <param name="Utc">If set to <c>true</c> UTC.</param>
		public static DateTime RandomDate (bool Utc = false)
		{
			return RandomDate (new DateTime (0), Utc);
		}

		/// <summary>
		/// Creates a <see cref="T:Knoble.Utils.Loading"/> object for displaying loading text to the console.
		/// </summary>
		/// <returns>The <see cref="T:Knoble.Utils.Loading"/> object.</returns>
		/// <param name="productName">Product name.</param>
		/// <param name="loadingText">Loading text.</param>
		/// <param name="millisecondsDelay">Milliseconds delay.</param>
		public static ConsoleLoadingText CreateLoading (string productName = ConsoleLoadingText.DefaultProductName, string loadingText = ConsoleLoadingText.DefaultLoadingText, int millisecondsDelay = ConsoleLoadingText.DefaultMillisecondsDelay)
		{
			return new ConsoleLoadingText (productName, loadingText, millisecondsDelay);
		}
	}
}
