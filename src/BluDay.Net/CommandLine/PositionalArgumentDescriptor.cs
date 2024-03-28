namespace BluDay.Net.CommandLine;

public sealed class PositionalArgumentDescriptor : ArgumentDescriptor
{
    public string Symbol { get; }

    public PositionalArgumentDescriptor()
    {
        Name = nameof(PositionalArgumentDescriptor);

        Symbol = Constants.POSITIONAL_ARG_SYMBOL;
    }
}