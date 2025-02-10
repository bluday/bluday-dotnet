namespace BluDay.Net.CommandLine;

/// <summary>
/// A command-line argument token.
/// </summary>
public readonly struct ArgumentToken
{
    /// <summary>
    /// Gets a value indicative whether the token is a flag.
    /// </summary>
    public bool IsFlag { get; }

    /// <summary>
    /// Gets the index of the token.
    /// </summary>
    public int Index { get; }

    /// <summary>
    /// Gets the raw token value.
    /// </summary>
    public string Value { get; }

    /// <summary>
    /// Initializes a value with the provided token.
    /// </summary>
    /// <param name="value">
    /// The token.
    /// </param>
    public ArgumentToken(string value) : this(value, -1) { }

    /// <summary>
    /// Initializes a value with the provided token and index values.
    /// </summary>
    /// <param name="value">
    /// The token.
    /// </param>
    /// <param name="index">
    /// The index of the token.
    /// </param>
    /// <exception cref="ArgumentException">
    /// If <paramref name="value"/> is null or contains only whitespace characters.
    /// </exception>
    /// <exception cref="ArgumentOutOfRangeException">
    /// If <paramref name="index"/> is less than -1.
    /// </exception>
    public ArgumentToken(string value, int index)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(value);

        ArgumentOutOfRangeException.ThrowIfLessThan(index, -1);

        IsFlag = IsValidFlag(value);

        Index = index;

        Value = value;
    }

    /// <summary>
    /// Gets a value indicative whether the value qualifies as a flag.
    /// </summary>
    /// <param name="value">
    /// The flag.
    /// </param>
    /// <returns>
    /// A <see cref="bool"/> value indicative whether the value is a flag.
    /// </returns>
    public static bool IsValidFlag(string value)
    {
        return !string.IsNullOrWhiteSpace(value)
            || value.StartsWith(Strings.ARG_SHORT_FLAG_PREFIX)
            || value.StartsWith(Strings.ARG_LONG_FLAG_PREFIX);
    }
}