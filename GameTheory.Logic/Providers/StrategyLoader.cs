using GameTheory.Logic.Entities;
using System.Reflection;

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
        var types = System.Reflection.Assembly.Load(assemblyName)
            .GetTypes()
            .Where(t => t.IsSubclassOf(typeof(StrategyBase)));

        IStrategy?[] returnValue = [];
        try
        {
            returnValue = types
                .Select(y => y.GetConstructors().First().Invoke(new []{ y.Name}) as IStrategy)
                .ToArray();
        }
        catch
        {
            //NOP
        }

        return [.. returnValue];
    }
}
