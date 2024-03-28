namespace BluDay.Net.CommandLine;

internal readonly struct Argument(ArgumentToken token)
{
    public ArgumentToken Token { get; } = token;

    public bool HasValues => Values is not null;

    public IReadOnlyList<ArgumentToken>? Values { get; }

    public Argument(ArgumentToken token, IEnumerable<ArgumentToken> values) : this(token)
    {
        Values = values.ToList().AsReadOnly();
    }
}