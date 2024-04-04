namespace BluDay.Net.CommandLine;

/// <summary>
/// A class that facilitates parsing and mapping of command-line argument values to an instance of the specified generic parameter type.
/// </summary>
/// <typeparam name="TArguments">The target type for argument mapping.</typeparam>
public class ArgumentsParser<TArguments> where TArguments : new()
{
    private readonly Type _resultType;

    private readonly IImmutableList<OptionalArgument> _optionals;

    private readonly IImmutableList<PositionalArgument> _positionals;

    /// <summary>
    /// Gets the type of object that <see cref="Parse(string[])"/> method returns.
    /// </summary>
    public Type ResultType => _resultType;

    /// <summary>
    /// Gets an immutable list of distinct optional argument descriptors.
    /// </summary>
    public IImmutableList<OptionalArgument> OptionalArguments => _optionals;

    /// <summary>
    /// Represents the positional argument descriptor.
    /// </summary>
    public IImmutableList<PositionalArgument> PositionalArguments => _positionals;

    /// <summary>
    /// Initializes a new instance with default values.
    /// </summary>
    public ArgumentsParser() : this(null!, null!) { }

    /// <summary>
    /// Initializes a new instance with a positional argument descriptor.
    /// </summary>
    /// <param name="positional">The postional argument.</param>
    public ArgumentsParser(IEnumerable<PositionalArgument> positionals) : this(null!, positionals) { }

    /// <summary>
    /// Initializes a new instance with optional argument descriptors.
    /// </summary>
    /// <param name="optionals">An enumerable of optionals arguments.</param>
    public ArgumentsParser(IEnumerable<OptionalArgument> optionals) : this(optionals, null!) { }

    /// <summary>
    /// Initializes a new instance with optional and positional arguments.
    /// </summary>
    /// <param name="optionals">An enumerable of optionals arguments.</param>
    /// <param name="positional">The postional argument.</param>
    public ArgumentsParser(IEnumerable<OptionalArgument> optionals, IEnumerable<PositionalArgument> positionals)
    {
        _resultType = typeof(TArguments);

        _optionals = optionals.Distinct().ToImmutableList();

        _positionals = positionals.Distinct().ToImmutableList();
    }

    /// <summary>
    /// Parses provided raw argument values.
    /// </summary>
    /// <param name="values">Raw argument values.</param>
    /// <returns>A new <see cref="TArguments"/> instance with parsed argument.</returns>
    public TArguments Parse(params string[] values)
    {
        throw new NotImplementedException();
    }
}