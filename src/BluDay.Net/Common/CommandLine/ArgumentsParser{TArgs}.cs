namespace BluDay.Net.Common.CommandLine;

public class ArgumentsParser<TArgs> where TArgs : IArgs, new()
{
    private readonly Dictionary<IArgumentInfo, PropertyInfo> _argumentToPropertyMap;

    public IEnumerable<IArgumentInfo> AvailableArguments
    {
        get => _argumentToPropertyMap.Keys;
    }

    public IEnumerable<PropertyInfo> ParsableProperties
    {
        get => _argumentToPropertyMap.Values;
    }

    public ArgumentsParser(IEnumerable<IArgumentInfo> arguments)
    {
        _argumentToPropertyMap = CreateArgumentToPropertyMap(arguments);
    }

    public static IArgumentInfo? GetArgumentByName(string name, IEnumerable<IArgumentInfo> arguments)
    {
        return arguments.FirstOrDefault(argument => argument.Name == name);
    }

    private static Dictionary<IArgumentInfo, PropertyInfo> CreateArgumentToPropertyMap(IEnumerable<IArgumentInfo> arguments)
    {
        Dictionary<IArgumentInfo, PropertyInfo> map = new();

        PropertyInfo[] properties = typeof(TArgs).GetProperties();

        foreach (var property in properties)
        {
            ArgumentAttribute? attribute = property.GetCustomAttribute<ArgumentAttribute>();

            if (attribute is null) continue;

            string name = attribute.TargetName ?? property.Name;

            IArgumentInfo? argument = GetArgumentByName(name, arguments);

            if (argument is null)
            {
                // TODO: Throw non-found argument info exception.
                throw new ArgumentException();
            }

            if (map.ContainsValue(property))
            {
                // TODO: Throw target property conflict exception.
                throw new InvalidOperationException();
            }

            map.Add(argument, property);
        }

        return map;
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