using FluentAssertions;
using Lib.Day07Year2023;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Algo2023Day07Tests
{
    public class HandSortTest
    {
        [Theory]
        [InlineData("AAAAA", "AAAAA")]
        [InlineData("AAQAA", "AAAAQ")]
        public void SortSameCards_ShouldRemainTheSameHand(string inputHand, string expectedHand)
        {
            // Given
            HandModel hand = new HandModel(inputHand, 0);

            // When
            string actual = hand.SortHand(hand.Hand);

            // Then
            string expected = expectedHand;
            actual.Should().Be(expected);
        }



    }
}
