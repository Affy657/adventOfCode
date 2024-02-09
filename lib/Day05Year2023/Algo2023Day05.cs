using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using lib.Day05Year2023;
using Lib;


namespace Lib.Day05Year2023
{
    internal class Algo2023Day05 : IAlgo
    {
        public string Solve(string[] input, bool isBonus = false)
        {
            return isBonus ? Standard(input) : Bonus(input);
        }
        public string Bonus(string[] input)
        {
            return default;
        }
        public string Standard(string[] input)
        {
            SeedsBuilder seedsBuilder = new(input);
            seedsBuilder.Build();

            MapsBuilder mapsBuilder = new(input);
            mapsBuilder.Build();

            List<long> seedTransormed = new List<long>();
            foreach (long seed in seedsBuilder.Seeds)
            {
                SeedModificator modificator = new(mapsBuilder.CategoryList, seed);
                seedTransormed.Add(modificator.ModifySeed());
            }
            return seedTransormed.Min().ToString();
        }
    }
}
