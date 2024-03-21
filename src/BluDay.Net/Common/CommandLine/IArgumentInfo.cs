namespace BluDay.Net.Common.CommandLine;

public interface IArgumentInfo
{
    ArgumentActionType ActionType { get; }

    ArgumentFlags Flags { get; }

    ArgumentStoreType StoreType { get; }

    bool IsRequired { get; }

    object? Constant { get; }

    object? DefaultValue { get; }

    string Name { get; }

    string? Description { get; }

    int MaxValueCount { get; }
}