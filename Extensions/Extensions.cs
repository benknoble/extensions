// Extensions.cs in David Knoble's Project 

using System;

namespace Knoble.Extensions
{
	public static class Extensions
	{
		//TODO: create extensions

		/// <summary>
		/// Converts a string to an enumerated type.
		/// </summary>
		/// <returns>The enum value.</returns>
		/// <param name="s">S.</param>
		/// <typeparam name="TEnum">The enumerated type.</typeparam>
		/// <exception cref="ArgumentException">Thrown when TEnum is not an enumerated type.</exception>
		public static TEnum ToEnum<TEnum> (this string s) where TEnum : struct
		{
			if (!typeof (TEnum).IsEnum)
				throw new ArgumentException ($"{nameof (TEnum)} must be an enumerated type");

			TEnum t;
			if (Enum.TryParse (s, out t))
			{
				return t;
			}

			return default (TEnum);
		}

		/// <summary>
		/// Returns a random date between this date and the specified date.
		/// </summary>
		/// <returns>The date.</returns>
		/// <param name="from">From.</param>
		/// <param name="to">To.</param>
		public static DateTime RandomDateUpTo (this DateTime from, DateTime to)
		{
			return Utils.Utils.RandomDateInRange (from, to);
		}

		/// <summary>
		/// Returns a random date between this date and now. By default, uses DateTime.Now.
		/// Uses DateTime.UtcNow if Utc passed as true.
		/// </summary>
		/// <returns>The date.</returns>
		/// <param name="from">From.</param>
		/// <param name="Utc">If set to <c>true</c> UTC.</param>
		public static DateTime RandomDate (this DateTime from, bool Utc = false)
		{
			return Utils.Utils.RandomDate (from, Utc);
		}
	}
}
