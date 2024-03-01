namespace GameTheory.Logic.Entities;

internal class TitForTatStrategy(string name) : StrategyBase(name)
{
    public override Choice Next(Choice opponentPreviousChoice)
    {
        return opponentPreviousChoice == Choice.Start
            ? Choice.Cooperate
            : opponentPreviousChoice;
    }
}
