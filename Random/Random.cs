using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;

namespace Random
{
    public class Random
    {
        WebClient cli = null;
        string format = "http://www.random.org/integers/?num={0}&min={1}&max={2}&col=1&base=10&format=plain&rnd=new";

        /// <summary>
        /// Gets or sets a value that, when false, prevents actually calling Random.org  and generates a local pseudo-random value -- useful for testing offline scenarios 
        /// </summary>
        public bool UseLocalMode { get; set; }
        private System.Random localRandom = new System.Random((int)DateTime.Now.Ticks);
        public int Next(int min, int max)
        {
            if (!UseLocalMode)
            {
                cli = new WebClient();
                var data = cli.DownloadString(
                    string.Format(format, 1, min, max)
                    );
                if (string.IsNullOrEmpty(data))
                {
                    throw new Exception("No response from random.org");
                }

                int value = -1;
                if (int.TryParse(data, out value))
                {
                    return value;
                }
                else
                {
                    throw new ArgumentException("The value returned from random.org was not properly formatted");
                }
            }
            else
            {
                return localRandom.Next(min, max);
            }
        }
    }
}
