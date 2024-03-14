using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Day07Year2023
{
    public class HandModel
    {
        public string Hand { get; set; }
        public int Bid { get; set; }

        public HandModel(string hand, int bid)
        {
            Hand = hand;
            Bid = bid;
        }
        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            return obj is HandModel objHand && objHand.Hand == Hand && objHand.Bid == Bid;
        }

        public override string ToString()
        {
            return $"{Hand}, {Bid}";
        }

        /// <summary>
        /// Return true if this hand is greater than one given
        /// </summary>
        /// <param name="otherHand">The hand we want to compare this one with</param>
        /// <returns>True if greater, false if lower, null if equal</returns>
        public bool? IsGreater(HandModel otherHand)
        {
            string mappedFirstHand = ConvertHand(Hand);
            string mappedSecondHand = ConvertHand(otherHand.Hand);

            List<CardWeight> currentHandCardWeight = ToDictionary(mappedFirstHand);
            List<CardWeight> otherHandCardWeight = ToDictionary(mappedSecondHand);
            /* 
             * 5
             * 4-1
             * 3-2
             * 3-1-1
             * 2-2-1
             * 2-1-1-1
             * 1-1-1-1-1
             */
            if(currentHandCardWeight.Count< otherHandCardWeight.Count)
            {
                return true;
            }
            if (currentHandCardWeight.Count > otherHandCardWeight.Count)
            {
                return false;
            }

            for (int i = 0; i < currentHandCardWeight.Count; i++)
            {
                CardWeight elementFirstList = currentHandCardWeight[i];
                CardWeight elementSecondtList = otherHandCardWeight[i];

                bool? eval = elementFirstList.IsGreater(elementSecondtList);

                if (eval.HasValue)
                {
                    return eval.Value;
                }
            }
            return ComparHand(mappedFirstHand, mappedSecondHand);
            
        }
        public bool? ComparHand(string firstHand, string secondHand)
        {
            int comparedHandsResult = firstHand.CompareTo(secondHand);
            return comparedHandsResult == 0 ? null : comparedHandsResult < 0;
        }

        public string SortHand(string hand)
        {
            List<char> charList = hand.ToList();
            charList.Sort();
            StringBuilder stringBuilder = new StringBuilder();
            foreach (char c in charList)
            {
                stringBuilder.Append(c);
            }
            return stringBuilder.ToString();
        }

        public string ConvertHand(string hand)
        {
            Dictionary<string, string> convertedChar = new Dictionary<string, string>
            {
                ["K"] = "B",
                ["Q"] = "C",
                ["J"] = "D",
                ["T"] = "E",
                ["9"] = "F",
                ["8"] = "G",
                ["7"] = "H",
                ["6"] = "I",
                ["5"] = "L",
                ["4"] = "M",
                ["3"] = "N",
                ["2"] = "O"
            };
            foreach (KeyValuePair<string, string> c in convertedChar)
            {
                hand = hand.Replace(c.Key, c.Value);
            }
            return hand;
        }

        public List<CardWeight> ToDictionary(string curentHand)
        {
            List<CardWeight> cardWeight = curentHand
                .GroupBy(c => c)
                .Select(g => new CardWeight { Card = g.Key, Weight = g.Count() })
                .OrderByDescending(c => c.Weight).ThenBy(c => c.Card)
                .ToList();

            return cardWeight;
        }
    }
}
