using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Xml.Linq;

namespace Lib.Day08Year2023
{
    public class Navigator
    {
        public string Target = "ZZZ";
        public int Navigate(List<Direction> path, Node currentNode)
        {
            int repeat = 0;
            int numberOfNodesCrossed = 0;
            bool targetFind = false;
            while (!targetFind)
            {
                repeat++;
                numberOfNodesCrossed = 0;
                while (!targetFind && numberOfNodesCrossed < path.Count)
                {
                    if (path[numberOfNodesCrossed].Left)
                    {
                        currentNode = currentNode.Links[0];
                    }
                    else if (path[numberOfNodesCrossed].Right)
                    {
                        currentNode = currentNode.Links[1];
                    }
                    if(currentNode.Name == Target)
                    {
                        targetFind = true;
                    }
                    numberOfNodesCrossed ++;
                }                
            }
            return path.Count * repeat + numberOfNodesCrossed + 1;
        }
    }
}
