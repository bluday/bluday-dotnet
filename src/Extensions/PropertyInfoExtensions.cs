namespace BluDay.Net.Extensions;

public static class PropertyInfoExtensions
{
    public static ArgInfo? GetArg(this PropertyInfo source, IEnumerable<ArgInfo> arguments)
    {
        return arguments.FirstOrDefault(argument => source.GetArgName() == argument.Name);
    }

    public static string? GetArgName(this PropertyInfo source)
    {
        ArgAttribute? attribute = source.GetCustomAttribute<ArgAttribute>();

        return attribute?.TargetName ?? source.Name;
    }
}