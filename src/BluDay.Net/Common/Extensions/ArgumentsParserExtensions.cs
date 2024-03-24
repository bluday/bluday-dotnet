namespace BluDay.Net.Common.Extensions;

public static class ArgumentsParserExtensions
{
    public static TArguments Parse<TArguments>(this ArgumentsParser source, string[] args) where TArguments : new()
    {
        return (TArguments)source.Parse(typeof(TArguments), args);
    }

    public static TArguments ParseFromCommandLine<TArguments>(this ArgumentsParser source) where TArguments : new()
    {
        return (TArguments)source.ParseFromCommandLine(typeof(TArguments));
    }
}