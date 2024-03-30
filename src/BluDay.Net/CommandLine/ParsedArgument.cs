namespace BluDay.Net.CommandLine;

public readonly struct ParsedArgument
{
    public ArgumentToken Token { get; }

    public bool HasValues => Values is not null;

    public IImmutableList<ArgumentToken> Values { get; }

    public ParsedArgument(ArgumentToken token) : this(token, Enumerable.Empty<ArgumentToken>()) { }

    public ParsedArgument(ArgumentToken token, IEnumerable<ArgumentToken> values)
    {
        ArgumentNullException.ThrowIfNull(values);

        Token = token;

        Values = values.ToImmutableList();
    }
}