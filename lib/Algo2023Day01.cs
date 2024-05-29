namespace Lib;

public class Algo2023Day01 : IAlgo
{
    public int Getday()
    {
        return 1;
    }
    public string Solve(string[] input, bool isBonus = false){

        List<int> numbers = new List<int>();
        Dictionary<string, int> numbersString = new Dictionary<string, int>{
            ["twone"] = 21,
            ["eightwo"] = 82,
            ["eighthree"] = 83,
            ["nineight"] = 98,
            ["oneight"] =18,
            ["threeight"] = 38,
            ["fiveight"] = 58,
            ["sevenine"] = 79,
            ["one"] = 1,
            ["two"] = 2,
            ["three"] = 3,
            ["four"] = 4,
            ["five"] = 5,
            ["six"] = 6,
            ["seven"] = 7,
            ["eight"] = 8,
            ["nine"] = 9
        };
        
        foreach (string item in input)
        {
            List<int> lineIntegersOnly = new List<int>();
            string itemReplaced = item;

            if (isBonus){
                foreach(KeyValuePair<string, int> page in numbersString){
                    itemReplaced = itemReplaced.Replace(page.Key, page.Value.ToString());

                }
            }
            
            foreach(char c in itemReplaced)
            {
                if(int.TryParse(c.ToString(), out int result)){
                    lineIntegersOnly.Add(result);
                }
            }

            string numbersOfLine = lineIntegersOnly[0].ToString() + lineIntegersOnly.Last().ToString();
            numbers.Add(int.Parse(numbersOfLine));
        }

        int sum = numbers.Sum();

        return sum.ToString();
        
    }
}
