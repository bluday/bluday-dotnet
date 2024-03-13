using BluDay.Net.Common.CommandLine;

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

    public static bool IsValidArgFlag(this string source)
    {
        return
            source.StartsWith(Constants.ARG_SHORT_FLAG_PREFIX) ||
            source.StartsWith(Constants.ARG_LONG_FLAG_PREFIX);
    }

    public static ArgToken ToArgToken(this string source)
    {
        return new(source);
    }
}