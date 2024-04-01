namespace BluDay.Net.CommandLine;

public interface IArgument
{
    ArgumentActionKind ActionKind { get; }

    ArgumentStoreKind StoreKind { get; }

    bool IsRequired { get; }

    object? Constant { get; }

    object? DefaultValue { get; }

    string? Description { get; }

    string? Name { get; }

    int MaxValueCount { get; }
}