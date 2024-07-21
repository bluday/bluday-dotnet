namespace BluDay.Net.Common.Attributes;

/// <summary>
/// Specifies a command-line argument with a certain name.
/// </summary>
public abstract class CommandLineArgumentAttribute : Attribute
{
    /// <summary>
    /// The name of a class property to map the value of the command-line argument to.
    /// </summary>
    public string? TargetName { get; init; }
}