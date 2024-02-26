namespace GameTheory.Logic.Entities;

internal interface IStrategy
{
    public string Name { get; }

    public Guid Id { get; }

    public Choice Next(Choice opponentPreviousChoice);

}
