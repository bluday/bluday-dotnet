namespace BluDay.Net.CommandLine;

public sealed class ArgumentsParser
{
    private readonly IEnumerable<Argument> _availableArguments;

    private readonly IReadOnlyDictionary<Argument, PropertyInfo> _argumentToPropertyMap;

    internal static readonly BindingFlags _propertyBindingFlags;

    public IEnumerable<Argument> AvailableArguments => _availableArguments;

    static ArgumentsParser()
    {
        _propertyBindingFlags = BindingFlags.DeclaredOnly
            | BindingFlags.Instance
            | BindingFlags.Public
            | BindingFlags.SetProperty;
    }

    public ArgumentsParser(IEnumerable<Argument> arguments)
    {
        _availableArguments = arguments;

        _argumentToPropertyMap = null!; // CreateArgumentToPropertyMap(arguments);
    }

    /*
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
    */

    public TArguments Parse<TArguments>(string[] args) where TArguments : new()
    {
        return (TArguments)Parse(args);
    }

    public object Parse(string[] args)
    {
        throw new NotImplementedException();
    }

    public object ParseFromCommandLine()
    {
        string[] args = Environment.GetCommandLineArgs()[1..];

        return Parse(args);
    }
}