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
        public RaceRecordBuilder() { }
        public static Regex regex = new Regex(@"\d+");

        public static List<RaceRecord> Parse(string[] input)
        {
            LineInput initaleTime = Parse(input[0]);
            LineInput initaleDistance = Parse(input[1]);

            List<RaceRecord> raceRecordList = new();
            for (int i = 0;i<initaleTime.Numbers.Count;i++)
            {
                raceRecordList.Add(new RaceRecord(initaleTime.Numbers[i], initaleDistance.Numbers[i]));
            }
            return raceRecordList;
        }

        private static LineInput Parse(string line)
        {
            //label
            string[] newLine = line.Split(':');
            string label = newLine[0];

            //number
            List<int> numbers = new(); 
            foreach (Match match in regex.Matches(newLine[1]))
            {
                numbers.Add(int.Parse(match.Value));
            }

            //new LineInput
            LineInput lineParsed = new(label, numbers);

            return lineParsed;
        }
    }
}
