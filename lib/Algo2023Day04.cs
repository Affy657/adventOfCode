using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib
{
    internal class Algo2023Day04 : IAlgo
    {
        public string Solve(string[] input, bool isBonus = false)
        {
            int totalPoint = 0;
            foreach (var line in input) 
            {
                int gamePoint = 0;
                string[] winningNumbers = line.Split(':')[1].Split('|')[0].Split(' ');
                winningNumbers = winningNumbers.Where(e => e != "").ToArray();
                string[] playNumbers = line.Split(':')[1].Split('|')[1].Split(' ');
                playNumbers = playNumbers.Where(e => e != "").ToArray();
                
                foreach (string playNumber in playNumbers)
                {
                    if (winningNumbers.Contains(playNumber))
                    {
                        gamePoint *= 2;
                        if(gamePoint == 0)
                        {
                            gamePoint++;
                        }
                    }
                }
                totalPoint += gamePoint;

            }
            return totalPoint.ToString();
        }
    }
}
