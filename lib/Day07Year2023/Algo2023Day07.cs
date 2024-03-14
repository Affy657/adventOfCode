using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Day07Year2023
{
    public class Algo2023Day07 : IAlgo
    {
        public string Solve(string[] input, bool isBonus = false)
        {
            HandsBuilder handsBuilder = new();
            List<HandModel> handModelList = handsBuilder.HandBuilder(input);

            PokerGame pokerGame = new();
            long handBidSum = pokerGame.Game(handModelList);
            pokerGame.WriteSortedHandsToFile(handModelList,"resultDay7.txt");

            return handBidSum.ToString();
        }
        
    }
}
