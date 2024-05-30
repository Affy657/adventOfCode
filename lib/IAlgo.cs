namespace Lib;

public interface IAlgo
{
    string Solve(string[] input, bool isBonus = false);
    YearAndDayAndBonus GetYearAndDayAndBonus();
    
    public class YearAndDayAndBonus
    {
        public int Year { get; set; }
        public int Day { get; set; }
        public bool Bonus { get; set; }
    }
}