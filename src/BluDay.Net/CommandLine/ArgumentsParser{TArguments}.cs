namespace BluDay.Net.CommandLine;

public class ArgumentsParser<TArguments> where TArguments : new()
{
    private readonly Dictionary<IArgument, PropertyInfo> _argumentToPropertyMap;

    public IEnumerable<IArgument> Arguments
    {
        get => _argumentToPropertyMap.Keys;
    }

    public IEnumerable<PropertyInfo> TargetedProperties
    {
        get => _argumentToPropertyMap.Values;
    }

    public ArgumentsParser(IEnumerable<IArgument> arguments)
    {
        _argumentToPropertyMap = CreateArgumentToPropertyMap(arguments);
    }

    private static Dictionary<IArgument, PropertyInfo> CreateArgumentToPropertyMap(IEnumerable<IArgument> arguments)
    {
        Dictionary<IArgument, PropertyInfo> map = new();

        PropertyInfo[] properties = typeof(TArguments).GetProperties();

        foreach (var property in properties)
        {
            ArgumentAttribute? attribute = property.GetCustomAttribute<ArgumentAttribute>();

            if (attribute is null) continue;

            string argumentName = attribute.TargetName ?? property.Name;

            IArgument? argument = arguments.First(argument => argument.Name == argumentName);

            if (map.ContainsValue(property))
            {
                // TODO: Throw target property conflict exception.
                throw new InvalidOperationException();
            }

            map.Add(argument, property);
        }

        return map;
    }

    public TArguments Parse(string[] args)
    {
        throw new NotImplementedException();
    }
}