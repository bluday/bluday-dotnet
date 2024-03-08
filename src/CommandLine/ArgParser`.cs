namespace BluDay.Net.CommandLine;

public class ArgParser<TArgs> where TArgs : IArgs, new()
{
    private readonly IReadOnlyDictionary<ArgInfo, PropertyInfo> _argToParsablePropertyMap;

    public IEnumerable<ArgInfo> Args
    {
        get => _argToParsablePropertyMap.Keys;
    }

    public IEnumerable<PropertyInfo> ParsableProperties
    {
        get => _argToParsablePropertyMap.Values;
    }

    public IReadOnlyDictionary<ArgInfo, PropertyInfo> ArgumentToParsablePropertyMap
    {
        get => _argToParsablePropertyMap;
    }

    public ArgParser(IEnumerable<ArgInfo> args)
    {
        _argToParsablePropertyMap = null!;
    }

    public TArgs ParseArgs(params string[] values)
    {
        return Activator.CreateInstance<TArgs>();
    }
}