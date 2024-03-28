namespace BluDay.Net.Common.Extensions;

public static class StringExtensions
{
    public static bool IsAlphanumeric(this string source)
    {
        return source.All(char.IsLetterOrDigit);
    }

    public static bool IsNullOrWhiteSpace(this string source)
    {
        return string.IsNullOrWhiteSpace(source);
    }

    public static bool IsNullOrEmpty(this string source)
    {
        return string.IsNullOrEmpty(source);
    }

    public static bool StartsWith(this string source, params string[] values)
    {
        return values.All(source.StartsWith);
    }

    public static string Format(this string source, params object[] values)
    {
        return string.Format(source, values);
    }
}