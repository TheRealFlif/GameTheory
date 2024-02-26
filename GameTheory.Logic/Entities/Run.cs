namespace GameTheory.Logic.Entities
{
    internal class Run
    {
        internal Run(
            Settings settings,
            IStrategy strategyOne,
            IStrategy strategyTwo
            )
        {
            Settings = settings;
            StrategyOne = strategyOne;
            StrategyTwo = strategyTwo;
        }

        public Settings Settings { get; init; }

        public IStrategy StrategyOne { get; init; }

        public IStrategy StrategyTwo { get; init; }
    }
}
