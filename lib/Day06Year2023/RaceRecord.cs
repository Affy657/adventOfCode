using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Day06Year2023
{
    public class RaceRecord
    {
        public long Time { get; set; }
        public long Distance { get; set; }

        public RaceRecord(long Time, long Distance) 
        {
            this.Time = Time;
            this.Distance = Distance;
        }
        public long NumberOfNewRecord() 
        {
            long numberOfNewRecord = 0;
            for (long i = 0;i<Time;i++)
            {
                long raceDistance = (Time-i)*i;
                if(raceDistance > Distance)
                {
                    numberOfNewRecord++;
                }
            }

            return numberOfNewRecord;
        }
    }
}
