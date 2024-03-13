namespace BluDay.Net.CommandLine;

public sealed class ArgInfo : IEquatable<ArgInfo>
{
    public ArgActionType ActionType { get; init; }

    public ArgFlagDescriptor Flag { get; }

    public bool Required { get; init; }

    public object? Constant { get; init; }

    public object? DefaultValue { get; init; }
    
    public required string Name { get; init; }

    public string? Description { get; init; }

    public int MaxValueCount { get; init; }

    public Type ValueType { get; init; }

    public ArgInfo(string flagDescriptor)
    {
        Flag = new(flagDescriptor);

        ValueType = typeof(bool);

        DefaultValue = (bool)default;

        MaxValueCount = 1;
    }

    public bool Equals(ArgInfo? other)
    {
        return false;
    }
}