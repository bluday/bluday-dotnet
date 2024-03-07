namespace BluDay.Net.CommandLine;

public class ArgParser<TArgs> where TArgs : IArgs, new()
{
    private readonly IReadOnlyDictionary<ArgInfo, PropertyInfo> _argToParsablePropertyMap;

    public IEnumerable<ArgInfo> Arguments
    {
        get => _argToParsablePropertyMap.Keys.ToList().AsReadOnly();
    }

    public IReadOnlyList<PropertyInfo> ParsableProperties
    {
        get => _argToParsablePropertyMap.Values.ToList().AsReadOnly();
    }

    public IReadOnlyDictionary<ArgInfo, PropertyInfo> ArgumentToParsablePropertyMap
    {
        get => _argToParsablePropertyMap;
    }

    public ArgParser(IEnumerable<ArgInfo> args)
    {
        _argToParsablePropertyMap = null!;
    }

    public TArgs ParseArgs(string[] args)
    {
        return Activator.CreateInstance<TArgs>();
    }
}