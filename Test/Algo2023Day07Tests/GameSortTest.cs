using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Lib.Day07Year2023;

namespace Test.Algo2023Day07Tests
{
    public class GameSortTest
    {
        [Fact] 
        public void WhenGameSortIsEmpty_ShouldBeEmpty()
        {
            // Given
            PokerGame pokerGame = new();
            List<HandModel> input = new();

            // When
            List<HandModel> actual = pokerGame.GameSort(input);

            // Then
            actual.Should().BeEmpty();
        }

        [Fact]
        public void WhenGameSortHandList_ShouldBeCorectOrder()
        {
            // Given
            PokerGame pokerGame = new();
            List<HandModel> input = new List<HandModel>
            {
                new("22222", 1),
                new("32T3K", 3),
                new("22222", 2)
            };

            // When
            List<HandModel> actual = pokerGame.GameSort(input);

            // Then
            actual.Should().BeEquivalentTo(new List<HandModel>
            {
                new("32T3K", 3),
                new("22222", 1),
                new("22222", 2)
              });
        }
        public static readonly TheoryData<List<HandModel>, List<HandModel>> WhenGameSortHandLists_ShouldBeCorectOrder_data
            = new TheoryData<List<HandModel>, List<HandModel>>()
        {
                {
                    [new("A2345", 1), new("AA235", 1), new("AA255", 1), new("AAA25", 1), new("AAA55", 1), new("AAAA5", 1), new("AAAAA", 1)],
                    [new("AAAA5", 1), new("AA255", 1), new("AAA25", 1), new("AAA55", 1), new("A2345", 1), new("AA235", 1), new("AAAAA", 1)]
                },
                {
                    [new("AAAAA", 1), new("AAAA5", 1), new("AAA55", 1), new("AAA25", 1), new("AA255", 1), new("AA235", 1), new("A2345", 1)],
                    [new("AAAAA", 1), new("AAAA5", 1), new("AAA55", 1), new("AAA25", 1), new("AA255", 1), new("AA235", 1), new("A2345", 1)]
                }
        };
        [Theory]
        [MemberData(nameof(WhenGameSortHandLists_ShouldBeCorectOrder_data))]

        //[InlineData("AAAAA", "QQQQQ")]
        //[InlineData("AAAAA", "AAAA5")]
        //[InlineData("AAAA5", "AAA55")]
        //[InlineData("AAA55", "AAA25")]
        //[InlineData("AAA25", "AA255")]
        //[InlineData("AA255", "AA235")]
        //[InlineData("AA235", "A2345")]
        //[InlineData("A2345", "72345")]
        public void WhenGameSortHandLists_ShouldBeCorectOrder(List<HandModel> input, List<HandModel> expected)
        {
            // Given
            PokerGame pokerGame = new();
            

            // When
            List<HandModel> actual = pokerGame.GameSort(input);

            // Then
            actual.Should().BeEquivalentTo(expected);
        }
    }
}
