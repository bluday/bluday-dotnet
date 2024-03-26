namespace BluDay.Net.CommandLine;

public class Argument
{
    public ArgumentActionType ActionType { get; init; }

    public ArgumentFlag? ShortFlag { get; }

    public ArgumentFlag? LongFlag { get; }

    public ArgumentStoreType StoreType { get; init; }

    public bool IsRequired { get; init; }

    public object? Constant { get; init; }

    public object? DefaultValue { get; init; }

    public required string Name { get; init; }

    public string? Description { get; init; }

    public int MaxValueCount { get; init; }

    public Func<string, object?> ValueHandler { get; init; } = null!;

    public Argument(string flagDescriptor)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(flagDescriptor);

        (ShortFlag, LongFlag) = GetFlagsByDescriptor(flagDescriptor);
    }

    public static (ArgumentFlag? Short, ArgumentFlag? Long) GetFlagsByDescriptor(string descriptor)
    {
        IReadOnlyList<string> flags = descriptor.Split(Constants.VERTICAL_BAR_CHAR);

        if (flags.Count == 1)
        {

        }
    }
}