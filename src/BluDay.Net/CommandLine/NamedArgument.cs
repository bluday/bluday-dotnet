namespace BluDay.Net.CommandLine;

public sealed class NamedArgument : Argument
{
    private readonly ArgumentFlag? _longFlag, _shortFlag;

    public ArgumentFlag PrimaryFlag => (_shortFlag ?? _longFlag)!.Value;

    public ArgumentFlag? LongFlag => _longFlag;

    public ArgumentFlag? ShortFlag => _shortFlag;

    public NamedArgument(string flagName)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(flagName);

        if (flagName.Length > 1)
        {
            _longFlag = new(flagName, ArgumentFlagType.Long);
        }
        else
        {
            _shortFlag = new(flagName, ArgumentFlagType.Short);
        }
    }

    public NamedArgument(string shortFlagName, string longFlagName)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(longFlagName);
        ArgumentException.ThrowIfNullOrWhiteSpace(shortFlagName);

        _longFlag = new(longFlagName, ArgumentFlagType.Long);

        _shortFlag = new(shortFlagName, ArgumentFlagType.Short);
    }
}