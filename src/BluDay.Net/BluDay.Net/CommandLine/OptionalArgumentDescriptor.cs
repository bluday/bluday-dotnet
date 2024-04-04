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
            ArgumentException.ThrowIfNullOrWhiteSpace(value);

            string[] flags = value.Split(Constants.VERTICAL_BAR_CHAR);

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
}