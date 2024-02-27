namespace GameTheory.Logic.Entities;

internal class AlwaysCooperateStrategy(string name) : StrategyBase(name)
{
    public override Choice Next(Choice opponentPreviousChoice)
    {
        return Choice.Cooperate;
    }
}
