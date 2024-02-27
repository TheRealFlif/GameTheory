namespace GameTheory.Logic.Entities;

internal class RewardMatrix(
    int reward,
    int temptation,
    int suckerReward,
    int penalty)
{
    public int Reward = reward;
    public int Temptation = temptation;
    public int SuckerReward = suckerReward;
    public int Penalty = penalty;

    private static readonly RewardMatrix _default = new(2, 3, 0, 1);
    public static RewardMatrix Default => _default;

    public override bool Equals(object? obj)
    {
        return obj is RewardMatrix rewardMatrix &&
            rewardMatrix.Reward == Reward &&
            rewardMatrix.Temptation == Temptation &&
            rewardMatrix.SuckerReward == SuckerReward &&
            rewardMatrix.Penalty == Penalty;
    }
    public override int GetHashCode()
    {
        return HashCode.Combine(
            Reward,
            Temptation,
            SuckerReward,
            Penalty);
    }

    public override string ToString()
    {
        return $"R: {Reward}, T: {Temptation}, S: {SuckerReward}, P: {Penalty}";
    }
}