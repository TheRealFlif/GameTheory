namespace GameTheory.Logic.Entities;

internal class AlwaysDefectStrategy : IStrategy
{
    public AlwaysDefectStrategy(string name)
    {
        Name = name;
        Id = Guid.NewGuid();
    }
    public string Name { get; init; }

    public Guid Id { get; init; }

    public Choice Next(Choice opponentPreviousChoice)
    {
        return Choice.Defect;
    }
}
