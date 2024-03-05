namespace BluDay.Net.Extensions;

public static class PropertyInfoExtensions
{
    public static ArgumentInfo? GetArgument(this PropertyInfo source, IEnumerable<ArgumentInfo> arguments)
    {
        return arguments.FirstOrDefault(argument => source.GetArgumentName() == argument.Name);
    }

    public static string? GetArgumentName(this PropertyInfo source)
    {
        ArgAttribute? attribute = source.GetCustomAttribute<ArgAttribute>();

        return attribute?.TargetName ?? source.Name;
    }
}