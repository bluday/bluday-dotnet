namespace BluDay.Net.CommandLine;

/// <summary>
/// A descriptor for positional command-line arguments.
/// </summary>
public class PositionalArgumentDescriptor : ArgumentDescriptor
{
    /// <summary>
    /// Initializes a new instance.
    /// </summary>
    /// <param name="name"><inheritdoc cref="ArgumentDescriptor(string)"/></param>
    public PositionalArgumentDescriptor(string name) : base(name) { }
}