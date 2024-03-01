using GameTheory.Logic.Entities;

namespace GameTheory.Logic.Providers;

internal class ArgsParser
{
    public static Settings? Parse(string[] args)
    {
        var numberOfRuns = Settings.Default.NumberOfRuns;
        var lengthOfRun = Settings.Default.LengthOfRun;
        var numberOfEachStrategyType = Settings.Default.NumberOfEachStrategyType;
        
        var reward = RewardMatrix.Default.Reward;
        var temptation = RewardMatrix.Default.Temptation;
        var suckersReward = RewardMatrix.Default.SuckerReward;
        var penalty = RewardMatrix.Default.Penalty;

        var strategySettings = new StrategySettings();

        for (int i = 0; i<args.Length; i++)
        {
            switch(args[i].ToLower())
            {
                case("-nr") :
                    numberOfRuns = ParseInteger(args[++i], "-nr");
                    break;

                case ("-rl"):
                    lengthOfRun = ParseInteger(args[++i], "-rl");
                    break;

                case ("-ns"):
                    numberOfEachStrategyType = ParseInteger(args[++i], "-ns");
                    break;

                case ("-ss"):
                    strategySettings = ParseStrategySettings(args[++i], "-ss");
                    break;
                
                case ("-r"):
                    reward = ParseInteger(args[++i], "-r");
                    break;

                case ("-t"):
                    temptation = ParseInteger(args[++i], "-t");
                    break;

                case ("-s"):
                    suckersReward = ParseInteger(args[++i], "-s");
                    break;

                case ("-p"):
                    penalty = ParseInteger(args[++i], "-p");
                    break;

                default:
                    return null; //Break with a return value of null -> show message if parameter not understood
            }
        }

        var returnValue = new Settings(
            numberOfRuns,
            lengthOfRun,
            numberOfEachStrategyType,
            new RewardMatrix(
                reward,
                temptation,
                suckersReward,
                penalty))
            .AddStrategySettings(strategySettings);

        return returnValue;
    }

    private static int ParseInteger(string value, string paramName)
    {
        int returnValue = int.Parse(value);
        if(returnValue < 0) { throw new ArgumentOutOfRangeException(paramName); }

        return returnValue;
    }

    private static StrategySettings ParseStrategySettings(string stringValue, string paramName)
    {
        var returnValue = new StrategySettings();
        var strings = stringValue.Split(",");
        foreach(var strategyPart in strings)
        {
            var strategyParts = strategyPart.Split(":");
            var strategyNames = strategyParts[0].Split(".");
            var name = strategyNames[strategyNames.Length - 1];
            var numberOfStrategies = strategyParts.Length > 1 ? ParseInteger(strategyParts[1], paramName) : 1;
            var setting = new StrategySetting(name, strategyParts[0], numberOfStrategies);
            returnValue.Add(setting);
        }

        return returnValue;
    }

    public static string HelpMessage =>
        @"Usage:
GameTheory.Console : runs the program with default values, ie -nr 100 -rl 100 -r 2 -t 3 -s 0 -p 1.
GameTheory.Console -h | -help : shows this message
GameTheory.Console [-nr <number of games>] [-rl <number of rounds for each game>] [-r <value of reward>] [-t <value of temptation>] [-s <value of sucker reward>] [-p <value of penalty>] : runs the program with the supplied values, values omitted will use the default values, see above";
}
