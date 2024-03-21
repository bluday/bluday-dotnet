namespace BluDay.Net.CommandLine;

public class ArgumentInfo<TValue> : IArgumentInfo
{
    object? IArgumentInfo.Constant => Constant;

    object? IArgumentInfo.DefaultValue => DefaultValue;

    Func<string, object?> IArgumentInfo.ValueHandler
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

    public ArgumentInfo(string flagDescriptor)
    {
        Flag = new(flagDescriptor);
    }
}