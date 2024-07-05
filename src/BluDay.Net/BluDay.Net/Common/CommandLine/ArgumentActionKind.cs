namespace BluDay.Net.Common.CommandLine;

/// <summary>
/// Represents different actions related to command-line arguments.
/// </summary>
public enum ArgumentActionKind
{
    /// <summary>
    /// Store a constant value.
    /// </summary>
    StoreConstant,

    /// <summary>
    /// Store a dynamic value.
    /// </summary>
    StoreValue,

    /// <summary>
    /// Append a constant value.
    /// </summary>
    AppendConstant,

    /// <summary>
    /// Append a dynamic value.
    /// </summary>
    AppendValue,

    /// <summary>
    /// Represents a count flag (e.g., for counting occurrences).
    /// </summary>
    CountFlag,

    /// <summary>
    /// Output a specified help message.
    /// </summary>
    OutputHelpMessage,

    /// <summary>
    /// Output the application version.
    /// </summary>
    OutputVersion
};