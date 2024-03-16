namespace BluDay.Net.Common.CommandLine;

public sealed class ParsedArgument
{
    public required ArgumentInfo Info { get; init; }

    public required ArgumentToken Token { get; init; }

    public required int Index { get; init; }

    public IReadOnlyList<object> Values { get; } = [];
}