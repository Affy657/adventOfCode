using FluentAssertions;
using Lib.Day05Year2023;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Test.Algo2023Day05Tests
{
    public class MapsBuilderTests
    {
        [Fact]
        public void WhenInputContainsCategories_ThenCategoryListShouldNotBeEmpty()
        {
            // Given
            string[] input = ["seed-to-soil map:", "soil-to-fert map:"];
            MapsBuilder mapsBuilder = new MapsBuilder(input);

            // When
            mapsBuilder.Build();

            // Then
            mapsBuilder.CategoryList.Should().NotBeEmpty();
        }

        [Fact]
        public void WhenInputContainsCategoriesButNoMaps_ThenMapsShouldBeEmpty()
        {
            // Given
            string[] input = ["seed-to-soil map:", "soil-to-fert map:"];
            MapsBuilder mapsBuilder = new MapsBuilder(input);

            // When
            mapsBuilder.Build();

            // Then
            foreach (var item in mapsBuilder.CategoryList)
            {
                item.Map.Should().BeEmpty();
            }
        }


        [Fact]
        public void WhenInputContainsCategoriesButNoMaps_ThenMapsShouldNotBeEmpty()
        {
            // Given
            string[] input = ["seed-to-soil map:", "soil-to-fert map:"];
            MapsBuilder mapsBuilder = new MapsBuilder(input);

            // When
            mapsBuilder.Build();

            // Then
            foreach (var item in mapsBuilder.CategoryList)
            {
                item.Map.Should().BeEmpty();
            }
        }

        [Fact]
        public void WhenInputContainsCategoriesAndMaps_ThenMapsShouldNotBeEmpty()
        {
            // Given
            string[] input = ["seed-to-soil map:", "1 2 3"];
            MapsBuilder mapsBuilder = new MapsBuilder(input);

            // When
            mapsBuilder.Build();

            // Then
            foreach (var item in mapsBuilder.CategoryList)
            {
                item.Map.Should().NotBeEmpty();
            }
        }

        [Fact]
        public void WhenInputContainsCategoriesAndMaps_ThenMapsShouldContainsAllValues()
        {
            // Given
            string[] input = ["seed-to-soil map:", "1 2 3"];
            MapsBuilder mapsBuilder = new MapsBuilder(input);

            // When
            mapsBuilder.Build();

            // Then
            Map expectedMap = new Map(new List<long>([1,2,3]));
            Map actualMap = mapsBuilder
                .CategoryList.First()
                .Map.First();

            actualMap.Range.Should().Be(expectedMap.Range);
            actualMap.StartMap.Should().Be(expectedMap.StartMap);
            actualMap.StartSeed.Should().Be(expectedMap.StartSeed);
        }

        [Theory]
        [InlineData("seed-to-soil map:", "seed-to-soil map:")]
        [InlineData("a-to-b map:", "a-to-b map:")]
        [InlineData("12 12 45 5", "")]
        public void WhenPatterMatch_ShouldGroupValue(string input, string expectedOutput)
        {
            // Given

            // When
            Match expected = Regex.Match(input, MapsBuilder.PatternCat);

            // Then
            expected.Groups[0].ToString().Should().Be(expectedOutput);
        }
    }
}
