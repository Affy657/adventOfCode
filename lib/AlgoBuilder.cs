using Lib.Day04Year2023;
using Lib.Day05Year2023;
using Lib.Day06Year2023;
using Lib.Day07Year2023;
using Lib.Day08Year2023;
using Lib.Day09Year2023;
using Lib.Day10Year2023;

namespace Lib;

public class AlgoBuilder
{
    public int Year { get; set; }
    public int Day { get; set; }
    public bool Bonus { get; set; }
    public AlgoBuilder(int year, int day, bool bonus)
    {
        this.Year = year;
        this.Day = day;
        Bonus = bonus;
    }

    public IAlgo Build()
    {
        List<IAlgo> algos = new()
        {
            new Algo2023Day01(),
            new Algo2023Day02(),
            new Algo2023Day03(),
            new Algo2023Day04(),
            new Algo2023Day05(),
            new Algo2023Day06(),
            new Algo2023Day07(),
            new Algo2023Day08(),
            new Algo2023Day09(),
            new Algo2023Day10()
        };
        return algos.FirstOrDefault(algo => 
        algo.GetYearAndDayAndBonus().Year == this.Year &&
        algo.GetYearAndDayAndBonus().Day == this.Day
        );
        
    } 
}
