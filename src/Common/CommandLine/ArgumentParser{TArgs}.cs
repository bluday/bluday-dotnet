namespace BluDay.Net.Common.CommandLine;

public class ArgumentParser<TArgs> where TArgs : IArgs, new()
{
    private readonly IReadOnlyDictionary<ArgumentInfo, PropertyInfo> _argumentToPropertyMap;

    public IEnumerable<ArgumentInfo> AvailableArguments => _argumentToPropertyMap.Keys;

    public IEnumerable<PropertyInfo> ParsableProperties => _argumentToPropertyMap.Values;

    public IReadOnlyDictionary<ArgumentInfo, PropertyInfo> ArgumentToPropertyMap
    {
        get => _argumentToPropertyMap;
    }

    public ArgumentParser(IEnumerable<ArgumentInfo> arguments)
    {
        _argumentToPropertyMap = CreateArgumentToPropertyMap(arguments);
    }

    private static ArgumentInfo? GetArgument(string name, IEnumerable<ArgumentInfo> arguments)
    {
        return arguments.FirstOrDefault(argument => argument.Name == name);
    }

    private static IReadOnlyDictionary<ArgumentInfo, PropertyInfo> CreateArgumentToPropertyMap(IEnumerable<ArgumentInfo> arguments)
    {
        Dictionary<ArgumentInfo, PropertyInfo> map = new();

        PropertyInfo[] properties = typeof(TArgs).GetProperties();

        foreach (var property in properties)
        {
            ArgumentAttribute? attribute = property.GetCustomAttribute<ArgumentAttribute>();

            if (attribute is null) continue;

            string name = attribute.TargetName ?? property.Name;

            ArgumentInfo? argument = GetArgument(name, arguments);

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

            map.Add(argument!, property);
        }

        return map.AsReadOnly();
    }

    public object? Parse(ArgumentInfo info, string arg)
    {
        throw new NotImplementedException();
    }

    public TArgs Parse(string[] args)
    {
        // ( 0 _ o )

        return Activator.CreateInstance<TArgs>();
    }

    public TArgs ParseFromCommandLine()
    {
        string[] args = Environment.GetCommandLineArgs()[1..];

        return Parse(args);
    }
}