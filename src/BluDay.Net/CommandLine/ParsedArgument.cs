namespace BluDay.Net.CommandLine;

public readonly struct ParsedArgument
{
    [DisallowNull]
    private readonly IImmutableList<ArgumentToken> _values;

    public ArgumentToken Token { get; }

    public bool HasValues => _values.Count > 0;

    public IImmutableList<ArgumentToken> Values
    {
        get  => _values;
        init => _values = value;
    }

    public ParsedArgument(ArgumentToken token)
    {
        _values = ImmutableList<ArgumentToken>.Empty;

        Token = token;
    }
}