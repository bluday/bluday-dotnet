namespace BluDay.Net.Common.Extensions;

public static class ArgumentInfoExtensions
{
    public static Dictionary<ArgumentInfo, PropertyInfo> CreateArgumentToPropertyMap<TArgs>(
        this IEnumerable<ArgumentInfo> arguments
    )
        where TArgs : IArgs, new()
    {
        return typeof(TArgs)
            .GetProperties()
            .Select(
                property => (
                    Property: property,
                    Argument: property.GetArgument(arguments)
                )
            )
            .Where(
                pair => pair.Argument is not null
            )
            .ToDictionary(
                pair => pair.Argument!,
                pair => pair.Property
            );
    }
}