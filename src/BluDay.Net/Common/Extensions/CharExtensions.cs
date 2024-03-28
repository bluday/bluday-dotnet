namespace BluDay.Net.Common.Extensions;

public static class CharExtensions
{
    public static bool IsAlphanumeric(this char source)
    {
        return char.IsLetterOrDigit(source);
    }
}