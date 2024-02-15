using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Day06Year2023
{
    public class SpaceRemove : ISpaceRemove
    {
        public string OldChar { get; set; }  = " ";
        public string NewChar { get; set; } = "";
        
        public SpaceRemove() { }

        public string SpaceRemover(string line) 
        {
            return line.Replace(OldChar, NewChar);
        }
    }
}
