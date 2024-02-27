namespace GameTheory.Logic.Entities;

internal class RandomStrategy(string name) : StrategyBase(name)
{
    private readonly Random _rand = new ();

    public override Choice Next(Choice opponentPreviousChoice)
    {
        return _rand.Next(0, 2) == 0
                ? Choice.Cooperate
                : Choice.Defect;
    }
}