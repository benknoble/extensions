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
        /// <summary>
        /// A default product name.
        /// </summary>
		public const string DefaultProductName = "";
        /// <summary>
        /// A default loading text that can be used.
        /// </summary>
		public const string DefaultLoadingText = "Loading...";
        /// <summary>
        /// A default milliseconds delay of 250 ms.
        /// </summary>
		public const int DefaultMillisecondsDelay = 250;

        static readonly string[] spinner = { "|", "/", "-", @"\" };

        readonly string productName, loadingText;
        readonly int millisecondsDelay;

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
        public Task Display (CancellationToken ct)
        {
            return Task.Run (
                () =>
                {
                    int i = 0;
                    while (!ct.IsCancellationRequested)
                    {
                        Console.Write ($"\r{productName} {loadingText} {spinner[i]}");
                        i = (i + 1) % spinner.Length;
                        Thread.Sleep (millisecondsDelay);
                    }
                },
            cancellationToken: ct);
        }
    }
}
