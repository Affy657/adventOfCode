using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Day04Year2023
{
    internal class Card
    {
        public int ReferenceId { get; set; }
        public List<int> WinningNumbers { get; set; }
        public List<int> Numbers { get; set; }

        public Card(int referenceId, List<int> winningNumbers, List<int> numbers)
        {
            ReferenceId = referenceId;
            WinningNumbers = winningNumbers;
            Numbers = numbers;
        }

        public Card(Card card)
        {
            ReferenceId = card.ReferenceId;
            WinningNumbers = new List<int>(card.WinningNumbers);
            Numbers = new List<int>(card.Numbers);
        }
    }
}
