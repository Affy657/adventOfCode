using FluentAssertions;
using Lib.Day07Year2023;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Algo2023Day07Tests
{
    public class CardWeightTest
    {
        [Theory]
        [InlineData(5, 4)]
        [InlineData(5, 3)]
        [InlineData(5, 2)]
        [InlineData(5, 1)]
        [InlineData(2, 1)]
        [InlineData(3, 1)]
        [InlineData(4, 1)]
        public void WhenWeightIsGreaterThanTheOtherPattern_ShouldBeGreater(int weightWinningPattern, int weightLosingPattern)
        {
            // Given
            CardWeight winningPattern = new CardWeight { Card = 'A', Weight = weightWinningPattern };
            CardWeight losingPattern = new CardWeight { Card = 'A', Weight = weightLosingPattern };

            // When
            bool? actual = winningPattern.IsGreater(losingPattern);

            // Then
            actual.Should().NotBeNull();
            actual.Should().BeTrue();
        }

        [Theory]
        [InlineData(5, 4)]
        [InlineData(5, 3)]
        [InlineData(5, 2)]
        [InlineData(5, 1)]
        [InlineData(2, 1)]
        [InlineData(3, 1)]
        [InlineData(4, 1)]
        public void WhenWeightIsLowerThanTheOtherPattern_ShouldBeLower(int weightLosingPattern, int weightWinningPattern)
        {
            // Given
            CardWeight winningPattern = new CardWeight { Card = 'A', Weight = weightWinningPattern };
            CardWeight losingPattern = new CardWeight { Card = 'A', Weight = weightLosingPattern };

            // When
            bool? actual = winningPattern.IsGreater(losingPattern);

            // Then
            actual.Should().NotBeNull();
            actual.Should().BeFalse();
        }


        [Theory]
        [InlineData(5, 5)]
        [InlineData(4, 4)]
        [InlineData(3, 3)]
        [InlineData(2, 2)]
        [InlineData(1, 1)]
        public void WhenWeightIsTheSameThanTheOtherPattern_ShouldBeEqual(int firstPattern, int secondPattern)
        {
            // Given
            CardWeight winningPattern = new CardWeight { Card = 'A', Weight = firstPattern };
            CardWeight losingPattern = new CardWeight { Card = 'A', Weight = secondPattern };

            // When
            bool? actual = winningPattern.IsGreater(losingPattern);

            // Then
            actual.Should().BeNull();
        }


        [Theory]
        [InlineData('A', 'Q')]
        [InlineData('K', 'J')]
        public void WhenWeightIsTheSame_WhenCardIsHigher_ShouldBeGreater(char winningCard, char losingCard)
        {
            // Given
            CardWeight winningPattern = new CardWeight { Card = winningCard, Weight = 5 };
            CardWeight losingPattern = new CardWeight { Card = losingCard, Weight = 5 };

            // When
            bool? actual = winningPattern.IsGreater(losingPattern);

            // Then
            actual.Should().NotBeNull();
            actual.Should().BeTrue();
        }

    }
}
