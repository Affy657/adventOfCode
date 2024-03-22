using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Day08Year2023
{
    public class Path
    {
        public List<Direction> getPaths(string line) 
        {
            List<Direction> Paths = new List<Direction>();
            for (int i = 0; i < line.Length; i++)
            {
                Paths.Add(new Direction(line[i]));
            }
            return Paths;

        }
    }
}
