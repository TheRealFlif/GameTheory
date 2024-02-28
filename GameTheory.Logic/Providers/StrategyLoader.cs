using GameTheory.Logic.Entities;

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
        var types = System.Reflection.Assembly.Load(assemblyName)
            .GetTypes()
            .Where(t => t.IsSubclassOf(typeof(StrategyBase)));

        List<IStrategy?> returnValue = [];
        try
        {
            for (int i = 0; i < settings.NumberOfEachStrategyType; i++)
            {
                returnValue
                    .AddRange(types
                    .Select(y => y.GetConstructors().First().Invoke(new[] { y.Name }) as IStrategy));
            }
        }
        catch
        {
            //NOP
        }

        return [.. returnValue];
    }
}
