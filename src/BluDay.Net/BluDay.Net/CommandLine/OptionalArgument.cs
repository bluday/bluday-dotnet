namespace BluDay.Net.CommandLine;

/// <summary>
/// A descriptor for an optional command-line argument.
/// </summary>
public class OptionalArgument : Argument
{
    private readonly ArgumentFlag? _longFlag;

    private readonly ArgumentFlag? _shortFlag;

    /// <summary>
    /// Gets either the short or the long flag, depending on flag descriptor provided at instantiation.
    /// </summary>
    public ArgumentFlag PrimaryFlag => (_shortFlag ?? _longFlag)!.Value;

    /// <summary>
    /// Gets the long flag.
    /// </summary>
    public ArgumentFlag? LongFlag => _longFlag;

    /// <summary>
    /// Gets the short flag.
    /// </summary>
    public ArgumentFlag? ShortFlag => _shortFlag;

    /// <summary>
    /// Initializes an new instance with a flags described in a <see cref="string"/> value.
    /// </summary>
    /// <param name="flagDescriptor">The flag descriptor.</param>
    /// <exception cref="InvalidArgumentFlagLengthException"></exception>
    public OptionalArgument(string flagDescriptor)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(flagDescriptor);

        string[] flags = flagDescriptor.Split(Constants.VERTICAL_BAR_CHAR);

        string primaryName = flags[0];

        string? secondaryName = flags.Length > 1 ? flags[1] : null;

        if (secondaryName?.Length < primaryName.Length)
        {
            throw new InvalidArgumentFlagLengthException(primaryName, secondaryName);
        }

        ArgumentFlag primary = new(primaryName);

        if (secondaryName is not null)
        {
            _longFlag = new(secondaryName);

            _shortFlag = primary;

            return;
        }

        if (primary.Kind is ArgumentFlagKind.Long)
        {
            _longFlag = primary;
        }
        else
        {
            _shortFlag = primary;
        }
    }
}