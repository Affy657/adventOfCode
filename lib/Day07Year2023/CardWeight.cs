﻿using System;
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

            return null;
        }
    }
}
