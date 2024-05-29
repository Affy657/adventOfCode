using Lib.Day09Year2023;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Day08Year2023
{
    public class Algo2023Day09 : IAlgo
    {     
        public int Getday()
        {
            return 9;
        }
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
