namespace GameTheory.Console;

using GameTheory.Logic.Entities;
using GameTheory.Logic.Providers;
using System.Text;

internal class Program
{

    static void Main(string[] args)
    {
        var settings = ParseArguments(args);
        var runner = new Runner(settings);

        var loader = new StrategyLoader();
        var strategies = loader.Load("GameTheory.Logic", settings);

        var total = RunAllGameRounds(runner, strategies);

        System.Console.WriteLine(settings);
        foreach (var totalResultForStrategy in total.OrderByDescending(kvp => kvp.Value))
        {
            System.Console.WriteLine($"{totalResultForStrategy.Key}: {totalResultForStrategy.Value}");
        }
    }

    private static Settings ParseArguments(string[] args)
    {
        Settings? returnValue = null;
        try
        {
            returnValue = ArgsParser.Parse(args);
        }
        catch
        {
            System.Console.WriteLine(ArgsParser.HelpMessage);
            Environment.Exit(1);
        }
        if (returnValue == null)
        {
            System.Console.WriteLine(ArgsParser.HelpMessage);
            Environment.Exit(1);
        }

        return returnValue;
    }

    private static Dictionary<IStrategy, int> RunAllGameRounds(Runner runner, IStrategy[] strategies)
    {
        var returnValue = new Dictionary<IStrategy, int>();
        for (int i = 0; i < strategies.Length; i++)
        {
            for (int j = i + 1; j < strategies.Length; j++)
            {
                if (!returnValue.TryGetValue(strategies[i], out var resultOne)) { returnValue[strategies[i]] = 0; }
                if (!returnValue.TryGetValue(strategies[j], out var resultTwo)) { returnValue[strategies[j]] = 0; }

                var runResult = (strategies[i].Id != strategies[j].Id)
                    ? runner.Go(strategies[i], strategies[j])
                    : runner.EmptyResult(strategies[i], strategies[j]);

                returnValue[strategies[i]] = returnValue[strategies[i]] + runResult.Results.Sum(r => r.StrategyOneScore);
                returnValue[strategies[j]] = returnValue[strategies[j]] + runResult.Results.Sum(r => r.StrategyTwoScore);
            }
        }
    
        return returnValue;
    }
}



