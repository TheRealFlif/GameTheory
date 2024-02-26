namespace GameTheory.Logic.Entities;

[Flags]
internal enum Choice
{
    Start = 1 << 0,
    Cooperate = 1 << 1,
    Defect = 1 << 2
}
