using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Lib.Day07Year2023
{
    public class PokerGame
    {
        public long Game(List<HandModel> handModelList) 
        {
            return GameBidCalcul(GameSort(handModelList));
            
        }
        public List<HandModel> GameSort(List<HandModel> handModelList)
        { 
            handModelList.Sort((HandModel x, HandModel y) => NullableBooleanToInt(x.IsGreater(y))); 
            return handModelList;
        }
        public static int NullableBooleanToInt(bool? nullableBoolean)
        {
            if (!nullableBoolean.HasValue)
            {
                return 0;
            }

            return nullableBoolean.Value ? 1 : -1;
        }
        public long GameBidCalcul(List<HandModel> handModelSortedList)
        {
            BidCalcul bidCalcul = new();
            long handBidSum = bidCalcul.BidCompute(handModelSortedList);
            return handBidSum;
        }
        public void WriteSortedHandsToFile(List<HandModel> handModelList, string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (HandModel hand in handModelList)
                {        
                    writer.WriteLine(hand.SortHand(hand.Hand));
                }
            }
        }
    }
}
