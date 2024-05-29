using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Lib.Day05Year2023;
using Lib;


namespace Lib.Day05Year2023
{
    internal class Algo2023Day05 : IAlgo
    {
        public int Getday()
        {
            return 5;
        }
        public string Solve(string[] input, bool isBonus = false)
        {
            SeedsBuilder seedsBuilder = new(input, isBonus);
            seedsBuilder.Build();

            MapsBuilder mapsBuilder = new(input);
            mapsBuilder.Build();

            Stopwatch stopwatch = Stopwatch.StartNew();

            List<long> allMinSeedTransormed = new List<long>();
            int i = 0;
            foreach (Seed seeds in seedsBuilder.Seeds)
            {
                List<long> seedTransormed = new List<long>();
                Console.WriteLine("Boucle {2} # Seed: {0}:{1}", seeds.Number, seeds.Range, ++i);
                for(long seed = seeds.Number; seed < seeds.Number + seeds.Range; seed++)
                {
                    SeedModificator modificator = new(mapsBuilder.CategoryList, seed);
                    seedTransormed.Add(modificator.ModifySeed());
                }
                Console.WriteLine("Terminé en: {0} ", stopwatch.Elapsed);
                allMinSeedTransormed.Add(seedTransormed.Min());
            }
            return allMinSeedTransormed.Min().ToString();   
        }
    }
}
