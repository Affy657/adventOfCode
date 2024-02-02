using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace lib.Day05Year2023
{
    internal class MapsBuilder
    {
        public List<Map> maps {  get; set; }

        private const string pattern = @"(\d+)\s+(\d+)\s+(\d+)";
        private readonly string[] input;

        public MapsBuilder(string[] input) 
        {
            this.input = input;
            this.maps = new List<Map>();
        }

        public void Build()
        {
            foreach (string line in input)
            {
                Match match = Regex.Match(line, pattern);
                if (match.Success)
                {
                    List<long> numbers = new List<long>();
                    for (int i = 1; i <= 3; i++)
                    {
                        numbers.Add(long.Parse(match.Groups[i].Value));
                    }
                    maps.Add(new Map(numbers));
                }
            }
        }
    }
}
