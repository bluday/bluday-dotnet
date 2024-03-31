namespace BluDay.Net.CommandLine;

public sealed class PositionalArgument<TValue> : Argument<TValue>
{
    public string Symbol { get; }

    public PositionalArgument()
    {
        Name = nameof(PositionalArgument);

        Symbol = Constants.POSITIONAL_ARG_SYMBOL;
    }
}