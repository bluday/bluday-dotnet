namespace BluDay.Net.CommandLine;

public readonly struct Argument
{
    public ArgumentToken Token { get; }

    public bool HasValues => Values is not null;

    public IReadOnlyList<ArgumentToken> Values { get; }

    public Argument(ArgumentToken token) : this(token, []) { }

    public Argument(ArgumentToken token, ArgumentToken[] values)
    {
        Token = token;

        Values = values.AsReadOnly();
    }
}