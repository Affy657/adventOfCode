using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Day09Year2023
{
    public class Predictor
    {
        public List<int> GetPredicates(List<List<int>> report)
        {
            List<int> predicats = [];
            foreach (List<int> history in report)
            {
                List<List<int>> offset = BuildOffset([history]);
                List<List<int>> nextValue = NextValue(offset);
                predicats.Add(nextValue[0][^1]);
            }

            return predicats;
        }
        public List<List<int>> BuildOffset(List<List<int>> history) 
        {       
            bool zero = history[^1].All(x => x == 0);

            if (!zero) {

                List<int> list = [];

                for(int i = 0; i < history[^1].Count - 1 ; i++)
                {
                    list.Add(history[^1][i+1] - history[^1][i]);
                }

                history.Add(list);
                history = BuildOffset(history);
            }   
            
            return history;         
        }
        public List<List<int>> NextValue(List<List<int>> offset) 
        {
            offset[^1].Add(0);
            for(int i = offset.Count - 2 ; i >= 0 ; i--)
            {
                offset[i].Add(offset[i][^1]+ offset[i+1][^1]);
            }
            return offset;
        }
    }
}
