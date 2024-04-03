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
            List<Direction> Paths = [];
            foreach (char c in line)
            {
                Paths.Add(new Direction(c));
            }
            return Paths;          
        }
    }
}
