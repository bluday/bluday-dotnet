namespace BluDay.Net.Common.Extensions;

public static class ArgumentsParserExtensions
{
    public static TArguments ParseFromCommandLine<TArguments>(this ArgumentsParser<TArguments> source)
        where TArguments : IArguments, new()
    {
        string[] args = Environment.GetCommandLineArgs()[1..];

        return source.Parse(args);
    }
}