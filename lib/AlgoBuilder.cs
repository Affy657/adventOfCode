using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        return null;
    }
}
