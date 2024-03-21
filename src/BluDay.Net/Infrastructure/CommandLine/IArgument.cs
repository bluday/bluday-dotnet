namespace BluDay.Net.CommandLine;

public interface IArgument
{
    ArgumentActionType ActionType { get; }

    ArgumentFlag Flag { get; }

    ArgumentStoreType StoreType { get; }

    bool IsRequired { get; }

    object? Constant { get; }

    object? DefaultValue { get; }

    string Name { get; }

    string? Description { get; }

    int MaxValueCount { get; }

    Func<string, object?> ValueHandler { get; }
}