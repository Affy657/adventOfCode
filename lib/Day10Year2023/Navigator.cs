using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Day10Year2023
{
    public class Navigator
    {
        public static readonly List<int> TOP = [-1, 0];
        public static readonly List<int> BOTTOM = [1, 0];
        public static readonly List<int> LEFT = [0, -1];
        public static readonly List<int> RIGHT = [0, 1];

        public List<Pipe> EnclosedPipeNeighbor = [];
        public List<Pipe> UnfencedPipeNeighbor = [];
        public List<Pipe> LoopPipes = [];
        public int UnfencedCorner = 0;
        public int EnclosedCorner = 0;

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
        public void NavigateOnLoop(Pipe startPoint, List<List<Pipe>> maps)
        {
            bool finishLoop = false;
            Pipe currentPipe = startPoint;
            Pipe oldPipe = null;
            

            while (!finishLoop)
            {
                Pipe nextPipe = currentPipe.NextPipe(oldPipe);
                oldPipe = currentPipe;
                currentPipe = nextPipe;
                currentPipe.GetEnclosedNeighbor(oldPipe);

                EnclosedPipeNeighbor.AddRange(CheckEnclosedNeighbors(currentPipe, currentPipe.EnclosedNeighbor, maps));
                UnfencedPipeNeighbor.AddRange(CheckEnclosedNeighbors(currentPipe, currentPipe.UnfencedNeighbor, maps));
                EnclosedCorner += currentPipe.GetEnclosedCorner(oldPipe);
                UnfencedCorner += currentPipe.GetUnfencedCorner(oldPipe);
                LoopPipes.Add(currentPipe);

                finishLoop = currentPipe == startPoint;
            }
        }

        public int GetNumberOfPipesEnclosed(Pipe startPoint, List<List<Pipe>> maps)
        {
            NavigateOnLoop(startPoint, maps);
            NavigateOnMapsForBuildEnclosedPipes(maps);
            
            return EnclosedPipeNeighbor.Count;
        }
        public void NavigateOnMapsForBuildEnclosedPipes(List<List<Pipe>> maps)
        {
            List<Pipe> EnclosedPipeNeighborTrue;
            if (EnclosedCorner == 4)
            {
                EnclosedPipeNeighborTrue = EnclosedPipeNeighbor;
            }
            else
            {
                EnclosedPipeNeighborTrue = UnfencedPipeNeighbor;
                EnclosedPipeNeighbor = UnfencedPipeNeighbor;
            }

            bool completeMap = false;
            while (!completeMap)
            {
               completeMap = true;
                List<Pipe> EnclosedPipeNeighborCopy = EnclosedPipeNeighborTrue;

                foreach (Pipe currentpipe in EnclosedPipeNeighborTrue)
                {
                    if (IsValidCoordinate(TOP, maps, currentpipe.Y, currentpipe.X))
                    {
                        Pipe translatePipe = maps[currentpipe.Y + TOP[0]][currentpipe.X + TOP[1]];
                        if (!LoopPipes.Contains(translatePipe) && !EnclosedPipeNeighborCopy.Contains(translatePipe))
                        {
                            EnclosedPipeNeighbor.Add(translatePipe);
                            completeMap = false;
                        }                           
                    }
                    if (IsValidCoordinate(BOTTOM, maps, currentpipe.Y, currentpipe.X))
                    {
                        Pipe translatePipe = maps[currentpipe.Y + BOTTOM[0]][currentpipe.X + BOTTOM[1]];
                        if (!LoopPipes.Contains(translatePipe) && !EnclosedPipeNeighborCopy.Contains(translatePipe))
                        {
                            EnclosedPipeNeighbor.Add(translatePipe);
                            completeMap = false;

                        }
                    }
                    if (IsValidCoordinate(LEFT, maps, currentpipe.Y, currentpipe.X))
                    {
                        Pipe translatePipe = maps[currentpipe.Y + LEFT[0]][currentpipe.X + LEFT[1]];
                        if (!LoopPipes.Contains(translatePipe) && !EnclosedPipeNeighborCopy.Contains(translatePipe))
                        {
                            EnclosedPipeNeighbor.Add(translatePipe);
                            completeMap = false;

                        }
                    }
                    if (IsValidCoordinate(RIGHT, maps, currentpipe.Y, currentpipe.X))
                    {
                        Pipe translatePipe = maps[currentpipe.Y + RIGHT[0]][currentpipe.X + RIGHT[1]];
                        if (!LoopPipes.Contains(translatePipe) && !EnclosedPipeNeighborCopy.Contains(translatePipe))
                        {
                            EnclosedPipeNeighbor.Add(translatePipe);
                            completeMap = false;

                        }
                    }

                }
                EnclosedPipeNeighbor.AddRange(EnclosedPipeNeighborCopy);
            }
            
        }
        public bool IsValidCoordinate(List<int> transformation, List<List<Pipe>> maps, int y, int x)
        {
            return transformation != null && maps[y][x] != null &&
                   y + transformation[0] >= 0 && y + transformation[0] < maps.Count &&
                   x + transformation[1] >= 0 && x + transformation[1] < maps[y + transformation[0]].Count;
        }

        public List<Pipe> CheckEnclosedNeighbors(Pipe currentPipe, List<List<int>> EnclosedNeighbors, List<List<Pipe>> maps)
        {
            List<Pipe> EnclosedPipeNeighbor = [];

            if (EnclosedNeighbors.Count != 0 )
            {
                return EnclosedPipeNeighbor;
            }

            foreach(List<int> EnclosedNeighbor in EnclosedNeighbors)
            {
                if(IsValidCoordinate(EnclosedNeighbor, maps, currentPipe.Y, currentPipe.X))
                {
                    EnclosedPipeNeighbor.Add(maps[currentPipe.Y + EnclosedNeighbor[0]][currentPipe.X + EnclosedNeighbor[1]]);
                }
            }

            return EnclosedPipeNeighbor;
        }
    }
}
