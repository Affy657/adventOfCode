using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Day07Year2023
{
    public class HandsBuilder
    {

        public List<HandModel> HandBuilder(string[] input)
        {
            if(input == null || input.Length == 0)
            {
                throw new ArgumentException(nameof(input));
            }

            List<HandModel> handModelList;
            handModelList = new List<HandModel>();

            foreach (string line in input)
            {
                string hand = line.Split(' ')[0];
                int bid = int.Parse(line.Split(' ')[1]);
                handModelList.Add(new HandModel(hand, bid));
            }

            return handModelList;
        }
    }
}
