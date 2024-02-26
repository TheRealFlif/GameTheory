namespace GameTheory.Logic.Entities;

internal class AlwaysCooperateStrategy : IStrategy
{
    public Choice Next(Choice opponentPreviousChoice)
    {
        return Choice.Cooperate;
    }
}
