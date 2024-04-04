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
        private static bool IsZero(int x) => x == 0;
        public List<int> GetPredicates(List<List<int>> report, bool isBonus)
        {
            List<int> predicats = [];
            foreach (List<int> history in report)
            {
                List<List<int>> offset = BuildOffset([history]);
                List<List<int>> nextValue = NextValue(offset, isBonus);
                predicats.Add(nextValue[0][^1]);
            }

            return predicats;
        }
        public List<List<int>> BuildOffset(List<List<int>> history) 
        {       
            bool zero = history[^1].All(IsZero);

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
        public List<List<int>> NextValue(List<List<int>> offset, bool isBonus) 
        {
            offset[^1].Add(0);           
            int bonus = 1;
            if (isBonus)
            {
                offset = offset.Select(x => x.AsEnumerable().Reverse().ToList()).ToList();
                bonus = -1;
            }          
            for (int i = offset.Count - 2; i >= 0; i--)
            {
                offset[i].Add(offset[i][^1] + offset[i + 1][^1] * bonus);
            }           

            return offset;
        }
    }
}
