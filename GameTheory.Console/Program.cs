namespace GameTheory.Console;

using GameTheory.Logic.Entities;
using GameTheory.Logic.Providers;

internal class Program
{
    static void Main(string[] args)
    {
        Settings? settings = null;
        try
        {
            settings = ArgsParser.Parse(args);
        }
        catch
        {
            System.Console.WriteLine(ArgsParser.HelpMessage);
            Environment.Exit(1);
        }
        if (settings == null) {
            System.Console.WriteLine(ArgsParser.HelpMessage);
            Environment.Exit(1);
        }

        var loader = new StrategyLoader();
        var strategies = loader.Load("GameTheory.Logic");

        var total = RunAllGameRounds(settings, strategies);

        System.Console.WriteLine(settings);
        foreach (var totalResultForStrategy in total.OrderByDescending(kvp => kvp.Value))
        {
            System.Console.WriteLine($"{totalResultForStrategy.Key}: {totalResultForStrategy.Value}");
        }
    }

    private static Dictionary<string, int> RunAllGameRounds(Settings settings, IStrategy[] strategies)
    {
        var returnValue = new Dictionary<string, int>();
        var runner = new Runner(settings);
        var runResults = new List<RunResult>();
        for (int i = 0; i < strategies.Length; i++)
        {
            for (int j = i; j < strategies.Length; j++)
            {
                if (strategies[i].Id != strategies[j].Id)
                {
                    var runResult = runner.Go(strategies[i], strategies[j]);
                    System.Console.WriteLine(runResult);
                    runResults.Add(runResult);
                    var oneKey = $"{strategies[i].Name}_{strategies[i].Id}";
                    var twoKey = $"{strategies[j].Name}_{strategies[j].Id}";
                    if (!returnValue.TryGetValue(oneKey, out var resultOne))
                    { resultOne = 0; }
                    if (!returnValue.TryGetValue(twoKey, out var resultTwo))
                    { resultTwo = 0; }

                    returnValue[oneKey] = resultOne + runResult.Results.Sum(r => r.StrategyOneScore);
                    returnValue[twoKey] = resultTwo + runResult.Results.Sum(r => r.StrategyTwoScore);
                }
            }
        }

        return returnValue;
    }
}



