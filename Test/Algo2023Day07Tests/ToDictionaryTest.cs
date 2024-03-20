using FluentAssertions;
using Lib.Day07Year2023;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Algo2023Day07Tests
{
    public class ToDictionaryTest
    {
        [Theory]
        [InlineData("AAAAA")]
        [InlineData("QQQQQ")]
        [InlineData("QQQKK")]
        [InlineData("AQQKK")]
        public void GivenHandsWithPatterns_ShouldReturnPatterSortedByWeight(string inputHand)
        {
            // Given
            HandModel firstHand = new HandModel(inputHand, 0);

            // When
            List<CardWeight> patterns = firstHand.ToDictionary(firstHand.Hand);

            // Then
            patterns.Select(p => p.Weight).Should().BeInDescendingOrder();
        }

        [Theory]
        [InlineData("BBEAA")]
        [InlineData("GCCDD")]
        public void GivenHandsWithSamePatterns_ShouldReturnPatterSortedByWeight(string inputHand)
        {
            // Given
            HandModel firstHand = new HandModel(inputHand, 0);

            // When
            List<CardWeight> patterns = firstHand.ToDictionary(firstHand.Hand);

            // Then
            patterns.Select(p => p.Card).Should().BeInAscendingOrder();
        }
    }
}
