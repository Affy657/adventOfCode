using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Day08Year2023
{
    public class Direction
    {
        public bool Left { get; set; } = false;
        public bool Right { get; set; } = false;
        public Direction(char input) 
        {
            if(input == 'L')
            {
                Left = true;
            }
            else if(input == 'R')
            {
                Right = true;
            }
        }
    }
}
