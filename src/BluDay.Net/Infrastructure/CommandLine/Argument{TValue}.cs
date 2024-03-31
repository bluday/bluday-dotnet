namespace BluDay.Net.CommandLine;

public abstract class Argument<TValue> : IArgument
{
    public ArgumentActionType ActionType { get; init; }

    public ArgumentStoreType StoreType { get; init; }

    public bool IsRequired { get; init; }

    public TValue? Constant { get; init; }

    public TValue? DefaultValue { get; init; }

    public string? Description { get; init; }

    public string Name { get; protected set; } = null!;

    public int MaxValueCount { get; init; }

    public Func<string, TValue?> ValueHandler { get; init; } = null!;

    object? IArgument.Constant => Constant;

    object? IArgument.DefaultValue => DefaultValue;

    Func<string, object?> IArgument.ValueHandler
    {
        get => (arg) => ValueHandler(arg);
    }
}