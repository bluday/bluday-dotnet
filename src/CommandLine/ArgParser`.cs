namespace BluDay.Net.CommandLine;

public class ArgumentParser<TArguments> where TArguments : class, new()
{
    private readonly IReadOnlyDictionary<ArgInfo, PropertyInfo> _argumentToParsablePropertyMap;

    public IEnumerable<ArgInfo> Arguments
    {
        get => _argumentToParsablePropertyMap.Keys.ToList().AsReadOnly();
    }

    public IReadOnlyList<PropertyInfo> ParsableProperties
    {
        get => _argumentToParsablePropertyMap.Values.ToList().AsReadOnly();
    }

    public IReadOnlyDictionary<ArgInfo, PropertyInfo> ArgumentToParsablePropertyMap
    {
        get => _argumentToParsablePropertyMap;
    }

    public ArgumentParser(IEnumerable<ArgInfo> arguments)
    {
        _argumentToParsablePropertyMap = null!;
    }

    public TArguments ParseArguments(string[] args)
    {
        return Activator.CreateInstance<TArguments>();
    }
}