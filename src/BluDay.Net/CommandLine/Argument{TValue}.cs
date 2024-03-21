namespace BluDay.Net.CommandLine;

public class Argument<TValue> : IArgument
{
    object? IArgument.Constant => Constant;

    object? IArgument.DefaultValue => DefaultValue;

    Func<string, object?> IArgument.ValueHandler
    {
        get => (value) => ValueHandler.Invoke(value);
    }

    public ArgumentActionType ActionType { get; init; }

    public ArgumentFlag Flag { get; }

    public ArgumentStoreType StoreType { get; init; }

    public bool IsRequired { get; init; }

    public TValue? Constant { get; init; }

    public TValue? DefaultValue { get; init; }

    public required string Name { get; init; }

    public string? Description { get; init; }

    public int MaxValueCount { get; init; }

    public Func<string, TValue?> ValueHandler { get; init; } = null!;

    public Argument(string flagDescriptor)
    {
        Flag = new(flagDescriptor);
    }
}