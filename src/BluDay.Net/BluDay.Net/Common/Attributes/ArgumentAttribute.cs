namespace BluDay.Net.Common.Attributes;

public abstract class ArgumentAttribute : Attribute
{
    public string? TargetName { get; init; }
}