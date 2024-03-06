using FluentAssertions;
using Lib.Day07Year2023;

namespace Test.Algo2023Day07Tests
{
    public class HandBuilderTest
    {

        [Fact]
        public void WhenBuild_WithEmpty_ThenThrowException()
        {
            // Given
            HandsBuilder builder = new HandsBuilder();
            string[] input = { };
            bool catched = false;

            // When
            try
            {
                List<HandModel> actual = builder.HandBuilder(input);
            }
            catch (ArgumentException)
            {
                catched = true;
            }

            // Then
            catched.Should().BeTrue();
        }

        [Fact]
        public void WhenBuild_WithNull_ThenThrowException()
        {
            // Given
            HandsBuilder builder = new HandsBuilder();
            string[] input = null;
            bool catched = false;

            // When
            try
            {
                List<HandModel> actual = builder.HandBuilder(input);
            }
            catch (ArgumentException)
            {
                catched = true;
            }

            // Then
            catched.Should().BeTrue();
        }


        [Theory]
        [InlineData("A234Q 34")]
        [InlineData("A234Q 347")]
        [InlineData("A234Q 3")]
        [InlineData("AAAAA 34")]
        public void WhenBuild_WithOneLineInGoodFormat_ThenReturnOneHandModel(string line)
        {
            // Given
            HandsBuilder builder = new HandsBuilder();
            string[] input = [line];

            // When
            List<HandModel> actual = builder.HandBuilder(input);

            // Then
            actual[0].Hand.Should().BeEquivalentTo(line.Split(" ")[0]);
            actual[0].Bid.Should().Be(int.Parse(line.Split(" ")[1]));
        }

        [Fact]
        public void WhenBuild_WithmultiLineInGoodFormat_ThenReturnOneHandModel()
        {
            // Given
            HandsBuilder builder = new HandsBuilder();
            string[] input = ["A234Q 34","A234Q 34","A234Q 34"];

            // When
            List<HandModel> actual = builder.HandBuilder(input);

            // Then
            actual[0].Hand.Should().BeEquivalentTo("A234Q");
            actual[0].Bid.Should().Be(34);
            actual[1].Hand.Should().BeEquivalentTo("A234Q");
            actual[1].Bid.Should().Be(34);
            actual[2].Hand.Should().BeEquivalentTo("A234Q");
            actual[2].Bid.Should().Be(34);
        }
    }
}
