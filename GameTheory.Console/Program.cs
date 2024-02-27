namespace GameTheory.Console;

using GameTheory.Logic.Entities;
using GameTheory.Logic.Providers;

internal class Program
{
    static void Main(string[] args)
    {
        var settings = new ArgsParser().Parse(args);
        var loader = new StrategyLoader();
        var strategies = loader.Load("GameTheory.Logic");

        var runner = new Runner(settings);
        var runResults = new List<RunResult>();
        for (int i = 0; i < strategies.Length; i++) { 
            for(int j = i; j < strategies.Length; j++)
            {
                if (strategies[i].Id != strategies[j].Id)
                {
                    runResults.Add(runner.Go(strategies[i], strategies[j]));
                }
            }
        }
    }
}


