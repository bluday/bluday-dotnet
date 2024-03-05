namespace BluDay.Net.Attributes;

public sealed class ArgAttribute : Attribute
{
    public string? TargetName { get; init; }
}