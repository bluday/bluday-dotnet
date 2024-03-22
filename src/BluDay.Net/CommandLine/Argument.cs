namespace BluDay.Net.CommandLine;

public class Argument
{
    public ArgumentActionType ActionType { get; init; }

    public ArgumentFlag Flag { get; }

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
        Flag = new(flagDescriptor);
    }
}