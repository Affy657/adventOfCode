using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lib
{
    public class Algo2023Day02 : IAlgo
    {
        public string Solve(string[] input, bool isBonus = false){
            // with only 12 red cubes, 13 green cubes, and 14 blue cubes.
            // Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green
            // Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue
            // Game 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red
            // Game 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red
            // Game 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green

            Dictionary<string, int> maxCubeForColors = new Dictionary<string, int>{
                ["red"] = 12,
                ["green"] = 13,
                ["blue"] = 14
            };
            List<int> numbersOfGames = new List<int>();

            foreach (string games in input)
            {
                    string gameNumber = games.Split(":")[0].Trim();
                    numbersOfGames.Add(int.Parse(gameNumber[gameNumber.Length - 1].ToString()));
                    string gameCubes = games.Split(":")[1].Trim();
                    gameCubes = gameCubes.Replace(";", ",");
                    
                    foreach(string cube in gameCubes.Split(",")){
                        
                        string cubeNumber = cube.Trim().Split(" ")[0];
                        string cubeColor = cube.Trim().Split(" ")[1];

                        if(int.Parse(cubeNumber) > maxCubeForColors[cubeColor]){
                            // on suprimme le dergnier element de la liste
                            numbersOfGames.RemoveAt(numbersOfGames.Count - 1);
                            // on passe a la game suivante
                            break;
                        }
                    }
            }
            int sum = numbersOfGames.Sum();

            return sum.ToString();
        }
    }
}