namespace BluDay.Net.CommandLine;

public class ArgParser<TArgs> where TArgs : IArgs, new()
{
    private readonly IReadOnlyDictionary<PropertyInfo, ArgInfo> _parsablePropertyToArgMap;

    public IEnumerable<ArgInfo> Args
    {
        get => _parsablePropertyToArgMap.Values;
    }

    public IEnumerable<PropertyInfo> ParsableProperties
    {
        get => _parsablePropertyToArgMap.Keys;
    }

    public IReadOnlyDictionary<PropertyInfo, ArgInfo> ParsablePropertyToArgMap
    {
        get => _parsablePropertyToArgMap;
    }

    public ArgParser(IEnumerable<ArgInfo> args)
    {
        _parsablePropertyToArgMap = null!;
    }

    public TArgs ParseArgs(params string[] values)
    {
        return Activator.CreateInstance<TArgs>();
    }
}