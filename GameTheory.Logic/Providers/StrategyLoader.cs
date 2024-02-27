using GameTheory.Logic.Entities;

namespace GameTheory.Logic.Providers;

internal class StrategyLoader
{
    internal IStrategy[] Load(string assemblyName)
    {
        var types = System.Reflection.Assembly.Load(assemblyName)
            .GetTypes()
            .Where(t => ((System.Reflection.TypeInfo)t).ImplementedInterfaces.Select(i => i.Name).Contains("IStrategy"));

        IStrategy[] returnValue = [];
        try
        {
            returnValue = types.Select(y => y.GetConstructors().First().Invoke(new[] { y.Name }) as IStrategy).ToArray();
        }
        catch
        {
            returnValue = [];
        }

        return returnValue;
    }
}
