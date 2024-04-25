using Lib;

string[] data = File.ReadAllLines("input2023Day10.txt");


AlgoBuilder builder = new AlgoBuilder(2023, 10);
IAlgo algo = builder.Build();

if(algo == null){
    Console.WriteLine("Algo not found");
    return;
}

string sum = algo.Solve(data, true);
Console.WriteLine(sum); 