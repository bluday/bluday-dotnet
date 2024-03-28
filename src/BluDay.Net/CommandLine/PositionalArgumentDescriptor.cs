namespace BluDay.Net.CommandLine;

public sealed class PositionalArgumentDescriptor : ArgumentDescriptor
{
    public ArgumentFlag Flag { get; } = new(Constants.ARG_LONG_FLAG_PREFIX);
}