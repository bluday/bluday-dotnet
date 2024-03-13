namespace BluDay.Net.CommandLine;

public class ArgParser<TArgs> where TArgs : IArgs, new()
{
    private readonly IReadOnlyDictionary<ArgInfo, PropertyInfo> _argumentToPropertyMap;

    public IEnumerable<ArgInfo> Arguments
    {
        get => _argumentToPropertyMap.Keys;
    }

    public IEnumerable<PropertyInfo> ParsableProperties
    {
        get => _argumentToPropertyMap.Values;
    }

    public IReadOnlyDictionary<ArgInfo, PropertyInfo> ArgToParsablePropertyMap
    {
        get => _argumentToPropertyMap;
    }

    public ArgParser(IEnumerable<ArgInfo> arguments)
    {
        _argumentToPropertyMap = CreateArgToParsablePropertyMap(arguments).AsReadOnly();
    }

    private static ArgInfo? GetArgument(PropertyInfo property, IEnumerable<ArgInfo> args)
    {
        return args.FirstOrDefault(arg => GetTargetedArgumentName(property) == arg.Name);
    }

    private static string? GetTargetedArgumentName(PropertyInfo property)
    {
        ArgAttribute? attribute = property.GetCustomAttribute<ArgAttribute>();

        return attribute?.TargetName ?? property.Name;
    }

    private static Dictionary<ArgInfo, PropertyInfo> CreateArgToParsablePropertyMap(IEnumerable<ArgInfo> arguments)
    {
        return typeof(TArgs)
            .GetProperties()
            .Select(
                property => (
                    Property: property,
                    ArgInfo:  GetArgument(property, arguments)
                )
            )
            .Where(
                pair => pair.ArgInfo is not null
            )
            .ToDictionary(
                pair => pair.ArgInfo!,
                pair => pair.Property
            );
    }

    public TArgs Parse(string[] args)
    {
        return Activator.CreateInstance<TArgs>();
    }
}