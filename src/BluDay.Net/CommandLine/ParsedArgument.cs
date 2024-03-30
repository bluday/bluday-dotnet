namespace BluDay.Net.CommandLine;

public readonly struct ParsedArgument(ArgumentToken token)
{
    private readonly IImmutableList<ArgumentToken> _values;

    public ArgumentToken Token { get; } = token;

    public bool HasValues => _values is not null;

    [DisallowNull]
    public IImmutableList<ArgumentToken> Values
    {
        get  => _values;
        init => _values = value;
    }
}