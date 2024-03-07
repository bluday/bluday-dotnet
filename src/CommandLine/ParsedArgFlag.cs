namespace BluDay.Net.CommandLine;

public readonly struct ParsedArgFlag
{
    public ArgInfo Info { get; }

    public ArgToken Token { get; }

    public IReadOnlyList<object> Values { get; } = [];

    public ParsedArgFlag(ArgInfo info, ArgToken token, object[] values)
    {
        ArgumentNullException.ThrowIfNull(info);

        Info   = info;
        Token  = token;
        Values = values;
    }
}