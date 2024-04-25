using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Day10Year2023
{
    public class Algo2023Day10 : IAlgo
    {
        public readonly MapsBuilder MapsBuilder;
        public readonly Navigator navigator;

        public Algo2023Day10()
        {
            this.MapsBuilder = new();
            this.navigator = new Navigator();
        }
        public string Solve(string[] input, bool isBonus = false)
        {
            Pipe startPipe = MapsBuilder.GetStartPipe(input);
            int furthestPoint = navigator.GetFurthestPoint(startPipe);
            return furthestPoint.ToString();
        }
    }
}
