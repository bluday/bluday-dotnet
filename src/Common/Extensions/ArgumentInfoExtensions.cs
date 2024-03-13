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
                    ArgInfo:  property.GetArgument(arguments)
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
}