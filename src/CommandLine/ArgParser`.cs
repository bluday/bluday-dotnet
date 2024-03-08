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

    public IReadOnlyDictionary<ArgInfo, PropertyInfo> ArgToParsablePropertyMap
    {
        get => _argToParsablePropertyMap;
    }

    public ArgParser(IEnumerable<ArgInfo> args)
    {
        _argToParsablePropertyMap = CreateArgToParsablePropertyMap(args).AsReadOnly();
    }

    public TArgs ParseArgs(string[] args)
    {
        return Activator.CreateInstance<TArgs>();
    }

    public static Dictionary<ArgInfo, PropertyInfo> CreateArgToParsablePropertyMap(IEnumerable<ArgInfo> args)
    {
        return typeof(TArgs)
            .GetProperties()
            .Select(
                property => (
                    Property: property,
                    ArgInfo:  property.GetArgInfo(args)
                )
            )
            .Where(
                pair => pair.ArgInfo is not null
            )
            .Distinct()
            .ToDictionary(
                pair => pair.ArgInfo!,
                pair => pair.Property
            );
    }
}