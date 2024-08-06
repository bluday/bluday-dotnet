namespace BluDay.Net.CommandLine;

/// <summary>
/// A builder class for constructing an instance of the <see cref="PositionalArgumentDescriptor"/> class.
/// </summary>
/// <inheritdoc cref="ArgumentDescriptorBuilder"/>
public sealed class PositionalArgumentDescriptorBuilder : ArgumentDescriptorBuilder
{
    /// <summary>
    /// Initializes a new instance of the <see cref="PositionalArgumentDescriptorBuilder"/> class.
    /// </summary>
    /// <param name="descriptors">
    /// The source arguments-parser builder instance.
    /// </param>
    /// <exception cref="ArgumentNullException">
    /// If <paramref name="descriptors"/> is null.
    /// </exception>
    public PositionalArgumentDescriptorBuilder(ArgumentDescriptorsBuilder descriptors) : base(descriptors) { }

    /// <summary>
    /// Constructs an instance of the <see cref="PositionalArgumentDescriptor"/> class using all provided values.
    /// </summary>
    /// <returns>The descriptor instance.</returns>
    public override ArgumentDescriptor Build()
    {
        return new PositionalArgumentDescriptor()
        {
            Description = _description,
            ActionKind  = _actionKind,
            StoreKind   = _storeKind,
            Constant    = _constant
        };
    }
}