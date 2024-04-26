using FluentAssertions;
using Lib.Day05Year2023;
using Lib.Day10Year2023;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Algo2023Day10Tests
{
    public class IsValidCoordinateTest
    {
        [Fact]
        public void IsValidCoordinateShouldBeTrue()
        {
            Lib.Day10Year2023.MapsBuilder mapsBuilder = new();
            string[] input = ["..F7.",
                              ".FJ|.",
                              "SJ.L7",
                              "|F--J",
                              "LJ..."];
            int y = 1;
            int x = 1;
            List<int> neighborCoordinate = [0, 1];
            List<List<Pipe>> maps = mapsBuilder.MapBuilder(input);

            bool actual = mapsBuilder.IsValidCoordinate(neighborCoordinate, maps, y, x);

            actual.Should().BeTrue();
        }
    }
}
