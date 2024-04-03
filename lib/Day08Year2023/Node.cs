using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Day08Year2023
{
    public class Node
    {
        public string Name { get; set; }
        public List<Node> Links { get; set; } = new List<Node>();
    }
}
