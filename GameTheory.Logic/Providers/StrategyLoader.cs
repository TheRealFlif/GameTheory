using GameTheory.Logic.Entities;
using System.Linq;

namespace GameTheory.Logic.Providers;

internal class StrategyLoader
{
    /// <summary>
    /// One instance of each Strategy that is a subclass of StrategyBase
    /// </summary>
    /// <param name="assemblyName">The name of the assembly to load the instances from</param>
    /// <returns></returns>
    internal IStrategy[] Load(string assemblyName)
    {
        return Load(assemblyName, Settings.Default);
    }

    internal IStrategy[] Load(string assemblyName, Settings settings)
    {
        var namesAndTypes = System.Reflection.Assembly.Load(assemblyName)
            .GetTypes()
            .Where(t => t.IsSubclassOf(typeof(StrategyBase)))
            .Where(t => settings.StrategySettings.Count() == 0 || settings.StrategySettings.Select(ss => ss.TypeName).Contains(t.FullName))
            .Select(x => new NameAndType(
                x.Name,
                x,
                settings.StrategySettings.Count() == 0
                ? settings.NumberOfEachStrategyType
                : settings.StrategySettings.First(ss => ss.TypeName == x.FullName).NumberOfStrategies));

        List<IStrategy?> returnValue = [];

        foreach (var nameAndType in namesAndTypes)
        {
            for (var i = 0; i < nameAndType.Number; i++)
            {
                var strategy = CreateStrategy(nameAndType);
                if (strategy != null) { returnValue.Add(strategy); }
            }
        }


        return [.. returnValue];
    }

    private static IStrategy? CreateStrategy(NameAndType nameAndType)
    {
        try
        {
            var constructor = nameAndType.Type.GetConstructors().First();
            var parameters = new[] { nameAndType.Name };
            return constructor.Invoke(parameters) as IStrategy;
        }
        catch
        {
            //NOP
        }

        return null;
    }

    private sealed class NameAndType(string name, Type type, int number)
    {
        public readonly string Name = name;
        public readonly Type Type = type;
        public readonly int Number = number;
    }
}
