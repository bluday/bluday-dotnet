namespace BluDay.Net.Common.Extensions;

public static class PropertyInfoExtensions
{
    public static ArgumentInfo? GetArgument(this PropertyInfo source, IEnumerable<ArgumentInfo> arguments)
    {
        return arguments.FirstOrDefault(argument => GetTargetedArgumentName(source) == argument.Name);
    }

    public static string? GetTargetedArgumentName(this PropertyInfo source)
    {
        ArgumentAttribute? attribute = source.GetCustomAttribute<ArgumentAttribute>();

        return attribute?.TargetName ?? source.Name;
    }
}