namespace GameTheory.Logic.Entities;

internal abstract class StrategyBase : IStrategy
{
    internal StrategyBase(string name)
    {
        Name = name;
        Id = Guid.NewGuid();
    }

    public string Name { get; init; }

    public Guid Id { get; init; }

    public abstract Choice Next(Choice opponentPreviousChoice);

    public override bool Equals(object? obj)
    {
        return obj is StrategyBase always &&
            always.Name == Name &&
            always.Id == Id;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Name, Id);
    }
    
    public override string ToString()
    {
        return Name;
    }
}
