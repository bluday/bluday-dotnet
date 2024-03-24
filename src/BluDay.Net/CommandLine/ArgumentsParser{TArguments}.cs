namespace BluDay.Net.CommandLine;

public class ArgumentsParser<TArguments> : ArgumentsParser where TArguments : new()
{
    private readonly IReadOnlyDictionary<Argument, PropertyInfo> _argumentToPropertyMap;

    public IEnumerable<Argument> Arguments
    {
        get => _argumentToPropertyMap.Keys;
    }

    public IEnumerable<PropertyInfo> TargetedProperties
    {
        get => _argumentToPropertyMap.Values;
    }

    public ArgumentsParser(IEnumerable<Argument> arguments)
    {
        _argumentToPropertyMap = CreateArgumentToPropertyMap(arguments);
    }

    private static IReadOnlyDictionary<Argument, PropertyInfo> CreateArgumentToPropertyMap(IEnumerable<Argument> arguments)
    {
        Dictionary<Argument, PropertyInfo> map = new();

        PropertyInfo[] properties = typeof(TArguments).GetProperties(_propertyBindingFlags);

        foreach (var property in properties)
        {
            ArgumentAttribute? attribute = property.GetCustomAttribute<ArgumentAttribute>();

            if (attribute is null) continue;

            string argumentName = attribute.TargetName ?? property.Name;

            Argument? argument = arguments.First(argument => argument.Name == argumentName);

            if (map.ContainsValue(property))
            {
                throw new ConflictingArgumentTargetPropertyException(property);
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