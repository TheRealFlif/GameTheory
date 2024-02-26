namespace GameTheory.Logic.Entities;

internal class AlwaysDefectStrategy : IStrategy
{
    public Choice Next(Choice opponentPreviousChoice)
    {
        return Choice.Defect;
    }
}
