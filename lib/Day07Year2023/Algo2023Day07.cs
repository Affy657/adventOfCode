using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Day07Year2023
{
    public class Algo2023Day07 : IAlgo
    {
        public int Getday()
        {
            return 7;
        }
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
