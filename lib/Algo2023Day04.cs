using Lib.Day04Year2023;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib
{
    internal class Algo2023Day04 : IAlgo
    {
        public string Solve(string[] input, bool isBonus = true)
        {
            if(isBonus)
            {
                return bonus(input);
            }
            else
            {
                return standard(input);
            }

            string standard(string[] input)
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
            string bonus(string[] input)
            {

                List<Card> cards = new List<Card>();
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
                    cards.Add(card);
                }
                for(int i = 1;i <= 202;i ++)
                {
                    // rechercher la carte dont la référence est 'i'
                    List<Card> currenCardModel = [.. cards.Where( c => c.ReferenceId == i)];
                    
                    // TODO résoudre le nombre de carte gagné avec ce modèle de carte

                    int winCount = 0;
                    foreach(int playNumber in cards[i].Numbers)
                    {
                        if (cards[i].WinningNumbers.Contains(playNumber))
                        {
                            winCount++;
                        }
                    }


                    // TODO trouver les modèles de cartes suivant (i + winCount) currenCardModel.Count foi
                    for (int j = 0;j < currenCardModel.Count;j++)
                    {
                        for(int k = i+1; k < i+winCount+1; k++)
                        {
                            // ajouter les carte doublon jusqua i+wincount
                            if (k < 202)
                            {
                                Card addCard = new Card(cards[k]);
                                cards.Add(addCard);

                            }
                        }
                    }
                    
                    

                    // TODO ajouter une copie de ces carte dans la liste de référence
                    // ex: Card copy = new Card(c);

                }
                // recompter pour chaque nouvelle card
                return cards.Count.ToString();
            }
        }
    }
}
