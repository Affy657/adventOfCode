using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Day09Year2023
{
    public class ReportBuilder
    {
        public List<List<int>> GetReport(string[] input) 
        {
            List<List<int>> report = [];
            foreach(string line in input)
            {
                List<int> history = line.Split(" ")
                    .Select(int.Parse)
                    .ToList();

                report.Add(history);
            }
            return report;
        }
    }
}
