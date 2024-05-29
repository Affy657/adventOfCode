using FluentAssertions;
using Lib.Day10Year2023;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Algo2023Day10Tests
{
    public class MapsBuilderTests
    {
        public List<List<Pipe>> ReferenceMap => new()
            {
                {
                    new List<Pipe>
                    {
                        new(0, 0, PipeType.SOUTHEAST_PIPE),
                        new(1, 0, PipeType.HORIZONTAL_PIPE),
                        new(2, 0, PipeType.NORTHWEST_PIPE)
                    }
                },
                {

                    new List<Pipe>
                    {
                        new(0, 1, PipeType.NORTHEAST_PIPE),
                        new(1, 1, PipeType.STARTING_PIPE),
                        new(2, 1, PipeType.VERTICAL_PIPE)
                    }
                },
                {

                    new List<Pipe>
                    {
                        new(0, 2, PipeType.GROUND),
                        new(1, 2, PipeType.NORTHEAST_PIPE),
                        new(2, 2, PipeType.NORTHWEST_PIPE)
                    }
                }
            };

        [Fact]
        public void StartPointDoExists()
        {
            // Given (étant donné: )
            MapsBuilder builder = new MapsBuilder();

            // When (quand: )
            Pipe start = builder.FindStartPipe(ReferenceMap);

            // Then (alors: )
            start.Should().NotBeNull();
        }

        [Fact]
        public void StartPipeHasCorrectPipeType()
        {
            // Given (étant donné: )
            MapsBuilder builder = new MapsBuilder();
            
            // When (quand: )
            Pipe start = builder.FindStartPipe(ReferenceMap);

            // Then (alors: )
            start.Type.Should().Be(PipeType.STARTING_PIPE);
        }

    }
}
