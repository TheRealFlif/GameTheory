using System.Collections;

namespace GameTheory.Logic.Entities;

internal class StrategySettings : IEnumerable<StrategySetting>
{
    HashSet<StrategySetting> _strategySettings = [];
       

    public IEnumerator<StrategySetting> GetEnumerator() =>
        ((IEnumerable<StrategySetting>)_strategySettings).GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() =>
        ((IEnumerable)_strategySettings).GetEnumerator();

    public void Add(StrategySetting? strategySetting)
    {
        if (strategySetting != null) {
            _strategySettings.Add(strategySetting);
        }
    }

    public void Add(Type? type, int numberOfStrategies)
    {
        Add(StrategySetting.CreateFromType(
            type, 
            numberOfStrategies));
    }

    public override bool Equals(object? obj)
    {
        return obj is StrategySettings strategySettings &&
            strategySettings.Count() == _strategySettings.Count &&
            CompareEachStrategySetting(strategySettings);
    }

    private bool CompareEachStrategySetting(StrategySettings strategySettings)
    {
        foreach(var strategySetting in _strategySettings)
        {
            if(!strategySettings.Contains(strategySetting))
            {
                return false;
            }
        }

        return true;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(_strategySettings);
    }


}
