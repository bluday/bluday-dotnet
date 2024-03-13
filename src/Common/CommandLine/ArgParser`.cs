namespace BluDay.Net.Common.CommandLine;

public class ArgParser<TArgs> where TArgs : IArgs, new()
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

    public ArgParser(IEnumerable<ArgumentInfo> arguments)
    {
        _argumentToPropertyMap = CreateArgumentToPropertyMap(arguments).AsReadOnly();
    }

    private static ArgumentInfo? GetArgument(PropertyInfo property, IEnumerable<ArgumentInfo> args)
    {
        return args.FirstOrDefault(arg => GetTargetedArgumentName(property) == arg.Name);
    }

    private static string? GetTargetedArgumentName(PropertyInfo property)
    {
        ArgAttribute? attribute = property.GetCustomAttribute<ArgAttribute>();

        return attribute?.TargetName ?? property.Name;
    }

    private static Dictionary<ArgumentInfo, PropertyInfo> CreateArgumentToPropertyMap(IEnumerable<ArgumentInfo> arguments)
    {
        return typeof(TArgs)
            .GetProperties()
            .Select(
                property => (
                    Property: property,
                    ArgInfo: GetArgument(property, arguments)
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