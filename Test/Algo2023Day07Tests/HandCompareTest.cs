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

        [Theory]
        [InlineData("AAAAA", "QQQQQ")]
        [InlineData("AAAAA", "AAAA5")]
        [InlineData("AAAA5", "AAA55")]
        [InlineData("AAA55", "AAA25")]
        [InlineData("AAAKK", "AAAQQ")]
        [InlineData("QQQKK", "QQQJJ")]
        [InlineData("AAA25", "AA255")]
        [InlineData("AA255", "AA235")]
        [InlineData("AA235", "A2345")]
        [InlineData("A2345", "72345")]
        [InlineData("88996", "88995")]
        [InlineData("AAKKK", "26AAA")]

        [InlineData("22225", "AAAKK")]
        [InlineData("22233", "AAAKQ")]
        [InlineData("22234", "AAKKQ")]
        [InlineData("22334", "AAKQJ")]
        [InlineData("22345", "AKQJT")]

        [InlineData("22246", "22245")]
        [InlineData("22337", "22336")]
        [InlineData("22225", "22224")]
        [InlineData("22346", "22345")]

        public void GivenAnUpperHandAndALowerOne_WhenCompareFirstWithSecond_ThenFirtShouldBeGreater(string firstHand, string secondHand)
        {
            // Given
            HandModel firstHandModel = new HandModel(firstHand, 0);
            HandModel secondHandModel = new HandModel(secondHand, 0);

            // When
            bool? actual = firstHandModel.IsGreater(secondHandModel);

            // Then
            actual.Should().BeTrue();
        }

        [Theory]

        [InlineData("AAJQQ", "KKQQ4")]
        [InlineData("AAAAJ", "JAAAA")]
        [InlineData("8JJJJ", "JJJJ8")]
        [InlineData("AJJQQ", "JJAQQ")]

        public void GivenIsBonusAnUpperHandAndALowerOne_WhenCompareFirstWithSecond_ThenFirtShouldBeGreater(string firstHand, string secondHand)
        {
            // Given
            HandModel firstHandModel = new HandModel(firstHand, 0);
            HandModel secondHandModel = new HandModel(secondHand, 0);

            // When
            bool? actual = firstHandModel.IsGreater(secondHandModel,true);

            // Then
            actual.Should().BeTrue();
        }

        [Theory]
        [InlineData("55554", "2222A")]
        [InlineData("73333", "44447")]
        [InlineData("85566", "2AAQQ")]
        [InlineData("AQQQQ", "2AAAA")]
        [InlineData("KKKKT", "JKKKK")] 
        
        public void GivenAnUpperHandAndALowerOneOnSecondRule_WhenCompareFirstWithSecond_ThenFirtShouldBeGreater(string firstHand, string secondHand)
        {
            // Given          
            HandModel handModel = new(firstHand, 0);
            string mappedFirstHand = handModel.ConvertHand(firstHand);
            string mappedSecondHand = handModel.ConvertHand(secondHand);

            // When
            bool? actual = handModel.ComparHand(mappedFirstHand, mappedSecondHand);

            // Then
            actual.Should().BeTrue();
        }

        [Theory]
        [InlineData("2222A", "55554")]
        [InlineData("44447", "73333")]
        [InlineData("2AAQQ", "85566")]
        [InlineData("2AAAA", "AQQQQ")]
        [InlineData("56789", "98765")]
        public void GivenAnUpperHandAndALowerOneOnSecondRule_WhenCompareFirstWithSecond_ThenFirtShouldBeNotGreater(string firstHand, string secondHand)
        {
            // Given          
            HandModel handModel = new(firstHand, 0);
            string mappedFirstHand = handModel.ConvertHand(firstHand);
            string mappedSecondHand = handModel.ConvertHand(secondHand);

            // When
            bool? actual = handModel.ComparHand(mappedFirstHand, mappedSecondHand);

            // Then
            actual.Should().BeFalse();
        }

        [Theory]
        [InlineData("2222A", "2222A")]
        [InlineData("44447", "44447")]
        [InlineData("2AAQQ", "2AAQQ")]
        [InlineData("2AAAA", "2AAAA")]
        [InlineData("56789", "56789")]
        public void GivenAnUpperHandAndALowerOneOnSecondRule_WhenCompareFirstWithSecond_ShouldBeEqual(string firstHand, string secondHand)
        {
            // Given          
            HandModel handModel = new(firstHand, 0);
            string mappedFirstHand = handModel.ConvertHand(firstHand);
            string mappedSecondHand = handModel.ConvertHand(secondHand);

            // When
            bool? actual = handModel.ComparHand(mappedFirstHand, mappedSecondHand);

            // Then
            actual.Should().BeNull();
        }
    }
}
