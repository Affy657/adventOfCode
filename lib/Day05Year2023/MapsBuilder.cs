using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace lib.Day05Year2023
{
    public class MapsBuilder
    {
        public List<Category> CategoryList {  get; set; }

        public const string PatternMap = @"(\d+)\s+(\d+)\s+(\d+)";
        public const string PatternCat = @"^(.*?)-to-(.*?) map:";
        private readonly string[] input;

        public MapsBuilder(string[] input) 
        {
            this.input = input;
            this.CategoryList = new List<Category>();
        }

        public void Build()
        {
            List<Map> newMaps = null;
            foreach (var line in input)
            {
                Match matchMap = Regex.Match(line, PatternMap);
                Match matchCat = Regex.Match(line, PatternCat);
                if(matchCat.Success)
                {
                    newMaps = new List<Map>();
                    Category newCat = new Category(newMaps, matchCat.Groups[0].Value);
                    CategoryList.Add(newCat);
                }

                if(matchMap.Success)
                {
                    List<long> numbers = new List<long>();
                    for (int i = 1; i <= 3; i++)
                    {
                        numbers.Add(long.Parse(matchMap.Groups[i].Value));
                    }
                    newMaps?.Add(new Map(numbers));
                }
            }
        }
    }
}
