namespace BluDay.Net.CommandLine;

/// <summary>
/// A struct for representing a raw command-line argument flag or value.
/// </summary>
public readonly struct ParsedArgument
{
    private readonly IImmutableList<ArgumentToken> _values;

    /// <summary>
    /// The token of the parsed argument.
    /// </summary>
    public ArgumentToken Token { get; }

    /// <summary>
    /// Gets a value indicative of if the count of values is greater than zero.
    /// </summary>
    public bool HasValues => _values.Count > 0;

    /// <summary>
    /// An immutable list of store value tokens.
    /// </summary>
    public IImmutableList<ArgumentToken> Values => _values;

    /// <summary>
    /// Initializes a new value with the provided argument token.
    /// </summary>
    /// <param name="token">The token for the parsed argument.</param>
    public ParsedArgument(ArgumentToken token) : this(token, null!) { }

    /// <summary>
    /// Initializes a new value with the provided argument token and store values.
    /// </summary>
    /// <param name="token">The token for the parsed argument.</param>
    /// <param name="values">An enumerable of store value tokens.</param>
    public ParsedArgument(ArgumentToken token, IEnumerable<ArgumentToken> values)
    {
        _values = values.ToImmutableList();

        Token = token;
    }
}