using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Day04Year2023
{
    internal class Algo2023Day04 : IAlgo
    {
        public string Solve(string[] input, bool isBonus = false)
        {
            return isBonus ? bonus(input) : standard(input);
        }
            public string standard(string[] input)
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
            public string bonus(string[] input)
            {

                List<Card> cardCollection = new List<Card>();
                foreach (var line in input)
                {
                    string[] cardGame = line.Split(':')[0].Split(' ');
                    int cardId = int.Parse(cardGame.Where(e => e != "").ToArray()[1]);
                    List<int> winningNumbers = line
                        .Split(':')[1]
                        .Split('|')[0]
                        .Split(' ')
                        .ToList()
                        .Where(str => !string.IsNullOrWhiteSpace(str))
                        .Select( str => int.Parse(str))
                        .ToList();
                    List<int> playNumbers = line
                        .Split(':')[1]
                        .Split('|')[1]
                        .Split(' ')
                        .ToList()
                        .Where(str => !string.IsNullOrWhiteSpace(str))
                        .Select(str => int.Parse(str))
                        .ToList();
                    Card card = new Card(cardId, winningNumbers, playNumbers);
                    cardCollection.Add(card);
                }
                    int max = cardCollection.Max(x => x.ReferenceId );
                    int min = cardCollection.Min(x => x.ReferenceId );

                for (int currentReference = min;currentReference <= max;currentReference ++)
                {
                    
                    Card currenCardModel = cardCollection.Find( c => c.ReferenceId == currentReference);
                    
                    int winCount = 0;
                    foreach(int playNumber in currenCardModel.Numbers)
                    {
                        if (currenCardModel.WinningNumbers.Contains(playNumber))
                        {
                            winCount++;
                        }
                    }

                    for (int j = 0;j < currenCardModel.Count;j++)
                    {
                        for(int nextReferenceWon = currentReference + 1; nextReferenceWon <= currentReference + winCount; nextReferenceWon++)
                        {
                            if (nextReferenceWon <= max)
                            {
                                Card originalWon = cardCollection.Find(x => x.ReferenceId == nextReferenceWon);
                                originalWon.Count++;

                            }
                        }
                    }

                }
                
                return cardCollection.Sum(x => x.Count).ToString();
            }
    }
}
