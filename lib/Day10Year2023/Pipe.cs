using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Day10Year2023
{
    public class Pipe
    {
        public int Y;
        public int X; 
        public char Type;
        public List<List<int>> NeighborCoordinate;
        public List<Pipe> Neighbor {  get; set; }
        public static readonly List<int> TOP = [-1, 0];
        public static readonly List<int> BOTTOM = [1, 0];
        public static readonly List<int> LEFT = [0, -1];
        public static readonly List<int> RIGHT = [0, 1];
        public Pipe(int y,int x, char type) 
        {
            this.Y = y;
            this.X = x;
            this.Type = type;
            this.NeighborCoordinate = GetNeighborCoordinate();
            this.Neighbor = new();
        }
        /*| is a vertical pipe connecting north and south.

        - is a horizontal pipe connecting east and west.

        L is a 90-degree bend connecting north and east.

        J is a 90-degree bend connecting north and west.

        7 is a 90-degree bend connecting south and west.

        F is a 90-degree bend connecting south and east.

        . is ground; there is no pipe in this tile.

        S is the starting position.*/
        public List<List<int>> GetNeighborCoordinate()
        {
            List<List<int>>  transformation = new();

            if (Type == '|')
            {
                transformation.Add(TOP);
                transformation.Add(BOTTOM);              
            }else if (Type == '-')
            {
                transformation.Add(LEFT);
                transformation.Add(RIGHT);
            }else if(Type == 'L')
            {
                transformation.Add(TOP);
                transformation.Add(RIGHT);
            }else if(Type == 'J')
            {
                transformation.Add(TOP);
                transformation.Add(LEFT);
            }else if(Type == '7')
            {
                transformation.Add(LEFT);
                transformation.Add(BOTTOM);
            }else if(Type == 'F')
            {
                transformation.Add(RIGHT);
                transformation.Add(BOTTOM);
            }else if(Type == 'S')
            {
                transformation.Add(LEFT);
                transformation.Add(RIGHT);
                transformation.Add(TOP);
                transformation.Add(BOTTOM);
            }else
            {
                transformation.Add(null);
                transformation.Add(null);
            }

            return transformation;
        }
    }
}
