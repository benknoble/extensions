// Loading.cs in David Knoble's Project 
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Knoble.Utils
{
	/// <summary>
	/// A class that represents a possibily infinitely looping load screen.
	/// It displays a product name, loading text, and spinner that spins for a given delay.
	/// </summary>
	public class ConsoleLoadingText
	{
		public const string DefaultProductName = "";
		public const string DefaultLoadingText = "Loading...";
		public const int DefaultMillisecondsDelay = 250;

		static string[] spinner = { "|", "/", "-", @"\" };

		readonly string productName, loadingText;
		readonly int millisecondsDelay;

		int i;
		bool @continue = true;

		/// <summary>
		/// Initializes a new instance of the <see cref="T:Knoble.Utils.Loading"/> class.
		/// Defaults to displaying "Loading... x" where the spinner (x) spins every quarter second.
		/// </summary>
		public ConsoleLoadingText () : this (DefaultProductName)
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="T:Knoble.Utils.Loading"/> class.
		/// Defaults to displaying "{productName} Loading... x" where the spinner (x) spins every quarter second.
		/// </summary>
		/// <param name="productName">Product name.</param>
		public ConsoleLoadingText (string productName) : this (productName, DefaultLoadingText)
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="T:Knoble.Utils.Loading"/> class.
		/// Defaults to displaying "{productName} {loadingText} x" where the spinner (x) spins every quarter second.
		/// </summary>
		/// <param name="productName">Product name.</param>
		/// <param name="loadingText">Loading text.</param>
		public ConsoleLoadingText (string productName, string loadingText) : this (productName, loadingText, DefaultMillisecondsDelay)
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="T:Knoble.Utils.Loading"/> class.
		/// Displays "{productName} {loadingText} x" where the spinner (x) spins every {millisecondsDelay} milliseconds.
		/// </summary>
		/// <param name="productName">Product name.</param>
		/// <param name="loadingText">Loading text.</param>
		/// <param name="millisecondsDelay">Milliseconds delay.</param>
		public ConsoleLoadingText (string productName, string loadingText, int millisecondsDelay)
		{
			if (productName == null)
				throw new ArgumentException (nameof (productName));
			if (loadingText == null)
				throw new ArgumentException (nameof (loadingText));
			if (millisecondsDelay < 0)
				throw new ArgumentException (nameof (millisecondsDelay));
			this.productName = productName;
			this.loadingText = loadingText;
			this.millisecondsDelay = millisecondsDelay;
		}

		/// <summary>
		/// Returns a task that, when running, continously prints the loading text.
		/// </summary>
		public Task Display ()
		{
			return Task.Run (() =>
			{
				@continue = true;
				while (@continue)
				{
					Console.Write ($"\r{productName} {loadingText} {spinner[i]}");
					i = (i + 1) % spinner.Length;
					Thread.Sleep (millisecondsDelay);
				}
			});
		}

		/// <summary>
		/// Stop this instance from displaying.
		/// </summary>
		public void Stop ()
		{
			@continue = false;
		}
	}
}
