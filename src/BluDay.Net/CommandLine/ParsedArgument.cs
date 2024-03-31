namespace BluDay.Net.CommandLine;

public readonly struct ParsedArgument
{
    private readonly IImmutableList<ArgumentToken> _values;

    public ArgumentToken Token { get; }

    public bool HasValues => _values.Count > 0;

    public IImmutableList<ArgumentToken> Values => _values;

    public ParsedArgument(ArgumentToken token) : this(token, []) { }

    public ParsedArgument(ArgumentToken token, IEnumerable<ArgumentToken> values)
    {
        ArgumentNullException.ThrowIfNull(values);

        _values = values.ToImmutableList();

        Token = token;
    }
}