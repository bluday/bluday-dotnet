namespace BluDay.Net.Common.CommandLine;

/// <summary>
/// A bulilder class for constructing a <see cref="ArgumentDescriptors"/> instance.
/// </summary>
public sealed class ArgumentDescriptorsBuilder
{
    private readonly List<OptionalArgumentDescriptorBuilder> _optionals = new();

    private readonly List<PositionalArgumentDescriptorBuilder> _positionals = new();

    /// <summary>
    /// Constructs an instance of the <see cref="ArgumentsParser{TArguments}"/> class using the set values.
    /// </summary>
    /// <returns>The constructed instance.</returns>
    public ArgumentDescriptors Build()
    {
        return new(
            _optionals.Select(
                optional => (OptionalArgumentDescriptor)optional.Build()
            ),
            _positionals.Select(
                positional => (PositionalArgumentDescriptor)positional.Build()
            )
        );
    }

    /// <summary>
    /// Initializes an instance of the <see cref="OptionalArgumentDescriptorBuilder{TArguments}"/> class
    /// for constructing a optional argument descriptor.
    /// </summary>
    /// <returns>The optional argument builder instance.</returns>
    public OptionalArgumentDescriptorBuilder Optional()
    {
        OptionalArgumentDescriptorBuilder builder = new(this);

        _optionals.Add(builder);

        return builder;
    }

    /// <summary>
    /// Intitializes an instance of the <see cref="PositionalArgumentDescriptorBuilder{TArguments}"/> class
    /// for constructing a positional arguments descriptor.
    /// </summary>
    /// <returns></returns>
    public PositionalArgumentDescriptorBuilder Positional()
    {
        PositionalArgumentDescriptorBuilder builder = new(this);

        _positionals.Add(builder);

        return builder;
    }
}