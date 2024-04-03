namespace BluDay.Net.CommandLine;

/// <summary>
/// A descriptor for positional command-line arguments.
/// </summary>
public class PositionalArgument : Argument
{
    /// <summary>
    /// Gets the symbol identifier.
    /// </summary>
    public string Symbol { get; }

    /// <summary>
    /// Initializes a new instance.
    /// </summary>
    public PositionalArgument()
    {
        Name = nameof(PositionalArgument);

        Symbol = Constants.POSITIONAL_ARG_SYMBOL;
    }
}