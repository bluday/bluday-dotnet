namespace BluDay.Net.Common.CommandLine;

public class ArgumentParser<TArgs> where TArgs : IArgs, new()
{
    private readonly IReadOnlyDictionary<ArgumentInfo, PropertyInfo> _argumentToPropertyMap;

    public IEnumerable<ArgumentInfo> AvailableArguments => _argumentToPropertyMap.Keys;

    public IEnumerable<PropertyInfo> ParsableProperties => _argumentToPropertyMap.Values;

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

    public object? ParseArg(ArgumentInfo info, string value)
    {
        return null;
    }

    public TArgs ParseArgs(string[] values)
    {
        return Activator.CreateInstance<TArgs>();
    }

    public TArgs ParseArgsFromCommandLine()
    {
        string[] values = Environment.GetCommandLineArgs()[1..];

        return ParseArgs(values);
    }
}