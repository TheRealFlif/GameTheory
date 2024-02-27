using GameTheory.Logic.Entities;

namespace GameTheory.Logic.Providers;

internal class ArgsParser
{
    public static Settings Parse(string[] args)
    {
        return new Settings(100, 1000);
    }
}
