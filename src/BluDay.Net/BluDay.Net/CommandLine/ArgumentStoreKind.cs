namespace BluDay.Net.CommandLine;

/// <summary>
/// Represents different kinds of arguments in a store.
/// </summary>
public enum ArgumentStoreKind
{
    /// <summary>
    /// Represents a boolean value.
    /// </summary>
    Boolean,

    /// <summary>
    /// Represents a integer value.
    /// </summary>
    Integer,

    /// <summary>
    /// Represents a floating-point value.
    /// </summary>
    Point,

    /// <summary>
    /// Represents a string value.
    /// </summary>
    String,

    /// <summary>
    /// Represents a character value.
    /// </summary>
    Char
};