namespace GameTheory.Logic.Entities;

internal class Settings(int numberOfRuns, int lengthOfRun)
{
    public int NumberOfRuns { get; init; } = numberOfRuns;
    public int LengthOfRun { get; init; } = lengthOfRun;

    public int Reward = 2;
    public int Temptation = 3;
    public int SuckerReward = 0;
    public int Penalty = 1;

    public override string ToString()
    {
        return $"Runs: {NumberOfRuns} of {LengthOfRun} rounds each. R: {Reward}, T: {Temptation}, S: {SuckerReward}, P: {Penalty}";
    }
}
