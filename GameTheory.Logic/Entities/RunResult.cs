namespace GameTheory.Logic.Entities
{
    internal class RunResult
    {
        internal RunResult(Run run)
        {
            Run = run??throw new ArgumentNullException(nameof(run));
        }

        private List<Results> _results = [];
        internal Run Run { get; }
        internal IEnumerable<Results> Results => _results;

        internal void AddResults(Results results)
        {
            results.Score(Run.Settings);
            //CalculateScore(results);
            _results.Add(results);

        }

        //private void CalculateScore(Results results)
        //{
        //    foreach (var result in results)
        //    {
        //        var strategyOneScore = Score(new (result.StrategyOneChoice, result.StrategyTwoChoice));
        //        var strategyTwoScore = Score(new(result.StrategyTwoChoice, result.StrategyOneChoice));
        //    }
        //}

        //private int Score(Tuple<Choice, Choice> choices)//Choice a, Choice b)
        //{
        //    var lookup = new Dictionary<Tuple<Choice, Choice>, int>
        //    {
        //        { new Tuple<Choice, Choice>(Choice.Cooperate, Choice.Cooperate), Run.Settings.Reward },
        //        { new Tuple<Choice, Choice>(Choice.Defect, Choice.Cooperate), Run.Settings.Temptation },
        //        { new Tuple<Choice, Choice>(Choice.Cooperate, Choice.Defect), Run.Settings.SuckerReward },
        //        { new Tuple<Choice, Choice>(Choice.Defect, Choice.Defect), Run.Settings.Penalty }
        //    };

        //    return lookup[choices];
        //}
    }
}