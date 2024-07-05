namespace BluDay.Net.Common.CommandLine;

/// <summary>
/// Represents a flag for an optional command-line argument.
/// </summary>
public readonly struct ArgumentFlag
{
    /// <summary>
    /// Gets the kind of the flag (e.g, short or long).
    /// </summary>
    public ArgumentFlagKind Kind { get; }

    /// <summary>
    /// Gets the name of the flag.
    /// </summary>
    public string Name { get; }

    /// <summary>
    /// Initializes a new value with the provided name.
    /// </summary>
    /// <param name="name">The name of the flag.</param>
    public ArgumentFlag(string name)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name);

        // TODO: Validate name.

        if (name.Length > 2)
        {
            Kind = ArgumentFlagKind.Long;
        }

        Name = name;
    }
}