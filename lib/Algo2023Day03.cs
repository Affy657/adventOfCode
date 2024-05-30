using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static Lib.IAlgo;

namespace Lib
{
    internal class Algo2023Day03 : IAlgo
    {
        public YearAndDayAndBonus GetYearAndDayAndBonus() => new() { Year = 2023, Day = 3, Bonus = true };

        public string Solve(string[] input, bool isBonus = false)
        {
            char notASymbole = '.';
            int result = 0;
            char symboleTarget = '*';

            for (int j = 0; j < input.Length; j++)
            {
                for (int i = 0; i < input[j].Length; i++)
                {                  
                    if (isBonus)
                    {
                        if (input[j][i] == symboleTarget)
                        {
                            result += getGearRatio(input, j, i);
                        }
                    }
                    else
                    {
                        if (int.TryParse(input[j][i].ToString(), out int v1))
                        {
                            string num = getNum(input[j],i);
                            result += numIsValid(input, j, i, num);
                            i += num.Length;
                        }
                    }
                }
            }
            int getGearRatio(string[] input,int j,int i)
            {
                List<int> numberList = new List<int>();
                for (int line = 0; line < 3; line++)
                {
                    for (int column = 0; column < 3; column++)
                    {
                        int lineCursor = j + line - 1;
                        int columnCursor = i + column - 1;
                        if (lineCursor >= 0 && lineCursor < input.Length && columnCursor >= 0 && columnCursor < input[lineCursor].Length)
                        {
                            char currentLocation = input[lineCursor][columnCursor];
                            if (int.TryParse(currentLocation.ToString(), out int ignored))
                            {
                                int number = getNumber(input[lineCursor], columnCursor);
                                if(!numberList.Contains(number))
                                {
                                    numberList.Add(number);
                                }
                            }
                        }
                    }
                }
                if(numberList.Count == 2) 
                {
                    return numberList.Aggregate((a, b) => a * b);
                }
                else
                {
                    return 0;
                }
            }
            int getNumber(string line, int i)
            {
                StringBuilder num = new StringBuilder(capacity: 1);

                num.Append(line[i]);
                if (int.TryParse(line[i + 1].ToString(), out int v2))
                {
                    num.Append(line[i + 1]);

                    if (int.TryParse(line[i + 2].ToString(), out int v3))
                    {
                        num.Append(line[i + 2]);
                    }
                }
                if (int.TryParse(line[i - 1].ToString(), out int v4))
                {
                    num.Insert(0,line[i - 1]);
                    
                    if (int.TryParse(line[i - 2].ToString(), out int v5))
                    {
                        num.Insert(0,line[i - 2]);
                    }
                }
                int res = int.Parse(num.ToString());
                    return res;
                
            }

            string getNum(string line,int i)
            {
                StringBuilder num = new StringBuilder(capacity: 1);
                
                num.Append(line[i]);
                if (int.TryParse(line[i + 1].ToString(), out int v2))
                {
                    num.Append(line[i + 1]);

                    if (int.TryParse(line[i + 2].ToString(), out int v3))
                    {
                        num.Append(line[i + 2]);
                    }
                }
                return num.ToString();
            }

            int numIsValid(string[] input,int j, int i, string num)
            {
                for(int ligne = 0; ligne < 3; ligne++)
                {
                    for(int positionDansLaLigne = 0; positionDansLaLigne < num.Length +2 ; positionDansLaLigne++)
                    {
                        int lineCursor = j + ligne - 1;
                        int columnCursor = i + positionDansLaLigne - 1;
                        if(lineCursor >= 0 && lineCursor < input.Length && columnCursor >= 0 && columnCursor < input[lineCursor].Length)
                        {
                            char currentLocation = input[lineCursor][columnCursor];
                            if (currentLocation != notASymbole && !int.TryParse(currentLocation.ToString(), out int ignored))
                            {
                                return int.Parse(num);
                            }
                        }
                    }
                }
                return 0;
            }

            return result.ToString();
        }
    }
}
