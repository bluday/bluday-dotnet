namespace BluDay.Net.CommandLine;

/// <summary>
/// Stores immutable lists of optional and positional argument descriptors.
/// </summary>
public sealed class ArgumentDescriptors
{
    private readonly ImmutableList<OptionalArgumentDescriptor> _optionals;

    private readonly ImmutableList<PositionalArgumentDescriptor> _positionals;

    /// <summary>
    /// Gets an immutable list of distinct optional argument descriptors.
    /// </summary>
    public IImmutableList<OptionalArgumentDescriptor> Optionals
    {
        get  => _optionals;
        init => _optionals = value.Distinct().ToImmutableList();
    }

    /// <summary>
    /// Gets an immutable list of distinct positional argument descriptors.
    /// </summary>
    public IImmutableList<PositionalArgumentDescriptor> Positionals
    {
        get  => _positionals;
        init => _positionals = value.Distinct().ToImmutableList();
    }

    /// <summary>
    /// Initializes a new instance with default values.
    /// </summary>
    public ArgumentDescriptors() : this(null!, null!) { }

    /// <summary>
    /// Initializes a new instance with positional argument descriptors.
    /// </summary>
    /// <param name="positionals">The postional argument.</param>
    public ArgumentDescriptors(IEnumerable<PositionalArgumentDescriptor> positionals) : this(null!, positionals) { }

    /// <summary>
    /// Initializes a new instance with optional argument descriptors.
    /// </summary>
    /// <param name="optionals">An enumerable of optionals arguments.</param>
    public ArgumentDescriptors(IEnumerable<OptionalArgumentDescriptor> optionals) : this(optionals, null!) { }

    /// <summary>
    /// Initializes a new instance with optional and positional arguments.
    /// </summary>
    /// <param name="optionals">An enumerable of optionals arguments.</param>
    /// <param name="positionals">An enumerable of positional arguments.</param>
    public ArgumentDescriptors(IEnumerable<OptionalArgumentDescriptor> optionals, IEnumerable<PositionalArgumentDescriptor> positionals)
    {
        _optionals = optionals
            .Distinct()
            .ToImmutableList() ?? ImmutableList<OptionalArgumentDescriptor>.Empty;

        _positionals = positionals
            .Distinct()
            .ToImmutableList() ?? ImmutableList<PositionalArgumentDescriptor>.Empty;
    }
}