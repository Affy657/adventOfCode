using Lib.Day04Year2023;
using Lib.Day05Year2023;
using Lib.Day06Year2023;
using Lib.Day07Year2023;

namespace Lib;

public class AlgoBuilder
{
    public int Year { get; set; }
    public int Day { get; set; }
    public AlgoBuilder(int year, int day)
    {
        this.Year = year;
        this.Day = day;
    }

    public IAlgo Build()
    {
        if(this.Year == 2023 && this.Day == 1){
            return new Algo2023Day01();
        }
        else if(this.Year == 2023 && this.Day == 2){
            return new Algo2023Day02();
        }
        else if (this.Year == 2023 && this.Day == 3)
        {
            return new Algo2023Day03();
        }
        else if (this.Year == 2023 && this.Day == 4)
        {
            return new Algo2023Day04();
        }
        else if (this.Year == 2023 && this.Day == 5)
        {
            return new Algo2023Day05();
        }
        else if (this.Year == 2023 && this.Day == 6)
        {
            return new Algo2023Day06();
        }
        else if (this.Year == 2023 && this.Day == 7)
        {
            return new Algo2023Day07();
        }

        return new Algo2023Day01();
    }
}
