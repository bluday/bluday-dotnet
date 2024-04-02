namespace BluDay.Net.CommandLine;

/// <summary>
/// A class that facilitates parsing and mapping of command-line argument values to an instance of the specified generic parameter type.
/// </summary>
/// <typeparam name="TArguments">The target type for argument mapping.</typeparam>
public class ArgumentsParser<TArguments> where TArguments : new()
{
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
    /// Initializes a new instance of the <see cref="ArgumentsParser{TArguments}"/> class with default values.
    /// </summary>
    public ArgumentsParser() : this(null!, null!) { }

    /// <summary>
    /// Initializes a new instance of the <see cref="ArgumentsParser{TArguments}"/> class with a positional argument.
    /// </summary>
    /// <param name="positional">The postional argument.</param>
    public ArgumentsParser(PositionalArgument positional) : this(null!, positional) { }

    /// <summary>
    /// Initializes a new instance of the <see cref="ArgumentsParser{TArguments}"/> class with optional arguments.
    /// </summary>
    /// <param name="optionals">An enumerable of optionals arguments.</param>
    public ArgumentsParser(IEnumerable<OptionalArgument> optionals) : this(optionals, null!) { }

    /// <summary>
    /// Initializes a new instance of the <see cref="ArgumentsParser{TArguments}"/> class with optional and positional arguments.
    /// </summary>
    /// <param name="optionals">An enumerable of optionals arguments.</param>
    /// <param name="positional">The postional argument.</param>
    public ArgumentsParser(IEnumerable<OptionalArgument> optionals, PositionalArgument positional)
    {
        _positional = positional;

        _optionals = optionals?.Distinct().ToImmutableList() ?? ImmutableList<OptionalArgument>.Empty;
    }

    /// <summary>
    /// Parses raw argument string values and maps them to a new <see cref="TArguments"/> instance.
    /// </summary>
    /// <param name="values">Raw argument values.</param>
    /// <returns>A new <see cref="TArguments"/> instance with parsed and mapped argument values.</returns>
    public TArguments Parse(params string[] values)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Convenient method for parsing arguments using <see cref="Environment.GetCommandLineArgs"/>.
    /// </summary>
    /// <returns>A new <see cref="TArguments"/> instance with parsed and mapped argument values.</returns>
    public TArguments ParseFromCommandLine()
    {
        return Parse(Environment.GetCommandLineArgs());
    }
}