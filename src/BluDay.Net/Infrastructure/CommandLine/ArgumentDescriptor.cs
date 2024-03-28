namespace BluDay.Net.CommandLine;

public abstract class ArgumentDescriptor : IArgumentDescriptor
{
    public ArgumentActionType ActionType { get; init; }

    public ArgumentStoreType StoreType { get; init; }

    public bool IsRequired { get; init; }

    public object? Constant { get; init; }

    public object? DefaultValue { get; init; }

    public string? Description { get; init; }

    public string Name { get; init; } = null!;

    public int MaxValueCount { get; init; }

    public Func<string, object?> ValueHandler { get; init; } = null!;
}