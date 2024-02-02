using Lib;

string[] data = File.ReadAllLines("input2023Day05.txt");


AlgoBuilder builder = new AlgoBuilder(2023, 5);
IAlgo algo = builder.Build();

if(algo == null){
    Console.WriteLine("Algo not found");
    return;
}

string sum = algo.Solve(data, true);
Console.WriteLine(sum); 