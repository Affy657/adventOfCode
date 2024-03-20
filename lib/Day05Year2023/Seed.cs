using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Day05Year2023
{
    public class Seed
    {
        public long Number { get; set; }
        public long Range { get; set; }

        public Seed(long seedNumber, long seedRange = 1) 
        {
            this.Number = seedNumber;
            this.Range = seedRange;
        }
    }
}
