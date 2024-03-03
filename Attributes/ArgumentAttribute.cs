namespace BluDay.Net.Attributes;

public sealed class ArgumentAttribute : Attribute
{
    public string? TargetName { get; init; }
}