using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Day07Year2023
{
    public class CardWeight
    {
        public char Card { get; set; }
        public int Weight { get; set; }

        public bool? IsGreater(CardWeight elementSecondtList)
        {
            if (Weight > elementSecondtList.Weight) return true;
            if (Weight < elementSecondtList.Weight) return false;

            char myCard = ConvertHand(Card.ToString())[0];
            char otherCard = ConvertHand(elementSecondtList.Card.ToString())[0];

            return myCard.CompareTo(otherCard) == 0 ? null : myCard.CompareTo(otherCard) < 0;
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
    }
}
