namespace BluDay.Net.CommandLine;

/// <summary>
/// A class that facilitates parsing and mapping of command-line argument values to an instance
/// of the specified generic parameter type.
/// </summary>
/// <typeparam name="TArguments">The target type for argument mapping.</typeparam>
public class ArgumentsParser<TArguments> where TArguments : new()
{
    private readonly ArgumentDescriptors _argumentDescriptors;

    private readonly Type _resultType;

    /// <summary>
    /// Gets a descriptor of different argument descriptors.
    /// </summary>
    public ArgumentDescriptors ArgumentDescriptors => _argumentDescriptors;

    /// <summary>
    /// Gets the type of object that <see cref="ParseArguments(string[])"/> method returns.
    /// </summary>
    public Type ResultType => _resultType;

    /// <summary>
    /// Initializes a new instance and with pre-defined arguments.
    /// </summary>
    /// <param name="argumentDescriptors">
    /// A group of optional and positional argument descriptors.
    /// </param>
    /// <exception cref="ArgumentNullException">
    /// If the <see cref="ArgumentDescriptor"/> instance is null.
    /// </exception>
    public ArgumentsParser(ArgumentDescriptors argumentDescriptors)
    {
        ArgumentNullException.ThrowIfNull(argumentDescriptors);

        _argumentDescriptors = argumentDescriptors;

        _resultType = typeof(TArguments);
    }

    /// <summary>
    /// Parses a single command-line argument.
    /// </summary>
    /// <param name="value">
    /// The unparsed argument as a <see cref="string"/>.
    /// </param>
    /// <returns>
    /// A <see cref="ParsedArgument"/> value with information about the argument.
    /// </returns>
    /// <exception cref="NotImplementedException">
    /// Temporary.
    /// </exception>
    public ParsedArgument ParseArgument(string argument)
    {
        return ParseArgument(argument, []);
    }

    /// <summary>
    /// Parses a single command-line argument.
    /// </summary>
    /// <param name="value">
    /// The unparsed argument as a <see cref="string"/>.
    /// </param>
    /// <returns>
    /// A <see cref="ParsedArgument"/> value with information about the argument.
    /// </returns>
    /// <exception cref="NotImplementedException">
    /// Temporary.
    /// </exception>
    public ParsedArgument ParseArgument(string argument, params string[] values)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Parses provided raw argument values.
    /// </summary>
    /// <param name="values">
    /// A <see cref="string"/> array of raw, unparsed values.
    /// </param>
    /// <returns>
    /// A new <see cref="TArguments"/> instance with parsed argument.
    /// </returns>
    public TArguments ParseArguments(params string[] values)
    {
        return new TArguments();
    }
}