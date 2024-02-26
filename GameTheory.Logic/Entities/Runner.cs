namespace GameTheory.Logic.Entities;

internal class Runner
{
    private readonly Settings _settings;

    internal Runner(Settings settings)
    {
        _settings = settings;
    }

    internal RunResult Go(IStrategy strategyOne, IStrategy strategyTwo)
    {
        var run = new Run(_settings, strategyOne, strategyTwo);
        var returnValue = new RunResult(run);

        for (var i = 0; i < _settings.NumberOfRuns; i++)
        {
            var previousChoice = new Result(Choice.Start, Choice.Start);
            var results = new Results();
            for (var j = 0; j < _settings.LengthOfRun; j++)
            {
                var choiceOne = strategyOne.Next(previousChoice.StrategyTwoChoice);
                var choiceTwo = strategyTwo.Next(previousChoice.StrategyOneChoice);
                previousChoice = new Result(choiceOne, choiceTwo);
                results.AddResult(previousChoice);
            }

            returnValue.AddResults(results);
        }

        return returnValue;
    }
}
