﻿using Lib.Day07Year2023;
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
        public string Solve(string[] input, bool isBonus = false)
        {
            Path path = new();
            List<Direction> paths = path.getPaths(input[0]);

            NetWork netWork = new NetWork();
            List<Node> firstNode = netWork.GetFirstNode(input[2..], isBonus);

            Navigator navigator = new Navigator();
            int numberOfNodesCrossed = navigator.Navigate(paths, firstNode, isBonus);

            return numberOfNodesCrossed.ToString();
        }
    }
}
