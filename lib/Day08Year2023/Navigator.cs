using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.IO;

namespace Lib.Day08Year2023
{
    public class Navigator
    {
        const string TARGET = "ZZZ";
        const char TARGETS = 'Z';
        public int Navigate(List<Direction> path, List<Node> currentNodes, bool isBonus)
        {
            int repeat = 0;
            int numberOfNodesCrossed = 0;
            bool targetFind = false;
            
            while (!targetFind)
            {              
                numberOfNodesCrossed = 0;

                while (!targetFind && numberOfNodesCrossed < path.Count)
                {
                    currentNodes = NextNode(currentNodes, path[numberOfNodesCrossed]);             
                    targetFind = IsTarget(currentNodes,isBonus);
                    numberOfNodesCrossed += !targetFind ? 1 : 0;
                }

                repeat += !targetFind ? 1 : 0;
            }

            return CalculateResult(path, repeat, numberOfNodesCrossed);
        }
        public bool IsTarget(List<Node> currentNodes, bool isBonus )
        {
            bool targetFind = true;
          
            foreach (Node node in currentNodes)
            {
                targetFind = targetFind && isBonus ? node.Name[^1] == TARGETS : node.Name == TARGET;
            }

            return targetFind;
        }
        public List<Node> NextNode(List<Node> currentNodes,Direction path)
        {
            for (int i = 0; i < currentNodes.Count; i++)
            {              
                currentNodes[i] = currentNodes[i].Links[path.Left ? 0 : 1];
            }
            return currentNodes;
        }
        public static int CalculateResult(List<Direction> path, int repeat, int numberOfNodesCrossed)
        {
            return path.Count * repeat + numberOfNodesCrossed + 1;
        }
    }
}
