namespace GameTheory.Logic.Entities;

internal class AlwaysDefectStrategy(string name) : StrategyBase(name)
{
    public override Choice Next(Choice opponentPreviousChoice)
    {
        return Choice.Defect;
    }
}
