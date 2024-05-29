using Lib.Day07Year2023;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Xml.Linq;

namespace Lib.Day08Year2023
{
    public class Algo2023Day08 : IAlgo
    {
        public int Getday()
        {
            return 8;
        }
        private readonly Path path;
        private readonly NetWork netWork;
        private readonly Navigator navigator;
        public Algo2023Day08()
        {
            this.path = new();
            this.netWork = new();
            this.navigator = new();
        }
        public string Solve(string[] input, bool isBonus = false)
        {            
            List<Direction> paths = path.getPaths(input[0]);
            List<Node> firstNode = netWork.GetFirstNode(input[2..], isBonus);
            int numberOfNodesCrossed = navigator.Navigate(paths, firstNode, isBonus);

            return numberOfNodesCrossed.ToString();
        }
    }
}
