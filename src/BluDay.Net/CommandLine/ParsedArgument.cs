namespace BluDay.Net.CommandLine;

internal readonly struct ParsedArgument(ParsedArgumentToken token)
{
    public ParsedArgumentToken Token { get; } = token;

    public bool HasValues => Values is not null;

    public IReadOnlyList<ParsedArgumentToken>? Values { get; }

    public ParsedArgument(ParsedArgumentToken token, IEnumerable<ParsedArgumentToken> values) : this(token)
    {
        Values = values.ToList().AsReadOnly();
    }
}