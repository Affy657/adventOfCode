using Lib;

string[] data = File.ReadAllLines("input2023Day06.txt");


AlgoBuilder builder = new AlgoBuilder(2023, 6);
IAlgo algo = builder.Build();

if(algo == null){
    Console.WriteLine("Algo not found");
    return;
}

string sum = algo.Solve(data, true);
Console.WriteLine(sum); 