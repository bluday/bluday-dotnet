namespace BluDay.Net.CommandLine;

public abstract class ArgumentsParser
{
    internal static readonly BindingFlags _propertyBindingFlags;

    static ArgumentsParser()
    {
        _propertyBindingFlags = BindingFlags.DeclaredOnly
            | BindingFlags.Instance
            | BindingFlags.Public
            | BindingFlags.SetProperty;
    }
}