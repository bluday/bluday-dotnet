namespace BluDay.Net.CommandLine;

public readonly struct Argument(ArgumentToken token)
{
    public ArgumentToken Token { get; } = token;

    public bool HasValues => Values is not null;

    public IReadOnlyList<ArgumentToken>? Values { get; }

    public Argument(ArgumentToken token, ArgumentToken[] values) : this(token)
    {
        Values = values.AsReadOnly();
    }
}