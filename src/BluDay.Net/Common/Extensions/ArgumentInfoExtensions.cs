namespace BluDay.Net.Common.Extensions;

public static class ArgumentInfoExtensions
{
    public static ArgumentInfo? GetArgumentByName(this IEnumerable<ArgumentInfo> source, string name)
    {
        return source.FirstOrDefault(argument => argument.Name == name);
    }

    public static Dictionary<ArgumentInfo, PropertyInfo> CreateArgumentToPropertyMap<TArgs>(
        this IEnumerable<ArgumentInfo> source
    )
        where TArgs : IArgs, new()
    {
        Dictionary<ArgumentInfo, PropertyInfo> map = new();

        PropertyInfo[] properties = typeof(TArgs).GetProperties();

        foreach (var property in properties)
        {
            ArgumentAttribute? attribute = property.GetCustomAttribute<ArgumentAttribute>();

            if (attribute is null) continue;

            string name = attribute.TargetName ?? property.Name;

            ArgumentInfo? argument = source.GetArgumentByName(name);

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

        return map;
    }
}