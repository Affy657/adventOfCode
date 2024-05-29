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
        public List<List<int>> EnclosedNeighbor = [];      
        public List<List<int>> UnfencedNeighbor = [];

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
        public Pipe NextPipe(Pipe oldPipe) 
        {
            foreach(Pipe pipe in Neighbor)
            {
                if(pipe != oldPipe)
                {
                    return pipe;
                }
            }
            return null;
        }
        public int GetEnclosedCorner(Pipe oldPipe)
        {
            Func < char, Pipe, int> EnclosedCornerShifts = (t, p) => t switch
            {               
                PipeType.NORTHEAST_PIPE => p.GetDirectionFromOldToCurrent(X, Y) switch
                {
                    DirectionType.TO_TOP => 1,
                    DirectionType.TO_RIGHT => -1,
                    _ => 0
                },
                PipeType.NORTHWEST_PIPE => p.GetDirectionFromOldToCurrent(X, Y) switch
                {
                    DirectionType.TO_TOP => -1,
                    DirectionType.TO_LEFT => 1,
                    _ => 0
                },
                PipeType.SOUTHWEST_PIPE => p.GetDirectionFromOldToCurrent(X, Y) switch
                {
                    DirectionType.TO_LEFT => -1,
                    DirectionType.TO_BOTTOM => 1,
                    _ => 0
                },
                PipeType.SOUTHEAST_PIPE => p.GetDirectionFromOldToCurrent(X, Y) switch
                {
                    DirectionType.TO_RIGHT => 1,
                    DirectionType.TO_BOTTOM => -1,
                    _ => 0
                },

                _ => 0
            };
            int EnclosedCorner = EnclosedCornerShifts(Type, oldPipe);
            return EnclosedCorner;
            
        }

        public int GetUnfencedCorner(Pipe oldPipe)
        {
            Func<char, Pipe, int> UnfencedCornerShifts = (t, p) => t switch
            {
                PipeType.NORTHEAST_PIPE => p.GetDirectionFromOldToCurrent(X, Y) switch
                {
                    DirectionType.TO_TOP => -1,
                    DirectionType.TO_RIGHT => 1,
                    _ => 0
                },
                PipeType.NORTHWEST_PIPE => p.GetDirectionFromOldToCurrent(X, Y) switch
                {
                    DirectionType.TO_TOP => 1,
                    DirectionType.TO_LEFT => -1,
                    _ => 0
                },
                PipeType.SOUTHWEST_PIPE => p.GetDirectionFromOldToCurrent(X, Y) switch
                {
                    DirectionType.TO_LEFT => 1,
                    DirectionType.TO_BOTTOM => -1,
                    _ => 0
                },
                PipeType.SOUTHEAST_PIPE => p.GetDirectionFromOldToCurrent(X, Y) switch
                {
                    DirectionType.TO_RIGHT => -1,
                    DirectionType.TO_BOTTOM => 1,
                    _ => 0
                },

                _ => 0
            };
            int UnfencedCorner = UnfencedCornerShifts(Type, oldPipe);
            return UnfencedCorner;
        }

        public List<List<int>> EnclosedNeighborShifts(char currentType, Pipe oldPipe) => currentType switch // TODO inverser DirectionType pour tout les angle / on vien de old pipe vere le curent pipe
        {
            PipeType.NORTHEAST_PIPE => oldPipe.GetDirectionFromOldToCurrent(Y, X) switch
            {
                DirectionType.TO_BOTTOM => [],
                DirectionType.TO_LEFT => [BOTTOM, LEFT],
                _ => []
            },
            PipeType.VERTICAL_PIPE => oldPipe.GetDirectionFromOldToCurrent(Y, X) switch
            {
                DirectionType.TO_BOTTOM => [RIGHT],
                DirectionType.TO_TOP => [LEFT],
                _ => []
            },
            PipeType.HORIZONTAL_PIPE => oldPipe.GetDirectionFromOldToCurrent(Y, X) switch
            {
                DirectionType.TO_LEFT => [BOTTOM],
                DirectionType.TO_RIGHT => [TOP],
                _ => []
            },
            PipeType.NORTHWEST_PIPE => oldPipe.GetDirectionFromOldToCurrent(Y, X) switch
            {
                DirectionType.TO_BOTTOM => [RIGHT, BOTTOM],
                DirectionType.TO_RIGHT => [],
                _ => []
            },
            PipeType.SOUTHWEST_PIPE => oldPipe.GetDirectionFromOldToCurrent(Y, X) switch
            {
                DirectionType.TO_RIGHT => [TOP, RIGHT],
                DirectionType.TO_TOP => [],
                _ => []
            },
            PipeType.SOUTHEAST_PIPE => oldPipe.GetDirectionFromOldToCurrent(Y, X) switch
            {
                DirectionType.TO_LEFT => [],
                DirectionType.TO_TOP => [LEFT, TOP],
                _ => []
            },
            PipeType.STARTING_PIPE => oldPipe.GetDirectionFromOldToCurrent(Y, X) switch
            {
                DirectionType.TO_LEFT => [],
                DirectionType.TO_TOP => [],
                _ => []
            },

            _ => []
        };

        public List<List<int>> UnfencedNeighborShifts(char t, Pipe oldPipe) => t switch
        {
            PipeType.VERTICAL_PIPE => oldPipe.GetDirectionFromOldToCurrent(Y, X) switch
            {
                DirectionType.TO_TOP => [LEFT],
                DirectionType.TO_BOTTOM => [RIGHT],
                _ => []
            },
            PipeType.HORIZONTAL_PIPE => oldPipe.GetDirectionFromOldToCurrent(Y, X) switch
            {
                DirectionType.TO_RIGHT => [TOP],
                DirectionType.TO_LEFT => [BOTTOM],
                _ => []
            },
            PipeType.NORTHEAST_PIPE => oldPipe.GetDirectionFromOldToCurrent(Y, X) switch
            {
                DirectionType.TO_TOP => [BOTTOM, LEFT],
                DirectionType.TO_RIGHT => [],
                _ => []
            },
            PipeType.NORTHWEST_PIPE => oldPipe.GetDirectionFromOldToCurrent(Y, X) switch
            {
                DirectionType.TO_TOP => [],
                DirectionType.TO_LEFT => [RIGHT, BOTTOM],
                _ => []
            },
            PipeType.SOUTHWEST_PIPE => oldPipe.GetDirectionFromOldToCurrent(Y, X) switch
            {
                DirectionType.TO_LEFT => [],
                DirectionType.TO_BOTTOM => [TOP, RIGHT],
                _ => []
            },
            PipeType.SOUTHEAST_PIPE => oldPipe.GetDirectionFromOldToCurrent(Y, X) switch
            {
                DirectionType.TO_RIGHT => [LEFT, TOP],
                DirectionType.TO_BOTTOM => [],
                _ => []
            },
            PipeType.STARTING_PIPE => oldPipe.GetDirectionFromOldToCurrent(Y, X) switch
            {
                DirectionType.TO_RIGHT => [],
                DirectionType.TO_BOTTOM => [],
                _ => []
            },

            _ => []
        };

        public void GetEnclosedNeighbor(Pipe oldPipe)
        { 
            EnclosedNeighbor.AddRange(EnclosedNeighborShifts(Type, oldPipe));
            UnfencedNeighbor.AddRange(UnfencedNeighborShifts(Type, oldPipe));     
        }

        public string GetDirectionFromOldToCurrent(int currentY, int currentX)
        {
            if (currentX > X) return DirectionType.TO_RIGHT;
            if (currentY > Y) return DirectionType.TO_BOTTOM;
            if (currentX < X) return DirectionType.TO_LEFT;
            if (currentY < Y) return DirectionType.TO_TOP;
            return "";
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
            }

            return transformation;
        }
    }
}
