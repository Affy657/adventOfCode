using FluentAssertions;
using Lib.Day07Year2023;

namespace Test.Algo2023Day07Tests
{
    public class HandCompareTest
    {
        [Fact]
        public void CompareFiveOfAKindToFourOfAKind()
        {
            // Given
            string fiveOfAKind = "AAAAA";
            string fourOfAKind = "AAAA5";
            HandModel testHandModel = new HandModel(fiveOfAKind, 0);
            HandModel testFourHandModel = new HandModel(fourOfAKind, 0);

            // When
            bool? actual = testHandModel.IsGreater(testFourHandModel);

            // Then
            actual.Should().BeTrue();
        }

        
        [Theory]
        [InlineData("AAAAA", "55555")]
        [InlineData("AAAAA", "KKKKK")]
        [InlineData("AAAAA", "QQQQQ")]
        [InlineData("AAAAA", "JJJJJ")]
        [InlineData("KKKKK", "JJJJJ")]
        [InlineData("QQQQQ", "JJJJJ")]
        [InlineData("AAAAA", "TTTTT")]
        [InlineData("AAAAA", "99999")]
        [InlineData("TTTTT", "55555")]
        [InlineData("KKKKK", "TTTTT")]
        [InlineData("QQQQQ", "TTTTT")]
        [InlineData("JJJJJ", "TTTTT")]
        [InlineData("TTTTT", "99999")]
        public void CompareKindToKind(string winningHand, string losingHand)
        {
            // Given
            HandModel winningHandModel = new HandModel(winningHand, 0);
            HandModel losingHandModel = new HandModel(losingHand, 0);

            // When
            bool? actual = winningHandModel.IsGreater(losingHandModel);

            // Then
            actual.Should().BeTrue();
        }

        [Fact]
        public void CompareFourOfAKindToFiveOfAKind()
        {
            // Given
            string fiveOfAKind = "AAAAA";
            string fourOfAKind = "AAAA5";
            HandModel testHandModel = new HandModel(fiveOfAKind, 0);
            HandModel testFourHandModel = new HandModel(fourOfAKind, 0);

            // When
            bool? actual = testFourHandModel.IsGreater(testHandModel);

            // Then
            actual.Should().BeFalse();
        }

        [Theory]
        [InlineData("AAAA5", "AAAAA")]
        [InlineData("AA5AA", "AAAAA")]
        [InlineData("AAQAA", "AAAAA")]
        [InlineData("QQQQA", "TTTTT")]
        [InlineData("6QQQQ", "TTTTT")]
        public void CompareFourOfAKindToFiveOfAKindTheory(string fourOfAKind, string fiveOfAKind)
        {
            // Given
            HandModel winningHand = new HandModel(fiveOfAKind, 0);
            HandModel losingHand = new HandModel(fourOfAKind, 0);

            // When
            bool? actual = losingHand.IsGreater(winningHand);

            // Then
            actual.Should().BeFalse();
        }

        [Theory]
        [InlineData("AA2QQ", "AAAAA")]
        [InlineData("AA2QQ", "55555")]
        [InlineData("33266", "AAAA5")]
        [InlineData("33266", "AAA55")]
        [InlineData("AA2TT", "QA2AQ")]
        public void CompareTwoPairHandwithDifferentOtherUpperHandTheory(string twoPairHand, string upperHand)
        {
            // Given
            HandModel losingHand = new HandModel(twoPairHand, 0);
            HandModel winningHand = new HandModel(upperHand, 0);

            // When
            bool? actual = winningHand.IsGreater(losingHand);

            // Then
            actual.Should().NotBeNull();
            actual.Should().BeTrue();
        }


        [Theory]
        [InlineData("AAAAA", "AAAAA")]
        [InlineData("AAAA5", "AAAA5")]
        [InlineData("AAAA5", "AA5AA")]
        public void CompareTwoEqualsHands(string firstHand, string secondHand)
        {
            // Given
            HandModel firstHandModel = new HandModel(firstHand, 0);
            HandModel secondHandModel = new HandModel(secondHand, 0);

            // When
            bool? actual = firstHandModel.IsGreater(secondHandModel);

            // Then
            actual.Should().BeNull();
        }
    }
}
