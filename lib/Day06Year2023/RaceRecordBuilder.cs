using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Lib.Day06Year2023
{
    public class RaceRecordBuilder
    {
        private ISpaceRemove spaceRemove;
        public static Regex regex = new Regex(@"\d+");

        public RaceRecordBuilder() 
        {
            this.spaceRemove = new SpaceRemove();
        }

        public List<RaceRecord> Parse(string[] input,bool isBonus)
        {
            LineInput initaleTime = Parse(input[0], isBonus);
            LineInput initaleDistance = Parse(input[1], isBonus);

            List<RaceRecord> raceRecordList = new();
            for (int i = 0;i<initaleTime.Numbers.Count;i++)
            {
                raceRecordList.Add(new RaceRecord(initaleTime.Numbers[i], initaleDistance.Numbers[i]));
            }
            return raceRecordList;
        }

        private LineInput Parse(string line, bool isBonus)
        {
            //label
            string[] newLine = line.Split(':');
            string label = newLine[0];
            string valueNumbersLine = newLine[1];
            if (isBonus)
            {
                valueNumbersLine = spaceRemove.SpaceRemover(valueNumbersLine);
            }

            //number
            List<long> numbers = new(); 
            foreach (Match match in regex.Matches(valueNumbersLine))
            {
                numbers.Add(long.Parse(match.Value));
            }

            //new LineInput
            LineInput lineParsed = new(label, numbers);

            return lineParsed;
        }
    }
}
