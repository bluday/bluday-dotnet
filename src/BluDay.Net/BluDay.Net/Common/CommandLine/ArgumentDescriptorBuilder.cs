namespace BluDay.Net.Common.CommandLine;

/// <summary>
/// A builder class for constructing an instance of the <see cref="OptionalArgumentDescriptor"/> class.
/// </summary>
public abstract class ArgumentDescriptorBuilder
{
    protected ArgumentActionKind _actionKind;

    protected ArgumentStoreKind _storeKind;

    protected object? _constant;

    protected string? _description;

    protected string? _flagDescriptor;

    protected string? _name;

    /// <summary>
    /// Gets the argument descriptors builder instance.
    /// </summary>
    public ArgumentDescriptorsBuilder Descriptors { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="ArgumentDescriptorBuilder"/> class.
    /// </summary>
    /// <param name="descriptors">
    /// The source arguments-parser builder instance.
    /// </param>
    /// <exception cref="ArgumentNullException">
    /// If <paramref name="descriptors"/> is null.
    /// </exception>
    public ArgumentDescriptorBuilder(ArgumentDescriptorsBuilder descriptors)
    {
        ArgumentNullException.ThrowIfNull(descriptors);

        Descriptors = descriptors;
    }

    /// <summary>
    /// Sets the action kind for the argument.
    /// </summary>
    /// <param name="value">The type of action to perform on the argument.</param>
    /// <returns>The builder instance.</returns>
    public ArgumentDescriptorBuilder ActionKind(ArgumentActionKind value)
    {
        _actionKind = value;

        return this;
    }

    /// <summary>
    /// Shortcut method for the <see cref="ArgumentDescriptorsBuilder.Optional"/> method.
    /// </summary>
    /// <returns>The builder instance for a new optional argument.</returns>
    public OptionalArgumentDescriptorBuilder AddOptional()
    {
        return Descriptors.AddOptional();
    }

    /// <summary>
    /// Shortcut method for the <see cref="ArgumentDescriptorsBuilder.Positional"/> method.
    /// </summary>
    /// <returns>The builder instance for a new positional argument.</returns>
    public PositionalArgumentDescriptorBuilder AddPositional()
    {
        return Descriptors.AddPositional();
    }

    /// <summary>
    /// Sets the constant to set or append for every qualifying value.
    /// </summary>
    /// <param name="value">The constant object to set.</param>
    /// <returns>The builder instance.</returns>
    public ArgumentDescriptorBuilder Constant(object value)
    {
        _constant = value;

        return this;
    }

    /// <summary>
    /// Sets the description text for the argument.
    /// </summary>
    /// <param name="value">The description for the argument.</param>
    /// <returns>The builder instance.</returns>
    public ArgumentDescriptorBuilder Description(string value)
    {
        _description = value;

        return this;
    }

    /// <summary>
    /// Sets the flag descriptor for the argument.
    /// </summary>
    /// <param name="value">The flag descriptor for the argument.</param>
    /// <returns>The builder instance.</returns>
    public ArgumentDescriptorBuilder Flags(string value)
    {
        _flagDescriptor = value;

        return this;
    }

    /// <summary>
    /// Sets the name of the argument.
    /// </summary>
    /// <param name="value">The name of the argument.</param>
    /// <returns>The builder instance.</returns>
    public ArgumentDescriptorBuilder Name(string value)
    {
        _name = value;

        return this;
    }

    /// <summary>
    /// Sets the store kind for the argument.
    /// </summary>
    /// <param name="value">The type to store the parsed value as.</param>
    /// <returns>The builder instance.</returns>
    public ArgumentDescriptorBuilder StoreKind(ArgumentStoreKind value)
    {
        _storeKind = value;

        return this;
    }

    /// <summary>
    /// Constructs an instance of the <see cref="OptionalArgumentDescriptor"/> class using all provided values.
    /// </summary>
    /// <returns>The descriptor instance.</returns>
    public abstract ArgumentDescriptor Build();
}