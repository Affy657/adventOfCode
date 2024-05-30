using Lib.Day05Year2023;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Lib.IAlgo;

namespace Lib.Day10Year2023
{
    public class Algo2023Day10 : IAlgo
    {
        public YearAndDayAndBonus GetYearAndDayAndBonus() => new() { Year = 2023, Day = 10, Bonus = false };
        public readonly MapsBuilder MapsBuilder;
        public readonly Navigator Navigator;

        public Algo2023Day10()
        {
            this.MapsBuilder = new();
            this.Navigator = new();
        }
        public string Solve(string[] input, bool isBonus = false)
        {           
            List<List<Pipe>> maps = MapsBuilder.CreateNetwork(input);
            Pipe startPipe = MapsBuilder.FindStartPipe(maps);

            if (isBonus)
            {
                int numberOfPipesEnclosed = Navigator.GetNumberOfPipesEnclosed(startPipe, maps);

                return numberOfPipesEnclosed.ToString();
            }
            else
            {
                int furthestPoint = Navigator.GetFurthestPoint(startPipe);

                return furthestPoint.ToString();
            }
        }
    }
}
