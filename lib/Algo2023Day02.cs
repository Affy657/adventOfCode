using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Lib.IAlgo;

namespace Lib
{
    public class Algo2023Day02 : IAlgo
    {
        private const string cubeOne = "red";
        private const string cubeTwo = "green";
        private const string cubeThree = "blue";
        private const string separatorOne = ":";
        private const string separatorTwo = ";";
        private const string separatorThree = ",";
        private const string separatorFour = " ";
        private const int cubeOneValue = 12;
        private const int cubeTwoValue = 13;
        private const int cubeThreeValue = 14;

        public YearAndDayAndBonus GetYearAndDayAndBonus() => new() { Year = 2023, Day = 2, Bonus = true };

        public string Solve(string[] input, bool isBonus = false)
        {
            return isBonus ? Bonus(input) : Standard(input);
        }

        private static string Standard(string[] input)
        {
            Dictionary<string, int> maxCubeForColors = new Dictionary<string, int>
            {
                [cubeOne] = cubeOneValue,
                [cubeTwo] = cubeTwoValue,
                [cubeThree] = cubeThreeValue
            };
            List<int> numbersOfGames = new List<int>();

            foreach (string games in input)
            {
                string gameNumber = games.Split(separatorOne)[0].Trim();
                gameNumber = gameNumber.Split(separatorFour)[1].ToString();
                string gameCubes = games.Split(separatorOne)[1];
                gameCubes = gameCubes.Replace(separatorTwo, separatorThree);

                string[] gameCube = gameCubes.Split(separatorThree);
                int i = 0;
                bool outOfGames = false;

                while (i < gameCube.Length && !outOfGames)
                {
                    string[] cube = gameCube[i++].Trim().Split(separatorFour);
                    string cubeNumber = cube[0];
                    string cubeColor = cube[1];
                    if (int.Parse(cubeNumber) > maxCubeForColors[cubeColor])
                    {
                        outOfGames = true;
                    }
                }
                if (!outOfGames)
                {
                    numbersOfGames.Add(int.Parse(gameNumber));
                }

            }
            int sum = numbersOfGames.Sum();
            return sum.ToString();
        }

        private static string Bonus(string[] input)
        {
            List<int> powerCubeOfGames = new List<int>();

            foreach (string games in input)
            {
                string gameCubes = games.Split(separatorOne)[1];
                gameCubes = gameCubes.Replace(separatorTwo, separatorThree);

                string[] gameCube = gameCubes.Split(separatorThree);
                int i = 0;
                Dictionary<string, int> maxNumberCubeInGames = new Dictionary<string, int>
                {
                    [cubeOne] = 1,
                    [cubeTwo] = 1,
                    [cubeThree] = 1
                };
                while (i < gameCube.Length)
                {
                    string[] cube = gameCube[i++].Trim().Split(separatorFour);
                    string cubeNumber = cube[0];
                    string cubeColor = cube[1];
                    if (int.Parse(cubeNumber) > maxNumberCubeInGames[cubeColor])
                    {
                        maxNumberCubeInGames[cubeColor] = int.Parse(cubeNumber);
                    }
                }
                powerCubeOfGames.Add(maxNumberCubeInGames[cubeOne] * maxNumberCubeInGames[cubeTwo] * maxNumberCubeInGames[cubeThree]);

            }
            int bonusSum = powerCubeOfGames.Sum();
            return bonusSum.ToString();
        }

    }
}