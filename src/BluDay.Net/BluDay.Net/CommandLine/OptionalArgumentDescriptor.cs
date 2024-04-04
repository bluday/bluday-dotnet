namespace BluDay.Net.CommandLine;

/// <summary>
/// A descriptor for an optional command-line argument.
/// </summary>
public class OptionalArgumentDescriptor : ArgumentDescriptor
{
    private readonly ArgumentFlag? _longFlag;

    private readonly ArgumentFlag? _shortFlag;

    private readonly string _flagDescriptor;

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
    /// Gets the raw flag descriptor value specified at instantiation.
    /// </summary>
    /// <exception cref="ArgumentException"></exception>
    /// <exception cref="InvalidArgumentFlagLengthException"></exception>
    public required string FlagDescriptor
    {
        get => _flagDescriptor;
        init
        {
            (_shortFlag, _longFlag) = ParseFlags(value);

            _flagDescriptor = value;
        }
    }

    /// <summary>
    /// Initializes an new instance with a flags described in a <see cref="string"/> value.
    /// </summary>
    /// <param name="name"><inheritdoc cref="ArgumentDescriptor(string)"/></param>
    public OptionalArgumentDescriptor(string name) : base(name)
    {
        _flagDescriptor = null!;
    }

    /// <summary>
    /// Parses a flag descriptor and extracts the short and long argument flags.
    /// </summary>
    /// <param name="flagDescriptor">The flag descriptor string.</param>
    /// <returns>A tuple containing the short and long arguments (if present).</returns>
    /// <exception cref="ArgumentException">Thrown if the flag descriptor is null or whitespace.</exception>
    /// <exception cref="InvalidArgumentFlagLengthException">Thrown if the long flag length is incorrect.</exception>
    public static (ArgumentFlag? Short, ArgumentFlag? Long) ParseFlags(string flagDescriptor)
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

        if (secondaryName is null)
        {
            if (primary.Kind is ArgumentFlagKind.Long)
            {
                return (null, primary);
            }

            return (primary, null);
        }

        return (primary, new(secondaryName));
    }
}