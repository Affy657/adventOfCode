using Lib.Day09Year2023;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Lib.IAlgo;

namespace Lib.Day08Year2023
{
    public class Algo2023Day09 : IAlgo
    {
        public YearAndDayAndBonus GetYearAndDayAndBonus() => new() { Year = 2023, Day = 9, Bonus = true };
        private readonly ReportBuilder reportBuilder;
        private readonly Predictor predictor;
        public Algo2023Day09()
        {         
            this.reportBuilder = new();
            this.predictor = new();
        }
        public string Solve(string[] input, bool isBonus = false)
        {
            List<List<int>> report = reportBuilder.GetReport(input);
            List<int> predicats = predictor.GetPredicates(report, isBonus);

            return predicats.Sum().ToString();
        }
    }
}
