using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Day07Year2023
{
    public class BidCalcul
    {
        public long BidCompute(List<HandModel> handModelSortedList) 
        {
            return BidSum(BidRankCompute(handModelSortedList));
        }
        public List<long> BidRankCompute ( List<HandModel> handModelSortedList) 
        {
            List<long> handBid = [];

            for (int i = 0; i < handModelSortedList.Count; i++)
            {
                handBid.Add(handModelSortedList[i].Bid * (i + 1));
            }

            return handBid;
            //return handModelSortedList.Select((handModel, index) => handModel.Bid * (index + 1)).ToList();
        }
        public long BidSum (List<long> handBid) 
        {
            return handBid.Sum();
        }
    }
}
