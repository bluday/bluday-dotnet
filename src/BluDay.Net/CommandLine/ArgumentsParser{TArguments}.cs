namespace BluDay.Net.CommandLine;

public class ArgumentsParser<TArguments> where TArguments : new()
{
    private readonly List<ArgumentPropertyMap> _argumentPropertyMaps;

    public IEnumerable<IArgument> Arguments
    {
        get => _argumentPropertyMaps.Select(map => map.Argument);
    }

    public IEnumerable<PropertyInfo> TargetedProperties
    {
        get => _argumentPropertyMaps.Select(map => map.TargetProperty);
    }

    public ArgumentsParser(IEnumerable<IArgument> arguments)
    {
        _argumentPropertyMaps = new();
    }

    /*
    public static IArgument? GetArgumentByName(string name, IEnumerable<IArgument> arguments)
    {
        return arguments.FirstOrDefault(argument => argument.Name == name);
    }

    private static Dictionary<IArgument, PropertyInfo> CreateArgumentToPropertyMap(IEnumerable<IArgument> arguments)
    {
        Dictionary<IArgument, PropertyInfo> map = new();

        PropertyInfo[] properties = typeof(TArguments).GetProperties();

        foreach (var property in properties)
        {
            ArgumentAttribute? attribute = property.GetCustomAttribute<ArgumentAttribute>();

            if (attribute is null) continue;

            string name = attribute.TargetName ?? property.Name;

            IArgument? argument = GetArgumentByName(name, arguments);

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
    */

    public TArguments Parse(string[] args)
    {
        throw new NotImplementedException();
    }
}