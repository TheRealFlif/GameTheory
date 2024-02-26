namespace GameTheory.Logic.Entities
{
    internal class Settings
    {
        public Settings(int numberOfRuns, int lengthOfRun) {
            NumberOfRuns = numberOfRuns;
            LengthOfRun = lengthOfRun;
        }
        public int NumberOfRuns { get; init; }
        public int LengthOfRun { get; init; }

        public int Reward = 2;
        public int Temptation = 3;
        public int SuckerReward = 0;
        public int Penalty = 1;
    }
}
