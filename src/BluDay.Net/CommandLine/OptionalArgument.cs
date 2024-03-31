namespace BluDay.Net.CommandLine;

public class OptionalArgument : Argument
{
    private readonly ArgumentFlag? _longFlag;

    private readonly ArgumentFlag? _shortFlag;

    public ArgumentFlag PrimaryFlag => (_shortFlag ?? _longFlag)!.Value;

    public ArgumentFlag? LongFlag => _longFlag;

    public ArgumentFlag? ShortFlag => _shortFlag;

    public required new string Name { get; init; }

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

        if (primary.Type is ArgumentFlagType.Long)
        {
            _longFlag = primary;
        }
        else
        {
            _shortFlag = primary;
        }
    }
}