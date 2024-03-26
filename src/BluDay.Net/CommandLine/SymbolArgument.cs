namespace BluDay.Net.CommandLine;

public sealed class SymbolArgument : Argument
{
    public ArgumentFlag? Flag { get; }

    public SymbolArgument(string symbol)
    {
        Flag = new(symbol);
    }
}