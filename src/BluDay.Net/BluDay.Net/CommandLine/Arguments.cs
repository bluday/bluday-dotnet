namespace BluDay.Net.CommandLine;

/// <summary>
/// Represents immutable command-line argument descriptors.
/// </summary>
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
    public Arguments()
    {
        _optionals = ImmutableList<OptionalArgument>.Empty;

        _positionals = ImmutableList<PositionalArgument>.Empty;
    }
}