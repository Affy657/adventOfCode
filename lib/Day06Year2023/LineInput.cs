using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Day06Year2023
{
    public class LineInput
    {
        public string Label { get; set; }
        public List<long> Numbers { get; set; }

        public LineInput(string label, List<long> numbers) 
        {
            Label = label;
            Numbers = numbers;
        }

    }
}
