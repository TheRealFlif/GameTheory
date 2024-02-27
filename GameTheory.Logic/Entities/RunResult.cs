using System.Text;

namespace GameTheory.Logic.Entities
{
    internal class RunResult
    {
        internal RunResult(Run run)
        {
            Run = run??throw new ArgumentNullException(nameof(run));
        }

        readonly List<Results> _results = [];
        internal Run Run { get; }
        internal IEnumerable<Results> Results => _results;

        internal void AddResults(Results results)
        {
            results.Score(Run.Settings);
            _results.Add(results);

        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            foreach(var result in _results) {
                sb.AppendLine($"S1 ({Run.StrategyOne.Name}): {result.StrategyOneScore}");
                sb.AppendLine($"S2 ({Run.StrategyTwo.Name}): {result.StrategyTwoScore}");
                sb.AppendLine("********");
            }
            return sb.ToString();
        }
    }
}