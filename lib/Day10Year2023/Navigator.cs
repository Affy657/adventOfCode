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
            Pipe oldNeighbor = null;

            while (!finishLoop)
            {
                Pipe nextPipe = currentPipe.NextPipe(oldNeighbor);
                oldNeighbor = currentPipe;
                currentPipe = nextPipe;
                lenthLoop++;
                finishLoop = currentPipe == startPoint;

            }
            return lenthLoop/2;
        }
    }
}
