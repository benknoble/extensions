// MyClass.cs in David Knoble's Project 

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
	}
}
