namespace BluDay.Net.CommandLine;

public sealed class PositionalArgumentDescriptor : ArgumentDescriptor
{
    public string Symbol { get; } = Constants.POSITIONAL_ARG_SYMBOL;
}