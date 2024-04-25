using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Day10Year2023
{
    public class Pipe
    {
        public int Y { get; }
        public int X { get; }
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
        
        public List<List<int>> GetNeighborCoordinate()
        {
            List<List<int>>  transformation = new();
            

            if (Type == PipeType.VERTICAL_PIPE)
            {
                transformation.Add(TOP);
                transformation.Add(BOTTOM);              
            }else if (Type == PipeType.HORIZONTAL_PIPE)
            {
                transformation.Add(LEFT);
                transformation.Add(RIGHT);
            }else if(Type == PipeType.NORTHEAST_PIPE)
            {
                transformation.Add(TOP);
                transformation.Add(RIGHT);
            }else if(Type == PipeType.NORTHWEST_PIPE)
            {
                transformation.Add(TOP);
                transformation.Add(LEFT);
            }else if(Type == PipeType.SOUTHWEST_PIPE)
            {
                transformation.Add(LEFT);
                transformation.Add(BOTTOM);
            }else if(Type == PipeType.SOUTHEAST_PIPE)
            {
                transformation.Add(RIGHT);
                transformation.Add(BOTTOM);
            }else if(Type == PipeType.STARTING_PIPE)
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
