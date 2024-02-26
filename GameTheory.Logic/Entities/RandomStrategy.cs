namespace GameTheory.Logic.Entities;

internal class RandomStrategy : IStrategy
{
    public RandomStrategy(string name)
    {
        Name = name;
        Id = Guid.NewGuid();
    }
    private Random _rand = new Random();

    public string Name { get; init; }

    public Guid Id { get; init; }

    public Choice Next(Choice opponentPreviousChoice)
    {
        return _rand.Next(0, 2) == 0
                ? Choice.Cooperate
                : Choice.Defect;
    }
}