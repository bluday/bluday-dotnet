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

    public object? ParseArgument(string value, ArgumentInfo info)
    {
        return null;
    }

    public TArgs ParseArguments(string[] values)
    {
        return Activator.CreateInstance<TArgs>();
    }

    public TArgs ParseArgumentsFromCommandLine()
    {
        string[] values = Environment.GetCommandLineArgs()[1..];

        return ParseArguments(values);
    }
}