namespace BluDay.Net.Common.CommandLine;

public class ArgumentParser<TArgs> where TArgs : IArgs, new()
{
    private readonly IReadOnlyDictionary<ArgumentInfo, PropertyInfo> _argumentToPropertyMap;

    public IEnumerable<ArgumentInfo> AvailableArguments
    {
        get => _argumentToPropertyMap.Keys;
    }

    public IEnumerable<PropertyInfo> ParsableProperties
    {
        get => _argumentToPropertyMap.Values;
    }

    public IReadOnlyDictionary<ArgumentInfo, PropertyInfo> ArgumentToPropertyMap
    {
        get => _argumentToPropertyMap;
    }

    public ArgumentParser(IEnumerable<ArgumentInfo> arguments)
    {
        _argumentToPropertyMap = arguments
            .CreateArgumentToPropertyMap<TArgs>()
            .AsReadOnly();
    }

    public TArgs Parse(string[] args)
    {
        return Activator.CreateInstance<TArgs>();
    }
}