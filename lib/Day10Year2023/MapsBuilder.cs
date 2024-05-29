using Lib.Day05Year2023;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Day10Year2023
{
    public class MapsBuilder
    {
        public List<List<Pipe>> CreateNetwork(string[] input) {

            List<List<Pipe>> maps = MapBuilder(input);
            maps = CreateNetwork(maps);
            return maps;
        }

        public Pipe FindStartPipe(List<List<Pipe>> maps)
        {
            int y = 0;
            int x = 0;
            while (!(maps[y][x].NeighborCoordinate.Count > 2))
            {
                x++;
                if (maps[y].Count == x)
                {
                    x = 0 ; y++;
                }
            }
            return maps[y][x];

        }

        public List<List<Pipe>> CreateNetwork(List<List<Pipe>> maps)
        {
            for (int y = 0; y < maps.Count; y++)
            {
                for (int x = 0; x < maps[y].Count; x++)
                {
                    List<List<int>> neighborCoordinate = maps[y][x].NeighborCoordinate;
                    for (int i = 0; i < neighborCoordinate.Count; i++)
                    {
                        maps = NewNeighbor(neighborCoordinate, maps, y, x, i);
                    }                    
                }
            }

            return maps;
        }
        public List<List<Pipe>> NewNeighbor(List<List<int>> neighborCoordinate, List<List<Pipe>>  maps,int y,int x, int i)
        {
            if (IsValidCoordinate(neighborCoordinate[i], maps, y, x))
            {
                Pipe? Neighbor = maps[y + neighborCoordinate[i][0]][x + neighborCoordinate[i][1]];
                maps[y][x].Neighbor.Add(Neighbor);
            }
            return maps;
        }
        public List<List<Pipe>> MapBuilder(string[] input)
        {
            List<List<Pipe>> maps = new();
            for (int y = 0; y < input.Length; y++)
            {
                List<Pipe> lineMaps = new();
                for (int x = 0; x < input[y].Length; x++)
                {
                    lineMaps.Add(new(y, x, input[y][x]));
                }
                maps.Add(lineMaps);
            }
            return maps;
        }

        public bool IsValidCoordinate(List<int> neighborCoordinate, List<List<Pipe>> maps, int y, int x)
        {
            return neighborCoordinate != null && maps[y][x] != null &&
                   y + neighborCoordinate[0] >= 0 && y + neighborCoordinate[0] < maps.Count &&
                   x + neighborCoordinate[1] >= 0 && x + neighborCoordinate[1] < maps[y + neighborCoordinate[0]].Count;
        }
    }
}
