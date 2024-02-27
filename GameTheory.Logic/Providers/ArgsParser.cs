using GameTheory.Logic.Entities;

namespace GameTheory.Logic.Providers;

internal class ArgsParser
{
    public static Settings? Parse(string[] args)
    {
        var numberOfRuns = Settings.Default.NumberOfRuns;
        var lengthOfRun = Settings.Default.LengthOfRun;
        var reward = Settings.Default.RewardMatrix.Reward;
        var temptation = Settings.Default.RewardMatrix.Temptation;
        var suckersReward = Settings.Default.RewardMatrix.SuckerReward;
        var penalty = Settings.Default.RewardMatrix.Penalty;

        for (int i = 0; i<args.Length; i++)
        {
            switch(args[i].ToLower())
            {
                case("-nr") :
                    numberOfRuns = int.Parse(args[++i]);
                    break;

                case ("-rl"):
                    lengthOfRun = int.Parse(args[++i]);
                    break;

                case ("-r"):
                    reward = int.Parse(args[++i]);
                    break;

                case ("-t"):
                    temptation = int.Parse(args[++i]);
                    break;

                case ("-s"):
                    suckersReward = int.Parse(args[++i]);
                    break;

                case ("-p"):
                    penalty = int.Parse(args[++i]);
                    break;

                default:
                    return null;
            }
        }
        
        return new Settings(
            numberOfRuns, 
            lengthOfRun, 
            new RewardMatrix(
                reward, 
                temptation, 
                suckersReward, 
                penalty));
    }

    public static string HelpMessage =>
        @"Usage:
GameTheory.Console : runs the program with default values, ie -nr 100 -rl 100 -r 2 -t 3 -s 0 -p 1.
GameTheory.Console -h | -help : shows this message
GameTheory.Console [-nr <number of games>] [-rl <number of rounds for each game>] [-r <value of reward>] [-t <value of temptation>] [-s <value of sucker reward>] [-p <value of penalty>] : runs the program with the supplied values, values omitted will use the default values, see above";
}
