namespace BluDay.Net.Common.CommandLine;

public class ArgumentParser<TArgs> where TArgs : IArgs, new()
{
    private readonly Dictionary<ArgumentInfo, PropertyInfo> _argumentToPropertyMap;

    public IEnumerable<ArgumentInfo> AvailableArguments => _argumentToPropertyMap.Keys;

    public IEnumerable<PropertyInfo> ParsableProperties => _argumentToPropertyMap.Values;

    public ArgumentParser(IEnumerable<ArgumentInfo> arguments)
    {
        _argumentToPropertyMap = arguments.CreateArgumentToPropertyMap<TArgs>();
    }

    public object? Parse(ArgumentInfo info, string arg)
    {
        throw new NotImplementedException();
    }

    public TArgs Parse(string[] args)
    {
        throw new NotImplementedException();
    }

    public TArgs ParseFromCommandLine()
    {
        string[] args = Environment.GetCommandLineArgs()[1..];

        return Parse(args);
    }
}