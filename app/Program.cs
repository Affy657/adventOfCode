using Lib;

string[] data = File.ReadAllLines("input2023Day08.txt");


AlgoBuilder builder = new AlgoBuilder(2023, 8);
IAlgo algo = builder.Build();

if(algo == null){
    Console.WriteLine("Algo not found");
    return;
}

string sum = algo.Solve(data, true);
Console.WriteLine(sum); 