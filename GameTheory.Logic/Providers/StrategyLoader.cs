using GameTheory.Logic.Entities;

namespace GameTheory.Logic.Providers;

internal class StrategyLoader
{
    internal IStrategy[] Load(string assemblyName)
    {
        var types = System.Reflection.Assembly.Load(assemblyName)
            .GetTypes()
            .Where(t => ((System.Reflection.TypeInfo)t).ImplementedInterfaces.Select(i => i.Name).Contains("IStrategy"));

        List<IStrategy> returnValue = [];
        try
        {
            foreach (var constructorInfo in types.Select(y => y.GetConstructors().First()))
            {
                if (constructorInfo.Invoke(new[] { constructorInfo.Name }) is IStrategy strategy)
                {
                    returnValue.Add(strategy);
                }
            }
        }
        catch
        {
            returnValue = [];
        }

        return [.. returnValue];
    }
}
