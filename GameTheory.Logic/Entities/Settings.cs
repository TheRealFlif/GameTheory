namespace GameTheory.Logic.Entities;

internal class Settings(
    int numberOfRuns, 
    int lengthOfRun, 
    int numberOfEachStrategyType, 
    RewardMatrix rewardMatrix)
{
    public int NumberOfRuns { get; init; } = numberOfRuns;
    public int LengthOfRun { get; init; } = lengthOfRun;
    public int NumberOfEachStrategyType { get; init; } = numberOfEachStrategyType;

    public RewardMatrix RewardMatrix { get; init; } = rewardMatrix;
   
    public override string ToString()
    {
        return $"Runs: {NumberOfRuns} of {LengthOfRun} rounds each with {NumberOfEachStrategyType} of each strategy. {RewardMatrix}";
    }

    public override bool Equals(object? obj)
    {
        return obj is Settings settings &&
            settings.NumberOfRuns == NumberOfRuns &&
            settings.LengthOfRun == LengthOfRun &&
            settings.NumberOfEachStrategyType == NumberOfEachStrategyType &&
            settings.RewardMatrix.Equals(RewardMatrix);
    }
    public override int GetHashCode()
    {
        return HashCode.Combine(
            NumberOfRuns, 
            LengthOfRun, 
            NumberOfEachStrategyType, 
            RewardMatrix);
    }

    private static readonly Settings _default = new (100, 100, 1, RewardMatrix.Default);
    internal static Settings Default => _default;
}
