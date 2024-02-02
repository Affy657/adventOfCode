using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib.Day05Year2023
{
    internal class SeedModificator
    {
        private readonly List<Map> maps;
        private readonly long seedInput;

        public SeedModificator(List<Map> maps, long seedInput) 
        {
            this.maps = maps;
            this.seedInput = seedInput;
        }

        public long ModifySeed()
        {
            long SeedOutput = seedInput;

            foreach (Map currenMap in maps)
            {
                if (seedInput >= currenMap.StartSeed && seedInput < currenMap.StartSeed + currenMap.Range)
                {
                    SeedOutput = currenMap.StartMap + (seedInput - currenMap.StartSeed);
                }
            }

            return SeedOutput;
        }
    }
}
