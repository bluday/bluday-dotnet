namespace BluDay.Net.CommandLine;

/// <summary>
/// Stores read-only lists of optional and positional argument descriptors.
/// </summary>
public sealed class ArgumentDescriptors
{
    /// <summary>
    /// Gets an read-only list of distinct optional argument descriptors.
    /// </summary>
    public IReadOnlyList<OptionalArgumentDescriptor> Optionals { get; }

    /// <summary>
    /// Gets an read-only list of distinct positional argument descriptors.
    /// </summary>
    public IReadOnlyList<PositionalArgumentDescriptor> Positionals { get; }

    /// <summary>
    /// Initializes a new instance with default values.
    /// </summary>
    public ArgumentDescriptors() : this(null!, null!) { }

    /// <summary>
    /// Initializes a new instance with positional argument descriptors.
    /// </summary>
    /// <param name="positionals">The postional argument.</param>
    public ArgumentDescriptors(IEnumerable<PositionalArgumentDescriptor> positionals)
        : this(null!, positionals) { }

    /// <summary>
    /// Initializes a new instance with optional argument descriptors.
    /// </summary>
    /// <param name="optionals">An enumerable of optionals arguments.</param>
    public ArgumentDescriptors(IEnumerable<OptionalArgumentDescriptor> optionals)
        : this(optionals, null!) { }

    /// <summary>
    /// Initializes a new instance with optional and positional arguments.
    /// </summary>
    /// <param name="optionals">An enumerable of optionals arguments.</param>
    /// <param name="positionals">An enumerable of positional arguments.</param>
    public ArgumentDescriptors(
        IEnumerable<OptionalArgumentDescriptor>   optionals,
        IEnumerable<PositionalArgumentDescriptor> positionals)
    {
        Optionals = optionals?.Distinct().ToList() ?? [];

        Positionals = positionals?.Distinct().ToList() ?? [];
    }
}