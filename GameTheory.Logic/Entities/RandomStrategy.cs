namespace GameTheory.Logic.Entities;

internal class RandomStrategy : IStrategy
{
    private Random _rand = new Random();

    public Choice Next(Choice opponentPreviousChoice)
    {
        return _rand.Next(0, 2) == 0
                ? Choice.Cooperate
                : Choice.Defect;
    }
}