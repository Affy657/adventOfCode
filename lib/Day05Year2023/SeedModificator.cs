using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Day05Year2023
{
    internal class SeedModificator
    {
        private readonly List<Category> categoryList;
        private readonly long seedInput;

        public SeedModificator(List<Category> categoryList, long seedInput) 
        {
            this.categoryList = categoryList;
            this.seedInput = seedInput;
        }

        public long ModifySeed()
        {
            long seedOutput = seedInput;

            foreach (Category currenCat in categoryList)
            {
                seedOutput = currenCat.Apply(seedOutput);
            }

            return seedOutput;
        }
    }
}
