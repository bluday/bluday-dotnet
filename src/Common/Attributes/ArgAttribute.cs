namespace BluDay.Net.Common.Attributes;

public sealed class ArgAttribute : Attribute
{
    public string? TargetName { get; init; }
}