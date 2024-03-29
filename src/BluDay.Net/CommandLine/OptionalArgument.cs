namespace BluDay.Net.CommandLine;

public sealed class OptionalArgument : Argument
{
    private readonly ArgumentFlag? _longFlag;

    private readonly ArgumentFlag? _shortFlag;

    public ArgumentFlag PrimaryFlag => (_shortFlag ?? _longFlag)!.Value;

    public ArgumentFlag? LongFlag => _longFlag;

    public ArgumentFlag? ShortFlag => _shortFlag;

    public required override string Name { get; init; }

    public OptionalArgument(string flagDescriptor)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(flagDescriptor);

        string[] flags = flagDescriptor.Split(Constants.VERTICAL_BAR_CHAR);

        string primary = flags[0];

        string? secondary = flags.ElementAt(1);

        if (!secondary.IsNullOrWhiteSpace())
        {
            if (primary.Length > secondary.Length)
            {
                throw new InvalidArgumentFlagLengthException(primary, secondary);
            }

            _longFlag = new(secondary, ArgumentFlagType.Long);

            _shortFlag = new(primary, ArgumentFlagType.Short);

            return;
        }

        if (primary.Length > 1)
        {
            _longFlag = new(primary, ArgumentFlagType.Long);
        }
        else
        {
            _shortFlag = new(primary, ArgumentFlagType.Short);
        }
    }

    public string AsRawFlagDescriptor()
    {
        StringBuilder builder = new();

        if (_shortFlag.HasValue && _longFlag.HasValue)
        {
            builder.Append(_shortFlag.Value.Name);
            builder.Append(Constants.VERTICAL_BAR_CHAR);
            builder.Append(_longFlag.Value.Name);
        }
        else
        {
            builder.Append(PrimaryFlag);
        }

        return builder.ToString();
    }

    public override string ToString()
    {
        return $"{Name} \"{AsRawFlagDescriptor()}\"";
    }
}