namespace GameTheory.Logic.Entities;

internal class StrategySetting(string? name, string? typeName, int numberOfStrategies)
{
    internal string Name { get; } = name ?? throw new ArgumentNullException(nameof(name));
    internal string TypeName { get; } = typeName ?? throw new ArgumentNullException(nameof(typeName));
    internal int NumberOfStrategies { get; } = numberOfStrategies;

    internal static StrategySetting? CreateFromType(Type? type, int numberOfStrategies = 1)
    {
        ArgumentNullException.ThrowIfNull(type);
        ArgumentOutOfRangeException.ThrowIfLessThan(numberOfStrategies, 1, "Must be greater than 0.");

        if (!type.GetInterfaces().Any(i => i == typeof(IStrategy))) {
            return null;
            //throw new ArgumentException($"{type.FullName} doesn't implement IStrategy", nameof(type)); 
        }

        return new StrategySetting(type.Name,
            type.FullName ?? type.Name,
            numberOfStrategies);
    }

    public override bool Equals(object? obj)
    {
        return obj is StrategySetting strategySetting &&
            strategySetting.Name == Name &&
            strategySetting.TypeName == TypeName &&
            strategySetting.NumberOfStrategies == NumberOfStrategies;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(
            Name,
            TypeName,
            NumberOfStrategies);
    }

    public override string? ToString()
    {
        return $"{Name} ({TypeName}) {NumberOfStrategies} items";
    }

}