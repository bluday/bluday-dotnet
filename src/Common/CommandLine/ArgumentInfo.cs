namespace BluDay.Net.Common.CommandLine;

public sealed class ArgumentInfo : IEquatable<ArgumentInfo>
{
    public ArgumentActionType ActionType { get; init; }

    public ArgumentFlagDescriptor Flag { get; }

    public bool Required { get; init; }

    public object? Constant { get; init; }

    public object? DefaultValue { get; init; }

    public required string Name { get; init; }

    public string? Description { get; init; }

    public int MaxValueCount { get; init; }

    public Type ValueType { get; init; }

    public ArgumentInfo(string flagDescriptor)
    {
        Flag = new(flagDescriptor);

        ValueType = typeof(bool);

        DefaultValue = (bool)default;

        MaxValueCount = 1;
    }

    public bool Equals(ArgumentInfo? other)
    {
        return false;
    }
}