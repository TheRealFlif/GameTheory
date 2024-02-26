namespace GameTheory.Logic.Entities;

[Flags]
internal enum Choice
{
    Cooperate = 1 << 0,
    Defect = 1 << 1
}
