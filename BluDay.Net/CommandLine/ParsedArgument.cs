namespace BluDay.Net.CommandLine;

/// <summary>
/// Represents a raw command-line argument flag or value.
/// </summary>
public readonly struct ParsedArgument
{
    /// <summary>
    /// Gets the token of the parsed argument.
    /// </summary>
    public ArgumentToken Token { get; }

    /// <summary>
    /// Gets a value indicative of if the count of values is greater than zero.
    /// </summary>
    public bool HasValues { get; }

    /// <summary>
    /// An enumerable of stored value tokens.
    /// </summary>
    public IEnumerable<ArgumentToken> Values { get; }

    /// <summary>
    /// Initializes a new value with the provided argument token.
    /// </summary>
    /// <param name="token">
    /// The token for the parsed argument.
    /// </param>
    public ParsedArgument(ArgumentToken token) : this(token, null!) { }

    /// <summary>
    /// Initializes a new value with the provided argument token and store values.
    /// </summary>
    /// <param name="token">
    /// The token for the parsed argument.
    /// </param>
    /// <param name="values">
    /// An enumerable of store value tokens.
    /// </param>
    public ParsedArgument(ArgumentToken token, IEnumerable<ArgumentToken> values)
    {
        Token = token;

        HasValues = values.Count() > 0;

        Values = values;
    }
}