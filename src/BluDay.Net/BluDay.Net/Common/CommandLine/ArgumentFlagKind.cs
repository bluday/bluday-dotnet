namespace BluDay.Net.Common.CommandLine;

/// <summary>
/// Represents different kinds of optional argument flags.
/// </summary>
public enum ArgumentFlagKind
{
    /// <summary>
    /// Represents a short flag (e.g., "-h").
    /// </summary>
    Short,

    /// <summary>
    /// Represents a long flag (e.g., "--help").
    /// </summary>
    Long
}