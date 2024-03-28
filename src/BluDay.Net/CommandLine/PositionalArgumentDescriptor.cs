namespace BluDay.Net.CommandLine;

public sealed class PositionalArgumentDescriptor : ArgumentDescriptor
{
    public ArgumentFlag? Flag { get; }

    public PositionalArgumentDescriptor(string symbol)
    {
        Flag = new(symbol);
    }
}