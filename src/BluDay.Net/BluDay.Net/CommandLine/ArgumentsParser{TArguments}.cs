namespace BluDay.Net.CommandLine;

/// <summary>
/// A class that facilitates parsing and mapping of command-line argument values to an instance of the specified generic parameter type.
/// </summary>
/// <typeparam name="TArguments">The target type for argument mapping.</typeparam>
public class ArgumentsParser<TArguments> where TArguments : new()
{
    private readonly ArgumentDescriptors _arguments;

    private readonly Type _resultType;

    /// <summary>
    /// Gets the type of object that <see cref="Parse(string[])"/> method returns.
    /// </summary>
    public Type ResultType => _resultType;

    /// <summary>
    /// Gets an immutable list of distinct optional argument descriptors.
    /// </summary>
    public ArgumentDescriptors Arguments => _arguments;

    /// <summary>
    /// Initializes a new instance with a default <see cref="ArgumentDescriptors"/> instance.
    /// </summary>
    public ArgumentsParser() : this(new()) { }

    /// <summary>
    /// Initializes a new instance and with pre-defined arguments.
    /// </summary>
    /// <param name="arguments">A descriptor of arguments.</param>
    public ArgumentsParser(ArgumentDescriptors arguments)
    {
        ArgumentNullException.ThrowIfNull(arguments);

        _resultType = typeof(TArguments);

        _arguments = arguments;
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