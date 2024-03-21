namespace BluDay.Net.Common.CommandLine;

public class ArgumentInfo<TValue> : IArgumentInfo
{
    object? IArgumentInfo.Constant => Constant;

    object? IArgumentInfo.DefaultValue => DefaultValue;

    public ArgumentActionType ActionType { get; init; }

    public required ArgumentFlags Flags { get; init; }

    public ArgumentStoreType StoreType { get; init; }

    public bool IsRequired { get; init; }

    public TValue? Constant { get; init; }

    public TValue? DefaultValue { get; init; }

    public required string Name { get; init; }

    public string? Description { get; init; }

    public int MaxValueCount { get; init; }

    public Func<string, TValue?> Handler { get; init; } = null!;
}