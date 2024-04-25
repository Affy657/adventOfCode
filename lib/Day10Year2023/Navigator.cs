using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Day10Year2023
{
    public class Navigator
    {
        public int GetFurthestPoint(Pipe startPoint)
        {
            bool finishLoop = false;
            Pipe currentPipe = startPoint;
            int lenthLoop = 0;
            Pipe oldNeighbor = new(0,0,'.');

            while (!finishLoop)
            {
                for(int i = 0; i < currentPipe.Neighbor.Count; i++) 
                {
                    if (oldNeighbor != currentPipe.Neighbor[i]  && currentPipe.Neighbor[i].Neighbor.Contains(currentPipe))
                    {
                        oldNeighbor = currentPipe;
                        currentPipe = currentPipe.Neighbor[i];
                        i = currentPipe.Neighbor.Count;
                        lenthLoop++;
                        finishLoop = currentPipe == startPoint;
                    }
                }
            }
            return lenthLoop/2;
        }
    }
}
