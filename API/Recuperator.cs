
namespace API
{
    public class Recuperator : ISolutionsRecuperator
    {
        public List<Solution> Recuperate()
        {
            return new List<Solution>
            {
                new Solution
                {
                    Year = 2023,
                    Days = new List<Day>
                    {
                        new Day
                        {
                            DayNumber = 1,
                            Bonus = true
                        }
                    }
                }
            };
        }
    }
}
