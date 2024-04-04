namespace BluDay.Net.CommandLine;

public sealed class Arguments
{
    private readonly ImmutableList<OptionalArgument> _optionals;

    private readonly ImmutableList<PositionalArgument> _positionals;

    /// <summary>
    /// Gets an immutable list of distinct optional argument descriptors.
    /// </summary>
    public IImmutableList<OptionalArgument> Optionals
    {
        get  => _optionals;
        init => _optionals = value.Distinct().ToImmutableList();
    }

    /// <summary>
    /// Gets an immutable list of distinct positional argument descriptors.
    /// </summary>
    public IImmutableList<PositionalArgument> Positionals
    {
        get  => _positionals;
        init => _positionals = value.Distinct().ToImmutableList();
    }

    /// <summary>
    /// Initializes a new instance with default values.
    /// </summary>
    public Arguments() : this(null!, null!) { }

    /// <summary>
    /// Initializes a new instance with positional argument descriptors.
    /// </summary>
    /// <param name="positionals">The postional argument.</param>
    public Arguments(IEnumerable<PositionalArgument> positionals) : this(null!, positionals) { }

    /// <summary>
    /// Initializes a new instance with optional argument descriptors.
    /// </summary>
    /// <param name="optionals">An enumerable of optionals arguments.</param>
    public Arguments(IEnumerable<OptionalArgument> optionals) : this(optionals, null!) { }

    /// <summary>
    /// Initializes a new instance with optional and positional arguments.
    /// </summary>
    /// <param name="optionals">An enumerable of optionals arguments.</param>
    /// <param name="positional">An enumerable of positional arguments.</param>
    public Arguments(IEnumerable<OptionalArgument> optionals, IEnumerable<PositionalArgument> positionals)
    {
        _optionals = optionals
            .Distinct()
            .ToImmutableList() ?? ImmutableList<OptionalArgument>.Empty;

        _positionals = positionals
            .Distinct()
            .ToImmutableList() ?? ImmutableList<PositionalArgument>.Empty;
    }
}