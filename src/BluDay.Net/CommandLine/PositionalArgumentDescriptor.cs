namespace BluDay.Net.CommandLine;

public sealed class PositionalArgumentDescriptor : ArgumentDescriptor
{
    public string Token { get; } = Constants.ARG_LONG_FLAG_PREFIX;
}