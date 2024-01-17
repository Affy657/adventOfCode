using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Lib
{
    internal class Algo2023Day03 : IAlgo
    {      
        public string Solve(string[] input, bool isBonus = false)
        {
            char notASymbole = '.';
            int res = 0;

            for (int j = 0; j < input.Length; j++)
            {
                for (int i = 0; i < input[j].Length; i++)
                {                  
                    if (int.TryParse(input[j][i].ToString(), out int v1))
                    {
                        string num = getNum(input[j],i);
                        res += numIsValid(input, j, i, num);
                        i += num.Length;
                    }
                }
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

            return res.ToString();
        }
    }
}
