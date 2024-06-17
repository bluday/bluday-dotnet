namespace BluDay.Net.Attributes;

public abstract class ArgumentAttribute : Attribute
{
    public string? TargetName { get; init; }
}