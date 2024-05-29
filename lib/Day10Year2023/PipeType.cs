using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Day10Year2023
{
    public class PipeType
    {
        /// <summary>
        /// | is a vertical pipe connecting north and south.
        /// </summary>
        public const char VERTICAL_PIPE = '|';
        /// <summary>
        /// - is a horizontal pipe connecting east and west.
        /// </summary>
        public const char HORIZONTAL_PIPE = '-';
        /// <summary>
        /// L is a 90-degree bend connecting north and east.
        /// </summary>
        public const char NORTHEAST_PIPE = 'L';
        /// <summary>
        /// J is a 90-degree bend connecting north and west.
        /// </summary>
        public const char NORTHWEST_PIPE = 'J';
        /// <summary>
        /// 7 is a 90-degree bend connecting south and west.
        /// </summary>
        public const char SOUTHWEST_PIPE = '7';
        /// <summary>
        /// F is a 90-degree bend connecting south and east.
        /// </summary>
        public const char SOUTHEAST_PIPE = 'F';
        /// <summary>
        /// . is ground; there is no pipe in this tile.
        /// </summary>
        public const char GROUND = '.';
        /// <summary>
        /// S is the starting position.*/
        /// </summary>
        public const char STARTING_PIPE = 'S';
    }
    public class DirectionType
    {
        public const string TO_TOP = "TO_TOP";
        public const string TO_BOTTOM = "TO_BOTTOM";
        public const string TO_RIGHT = "TO_RIGHT";
        public const string TO_LEFT = "TO_LEFT";

    }
}
