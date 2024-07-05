namespace BluDay.Net.Common.CommandLine;

/// <summary>
/// A builder class for constructing an instance of the <see cref="OptionalArgumentDescriptor"/> class.
/// </summary>
/// <inheritdoc cref="ArgumentDescriptorBuilder"/>
public sealed class OptionalArgumentDescriptorBuilder : ArgumentDescriptorBuilder
{
    /// <summary>
    /// Initializes a new instance of the <see cref="OptionalArgumentDescriptorBuilder"/> class.
    /// </summary>
    public OptionalArgumentDescriptorBuilder(ArgumentDescriptorsBuilder descriptors) : base(descriptors) { }

    /// <summary>
    /// Constructs an instance of the <see cref="OptionalArgumentDescriptor"/> class using all provided values.
    /// </summary>
    /// <returns>The descriptor instance.</returns>
    public override ArgumentDescriptor Build()
    {
        return new OptionalArgumentDescriptor(_name!)
        {
            FlagDescriptor = _flagDescriptor!,
            Description    = _description,
            ActionKind     = _actionKind,
            StoreKind      = _storeKind,
            Constant       = _constant
        };
    }
}