namespace GameTheory.Logic.Entities;

internal class Settings(int numberOfRuns, int lengthOfRun, RewardMatrix rewardMatrix)
{
    public int NumberOfRuns { get; init; } = numberOfRuns;
    public int LengthOfRun { get; init; } = lengthOfRun;
    public RewardMatrix RewardMatrix { get; init; } = rewardMatrix;
   
    public override string ToString()
    {
        return $"Runs: {NumberOfRuns} of {LengthOfRun} rounds each. {RewardMatrix}";
    }

    public override bool Equals(object? obj)
    {
        return obj is Settings settings &&
            settings.NumberOfRuns == NumberOfRuns &&
            settings.LengthOfRun == LengthOfRun &&
            settings.RewardMatrix.Equals(RewardMatrix);
    }
    public override int GetHashCode()
    {
        return HashCode.Combine(NumberOfRuns, LengthOfRun, RewardMatrix);
    }

    private static readonly Settings _default = new (100, 100, RewardMatrix.Default);
    internal static Settings Default => _default;
}
