using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Lib.IAlgo;

namespace Lib.Day07Year2023
{
    public class Algo2023Day07 : IAlgo
    {
        public YearAndDayAndBonus GetYearAndDayAndBonus() => new() { Year = 2023, Day = 7, Bonus = true };
        public string Solve(string[] input, bool isBonus = false)
        {
            HandsBuilder handsBuilder = new();
            List<HandModel> handModelList = handsBuilder.HandBuilder(input);

            PokerGame pokerGame = new();
            long handBidSum = pokerGame.Game(handModelList, isBonus);

            return handBidSum.ToString();
        }
        
    }
}
