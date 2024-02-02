using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib.Day05Year2023
{
    public class SeedsBuilder
    {
        private readonly string[] input;

        public List<long> Seeds { get; set; }

        public SeedsBuilder(string[] input)
        {
            this.input = input ?? throw new ArgumentNullException(nameof(input));
            this.Seeds = new List<long>();
        }

        public void Build()
        {
            var rawSeedLine = input[0].Split(':');

            if(rawSeedLine.Length == 2)
            {
                var rawListOfNumbers = rawSeedLine[1].Trim();

                if (!string.IsNullOrWhiteSpace(rawListOfNumbers))
                {
                    var arrayOfNumbersAsString = rawListOfNumbers.Split(' ');

                    var arrayOfNumbers = arrayOfNumbersAsString.Select(long.Parse);

                    Seeds = arrayOfNumbers.ToList();
                }
            }
        }
    }
}
