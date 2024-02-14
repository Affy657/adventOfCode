using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Day06Year2023
{
    public class RaceRecord
    {
        public int Time { get; set; }
        public int Distance { get; set; }

        public RaceRecord(int Time,int Distance) 
        {
            this.Time = Time;
            this.Distance = Distance;
        }
        public int NumberOfNewRecord() 
        {
            int numberOfNewRecord = 0;
            for (int i = 0;i<Time;i++)
            {
                int raceDistance = (Time-i)*i;
                if(raceDistance > Distance)
                {
                    numberOfNewRecord++;
                }
            }

            return numberOfNewRecord;
        }
    }
}
