namespace BluDay.Net.Common.CommandLine;

public class ArgumentsParser<TArgs> where TArgs : IArgs, new()
{
    private readonly Dictionary<ArgumentInfo, PropertyInfo> _argumentToPropertyMap;

    public IEnumerable<ArgumentInfo> AvailableArguments => _argumentToPropertyMap.Keys;

    public IEnumerable<PropertyInfo> ParsableProperties => _argumentToPropertyMap.Values;

    public ArgumentsParser(IEnumerable<ArgumentInfo> arguments)
    {
        _argumentToPropertyMap = CreateArgumentToPropertyMap(arguments);
    }

    public static ArgumentInfo? GetArgumentByName(string name, IEnumerable<ArgumentInfo> arguments)
    {
        return arguments.FirstOrDefault(argument => argument.Name == name);
    }

    private static Dictionary<ArgumentInfo, PropertyInfo> CreateArgumentToPropertyMap(IEnumerable<ArgumentInfo> arguments)
    {
        Dictionary<ArgumentInfo, PropertyInfo> map = new();

        PropertyInfo[] properties = typeof(TArgs).GetProperties();

        foreach (var property in properties)
        {
            ArgumentAttribute? attribute = property.GetCustomAttribute<ArgumentAttribute>();

            if (attribute is null) continue;

            string name = attribute.TargetName ?? property.Name;

            ArgumentInfo? argument = GetArgumentByName(name, arguments);

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