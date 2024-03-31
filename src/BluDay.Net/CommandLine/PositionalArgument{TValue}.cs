namespace BluDay.Net.CommandLine;

public class PositionalArgument<TValue> : Argument<TValue>
{
    public string Symbol { get; }

    public PositionalArgument()
    {
        Name = nameof(PositionalArgument);

        Symbol = Constants.POSITIONAL_ARG_SYMBOL;
    }
}