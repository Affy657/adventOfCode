using FluentAssertions;
using Lib.Day10Year2023;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Algo2023Day10Tests
{
    public class GetEnclosedNeighborTest
    {
        [Fact]
        public void DirectionShouldBeTO_TOP()
        {
            Pipe pipe = new Pipe(1, 0, PipeType.SOUTHEAST_PIPE);
            string actual = pipe.GetDirectionFromOldToCurrent(0, 0);

            actual.Should().Be("TO_TOP");
        }
        [Fact]
        public void DirectionShouldBeTO_BOTTOM()
        {
            Pipe pipe = new Pipe(0, 0, PipeType.SOUTHEAST_PIPE);
            string actual = pipe.GetDirectionFromOldToCurrent(1, 0);

            actual.Should().Be("TO_BOTTOM");
        }
        [Fact]
        public void DirectionShouldBeTO_RIGHT()
        {
            Pipe pipe = new Pipe(0, 0, PipeType.SOUTHEAST_PIPE);
            string actual = pipe.GetDirectionFromOldToCurrent(0, 1);

            actual.Should().Be("TO_RIGHT");
        }
        [Fact]
        public void DirectionShouldBeTO_LEFT()
        {
            Pipe pipe = new Pipe(0, 1, PipeType.SOUTHEAST_PIPE);
            string actual = pipe.GetDirectionFromOldToCurrent(0, 0);

            actual.Should().Be("TO_LEFT");
        }

        //EnclosedNeighborShifts

        [Fact]

        public void EnclosedNeighborShiftsShouldBeRIGHT()
        {
            Pipe pipe = new Pipe(0, 0, PipeType.HORIZONTAL_PIPE);
            Pipe nextPipe = new Pipe(1, 0, PipeType.VERTICAL_PIPE);
            List<List<int>> actual = pipe.EnclosedNeighborShifts(PipeType.VERTICAL_PIPE, nextPipe);

            actual.Should().Equal(Pipe.LEFT);

        }
        [Fact]
        public void EnclosedNeighborShiftsShouldBeBOTTOMAndLEFT()
        {
            Pipe currentPipe = new Pipe(1, 0, PipeType.NORTHEAST_PIPE);
            Pipe oldPipe = new Pipe(0, 0, PipeType.SOUTHEAST_PIPE);
            List<List<int>> actual = currentPipe.EnclosedNeighborShifts(currentPipe.Type, oldPipe);

            actual.Should().Equal([Pipe.LEFT, Pipe.TOP]);
        }





    }
}
