namespace BluDay.Net.CommandLine;

public interface IArgumentsParser
{
    /// <summary>
    /// Represents the positional argument descriptor.
    /// </summary>
    PositionalArgument? PositionalArgument { get; }

    /// <summary>
    /// Gets an immutable list of distinct optional argument descriptors.
    /// </summary>
    IImmutableList<OptionalArgument> OptionalArguments { get; }

    /// <summary>
    /// Gets the type that the <see cref="Parse(string[])"/> method returns an instance of.
    /// </summary>
    Type ResultType { get; }

    /// <summary>
    /// Parses raw argument string values and maps them to a new arguments instance.
    /// </summary>
    /// <param name="values">Raw argument values.</param>
    /// <returns>A new arguments instance with parsed and mapped argument values.</returns>
    object Parse(params string[] values);

    /// <summary>
    /// Convenient method for parsing arguments using <see cref="Environment.GetCommandLineArgs"/>.
    /// </summary>
    /// <returns>A new arguments instance with parsed and mapped argument values.</returns>
    object ParseFromCommandLine();
}