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

        /// <summary>
        /// Return true if this hand is greater than one given
        /// </summary>
        /// <param name="otherHand">The hand we want to compare this one with</param>
        /// <returns>True if greater, false if lower, null if equal</returns>
        public bool? IsGreater(HandModel otherHand)
        {
            string mappedFirstHand = ConvertHand(otherHand.Hand);
            string mappedSecondHand = ConvertHand(Hand);

            List<CardWeight> curentHandCardWeight = ToDictionary(mappedSecondHand);
            List<CardWeight> otherHandCardWeight = ToDictionary(mappedFirstHand);
            for (int i = 0; i < curentHandCardWeight.Count; i++)
            {
                CardWeight elementFirstList = curentHandCardWeight[i];
                CardWeight elementSecondtList = otherHandCardWeight[i];

                bool? eval = elementFirstList.IsGreater(elementSecondtList);
                if (eval.HasValue)
                {
                    return eval.Value;
                }
            }

            string firstHand = SortHand(mappedFirstHand);
            string secondHand = SortHand(mappedSecondHand);

            int comparedHandsResult = firstHand.CompareTo(secondHand);

            return comparedHandsResult == 0 ? null : comparedHandsResult > 0;
        }

        public string SortHand(string hand)
        {
            List<char> charList = hand.ToList();
            charList.Sort();
            //charList.Reverse();
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
