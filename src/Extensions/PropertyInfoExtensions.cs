namespace BluDay.Net.Extensions;

public static class PropertyInfoExtensions
{
    public static ArgInfo? GetArgInfo(this PropertyInfo source, IEnumerable<ArgInfo> args)
    {
        return args.FirstOrDefault(arg => source.GetTargetedArgName() == arg.Name);
    }

    public static string? GetTargetedArgName(this PropertyInfo source)
    {
        ArgAttribute? attribute = source.GetCustomAttribute<ArgAttribute>();

        return attribute?.TargetName ?? source.Name;
    }
}