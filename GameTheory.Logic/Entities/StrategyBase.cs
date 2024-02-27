namespace GameTheory.Logic.Entities
{
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
    }
}
