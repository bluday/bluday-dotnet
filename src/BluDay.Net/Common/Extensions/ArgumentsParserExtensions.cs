namespace BluDay.Net.Common.Extensions;

public static class ArgumentsParserExtensions
{
    public static TArgs ParseFromCommandLine<TArgs>(this ArgumentsParser<TArgs> source) where TArgs : IArgs, new()
    {
        string[] args = Environment.GetCommandLineArgs()[1..];

        return source.Parse(args);
    }
}