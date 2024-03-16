namespace BluDay.Net.Common.CommandLine;

public sealed class ParsedArgument
{
    public ArgumentInfo Info { get; }

    public ArgumentToken Token { get; }

    public IReadOnlyList<object> Values { get; }

    public ParsedArgument(ArgumentInfo info, ArgumentToken token) : this(info, token, []) { }

    public ParsedArgument(ArgumentInfo info, ArgumentToken token, object[] values)
    {
        ArgumentNullException.ThrowIfNull(info);
        ArgumentNullException.ThrowIfNull(values);

        // TODO: Validate token—and values if not empty.

        Info = info;

        Token = token;

        Values = values;
    }
}