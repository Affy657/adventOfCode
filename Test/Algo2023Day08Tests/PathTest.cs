using FluentAssertions;
using Lib.Day08Year2023;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Algo2023Day08Tests
{
    public class PathTest
    {
        [Fact]
        public void GivenRightAndLeftInput_ShouldBeCorectValue()
        {
            // Given
            Lib.Day08Year2023.Path path = new();

            // When
            List<Direction> actual = path.getPaths("LR");
            
            // Then
            actual.Should().NotBeEmpty();
            actual.Count().Should().Be(2);
            actual[0].Left.Should().BeTrue();
            actual[0].Right.Should().BeFalse();
            actual[1].Left.Should().BeFalse();
            actual[1].Right.Should().BeTrue();

        }
    }
}
