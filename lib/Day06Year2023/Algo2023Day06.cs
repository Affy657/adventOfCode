using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Day06Year2023
{
    internal class Algo2023Day06 : IAlgo
    {


        public string Solve(string[] input, bool isBonus = false)
        {
            RaceRecordBuilder builder = new RaceRecordBuilder();
            List<RaceRecord>  raceRecordList = builder.Parse(input, isBonus);
            List<long> newRecord = new List<long>();
            foreach (RaceRecord raceRecord in raceRecordList)
            {
                newRecord.Add(raceRecord.NumberOfNewRecord());
            }
            long multiplyNewRecord = 1;
            for (int i = 0;i<newRecord.Count;i++)
            {
                if(newRecord[i] != 0)
                {
                    multiplyNewRecord = multiplyNewRecord * newRecord[i];
                }
            }
            
            return multiplyNewRecord.ToString();
        }
    }
}
