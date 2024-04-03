namespace BluDay.Net.CommandLine;

/// <summary>
/// A class that facilitates parsing and mapping of command-line argument values to an instance of the specified generic parameter type.
/// </summary>
/// <typeparam name="TArguments">The target type for argument mapping.</typeparam>
public class ArgumentsParser<TArguments> where TArguments : new()
{
    private readonly Type _resultType;

    private readonly PositionalArgument? _positional;

    private readonly IImmutableList<OptionalArgument> _optionals;

    /// <summary>
    /// Represents the positional argument.
    /// </summary>
    public PositionalArgument? PositionalArgument => _positional;

    /// <summary>
    /// Gets an immutable list of distinct optional arguments.
    /// </summary>
    public IImmutableList<OptionalArgument> OptionalArguments => _optionals;

    /// <summary>
    /// Gets the type of object that <see cref="Parse(string[])"/> method returns.
    /// </summary>
    public Type ResultType => _resultType;

    /// <summary>
    /// Initializes a new instance with default values.
    /// </summary>
    public ArgumentsParser() : this(null!, null!) { }

    /// <summary>
    /// Initializes a new instance with a positional argument.
    /// </summary>
    /// <param name="positional">The postional argument.</param>
    public ArgumentsParser(PositionalArgument positional) : this(null!, positional) { }

    /// <summary>
    /// Initializes a new instance with optional arguments.
    /// </summary>
    /// <param name="optionals">An enumerable of optionals arguments.</param>
    public ArgumentsParser(IEnumerable<OptionalArgument> optionals) : this(optionals, null!) { }

    /// <summary>
    /// Initializes a new instance with optional and positional arguments.
    /// </summary>
    /// <param name="optionals">An enumerable of optionals arguments.</param>
    /// <param name="positional">The postional argument.</param>
    public ArgumentsParser(IEnumerable<OptionalArgument> optionals, PositionalArgument positional)
    {
        _resultType = typeof(TArguments);

        _positional = positional;

        _optionals = optionals?.Distinct().ToImmutableList() ?? ImmutableList<OptionalArgument>.Empty;
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

    /// <summary>
    /// Parses arguments from <see cref="Environment.GetCommandLineArgs"/>.
    /// </summary>
    /// <returns>A new <see cref="TArguments"/> instance with parsed argument.</returns>
    public TArguments ParseFromCommandLine()
    {
        return Parse(Environment.GetCommandLineArgs());
    }
}