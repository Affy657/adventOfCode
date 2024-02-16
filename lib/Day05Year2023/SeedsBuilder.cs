using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Day05Year2023
{
    public class SeedsBuilder
    {
        private readonly string[] input;
        private readonly bool isBonus;

        public List<Seed> Seeds { get; set; }

        public SeedsBuilder(string[] input, bool isBonus = false)
        {
            this.input = input ?? throw new ArgumentNullException(nameof(input));
            this.Seeds = new List<Seed>();
            this.isBonus = isBonus;
        }

        public void Build()
        {
            var rawSeedLine = input[0].Split(':');

            if(rawSeedLine.Length == 2)
            {
                var rawListOfNumbers = rawSeedLine[1].Trim();

                if (!string.IsNullOrWhiteSpace(rawListOfNumbers))
                {
                    
                    string[] arrayOfNumbersAsString = rawListOfNumbers.Split(' ');

                    List<long> arrayOfNumbers = arrayOfNumbersAsString.Select(long.Parse).ToList();
                    if (isBonus)
                    {
                        for (int i = 0; i < arrayOfNumbers.Count; i += 2)
                        {
                            Seed newSeed = new Seed(arrayOfNumbers[i], arrayOfNumbers[i + 1]);
                            Seeds.Add(newSeed);
                        }
                    }
                    else
                    {
                        foreach (var number in arrayOfNumbers)
                        {
                            Seed newSeed = new Seed(number);
                            Seeds.Add(newSeed);
                        }

                    }
                }
            }
        }
    }
}
