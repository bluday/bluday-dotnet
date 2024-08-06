namespace BluDay.Net.CommandLine;

/// <summary>
/// A descriptor for positional command-line arguments.
/// </summary>
public class PositionalArgumentDescriptor : ArgumentDescriptor
{
    /// <summary>
    /// Initializes a new instance of the <see cref="PositionalArgumentDescriptor"/> class.
    /// </summary>
    /// <inheritdoc cref="ArgumentDescriptor(string)"/>
    public PositionalArgumentDescriptor() : base(nameof(PositionalArgumentDescriptor)) { }
}