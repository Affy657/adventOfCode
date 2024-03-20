using FluentAssertions;
using Lib.Day05Year2023;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Algo2023Day05Tests
{
    public class SeedsTests
    {
        [Fact]
        public void WhenCreateWithEmptyValue_ShouldThrowException()
        {
            // Given
            string[] input = null;

            // When
            Action act = () => new SeedsBuilder(input);

            // Then
            act.Should()
                .Throw<ArgumentNullException>()
                .WithMessage("Value cannot be null. (Parameter 'input')");
        }

        [Fact]
        public void WhenCreateWithWrongFormat_ShouldBeEmpty()
        {
            // Given
            string[] input = ["seeds: "];
            SeedsBuilder builder = new SeedsBuilder(input);

            // When
            builder.Build();

            // Then
            List<long> expected = [];
            builder.Should().NotBeNull();
            builder.Seeds.Should().BeEquivalentTo(expected);
        }


        [Fact]
        public void WhenCreateWithRightFormat_ShouldReturnsAllNumbers()
        {
            // Given
            string[] input = ["seeds: 123456 95674 0 12"];
            SeedsBuilder builder = new SeedsBuilder(input);

            // When
            builder.Build();

            // Then
            List<long> expected = [123456, 95674, 0, 12];
            builder.Should().NotBeNull();
            builder.Seeds.Should().BeEquivalentTo(expected);
        }

    }
}
