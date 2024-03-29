namespace BluDay.Net.CommandLine;

public readonly struct ParsedArgument
{
    public ArgumentToken Token { get; }

    public bool HasValues => Values is not null;

    public IReadOnlyList<ArgumentToken> Values { get; }

    public ParsedArgument(ArgumentToken token) : this(token, []) { }

    public ParsedArgument(ArgumentToken token, ArgumentToken[] values)
    {
        Token = token;

        Values = values.AsReadOnly();
    }
}