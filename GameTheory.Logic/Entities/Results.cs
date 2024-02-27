using System.Collections;

namespace GameTheory.Logic.Entities;

internal class Results : IEnumerable<Result>
{
    private readonly Dictionary<int, Result> _results = [];

    public IEnumerator<Result> GetEnumerator()
    {
        return ((IEnumerable<Result>)_results.Values).GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return ((IEnumerable)_results.Values).GetEnumerator();
    }

    internal void AddResult(Result result)
    {
        _results.Add(_results.Count + 1, result);
    }

    internal Result[] OrderedResult()
    {
        return _results.OrderBy(kvp => kvp.Key).Select(kvp => kvp.Value).ToArray();
    }

    internal int StrategyOneScore = 0;
    internal int StrategyTwoScore = 0;

    internal void Score(Settings settings)
    {
        var lookup = new Dictionary<Tuple<Choice, Choice>, int>
            {
                { new Tuple<Choice, Choice>(Choice.Cooperate, Choice.Cooperate), settings.RewardMatrix.Reward },
                { new Tuple<Choice, Choice>(Choice.Defect, Choice.Cooperate), settings.RewardMatrix.Temptation },
                { new Tuple<Choice, Choice>(Choice.Cooperate, Choice.Defect), settings.RewardMatrix.SuckerReward },
                { new Tuple<Choice, Choice>(Choice.Defect, Choice.Defect), settings.RewardMatrix.Penalty }
            };

        StrategyOneScore = _results.Sum(result => lookup[new(result.Value.StrategyOneChoice, result.Value.StrategyTwoChoice)]);
        StrategyTwoScore = _results.Sum(result => lookup[new(result.Value.StrategyTwoChoice, result.Value.StrategyOneChoice)]);
    }
}
