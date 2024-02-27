using GameTheory.Logic.Entities;

namespace GameTheory.Logic.Providers;

internal class ArgsParser
{
    public Settings Parse(string[] args)
    {
        return new Settings(10, 1000);
    }
}
