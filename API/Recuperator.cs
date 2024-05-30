
using Lib;
using System.Collections.Generic;

namespace API
{
    public class Recuperator : ISolutionsRecuperator
    {
        public List<Solution> Recuperate()
        {
            List<Solution> result = new();

            List<IAlgo> algos = GetIAlgos();
            foreach (IAlgo algo in algos)
            {
                if (algo != null)
                {
                    result.Add(new Solution
                    {
                        Year = algo.GetYearAndDayAndBonus().Year,
                        Days = new List<Day>
                    {
                        new Day
                        {
                            DayNumber = algo.GetYearAndDayAndBonus().Day,
                            Bonus = algo.GetYearAndDayAndBonus().Bonus
                        }
                    }
                    });
                }
            }        
             return result;
        }
        public List<IAlgo> GetIAlgos()
        {
            List<IAlgo> algos = new();
            for (int i = 1; i <= 25; i++)
            {
                algos.Add(new AlgoBuilder(2023, i, true).Build());
                
            }
            return algos;
        }
    }
}
