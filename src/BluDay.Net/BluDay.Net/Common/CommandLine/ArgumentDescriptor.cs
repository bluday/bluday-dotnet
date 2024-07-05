namespace BluDay.Net.Common.CommandLine;

/// <summary>
/// Base class for creating derived command-line argument descriptors classes.
/// </summary>
public abstract class ArgumentDescriptor : IArgumentDescriptor
{
    private readonly ArgumentActionKind _actionKind;

    private readonly ArgumentStoreKind _storeKind;

    private readonly object? _constant;

    private readonly object? _defaultValue;

    private readonly string _name;

    private readonly Type _storeType;

    /// <summary>
    /// <inheritdoc cref="IArgumentDescriptor.ActionKind"/>
    /// </summary>
    public ArgumentActionKind ActionKind
    {
        get => _actionKind;
        init
        {
            // TODO: Reset invalid constant and default value.

            _actionKind = value;
        }
    }

    /// <summary>
    /// <inheritdoc cref="IArgumentDescriptor.StoreKind"/>
    /// </summary>
    public ArgumentStoreKind StoreKind
    {
        get => _storeKind;
        init
        {
            // TODO: Reset invalid constant and default value.

            _storeKind = value;

            _storeType = GetStoreType(value);
        }
    }

    /// <summary>
    /// <inheritdoc cref="IArgumentDescriptor.IsRequired"/>
    /// </summary>
    public bool IsRequired { get; init; }

    /// <summary>
    /// <inheritdoc cref="IArgumentDescriptor.Constant"/>
    /// </summary>
    public object? Constant
    {
        get => _constant;
        init
        {
            // TODO: Validate value type.

            _constant = value;
        }
    }

    /// <summary>
    /// <inheritdoc cref="IArgumentDescriptor.DefaultValue"/>
    /// </summary>
    public object? DefaultValue
    {
        get => _defaultValue;
        init
        {
            // TODO: Validate value type.

            _defaultValue = value;
        }
    }

    /// <summary>
    /// <inheritdoc cref="IArgumentDescriptor.Description"/>
    /// </summary>
    public string? Description { get; init; }

    /// <summary>
    /// <inheritdoc cref="IArgumentDescriptor.Name"/>
    /// </summary>
    public string Name => _name;

    /// <summary>
    /// <inheritdoc cref="IArgumentDescriptor.MaxValueCount"/>
    /// </summary>
    public int MaxValueCount { get; init; }

    /// <summary>
    /// Gets the value handler delegate for processing a raw store value.
    /// </summary>
    public Func<string, object?> ValueHandler { get; init; }

    /// <summary>
    /// <inheritdoc cref="IArgumentDescriptor.StoreType"/>
    /// </summary>
    public Type StoreType => _storeType;

    /// <summary>
    /// Initializes a new <see cref="ArgumentDescriptor"/> instance.
    /// </summary>
    /// <param name="name">The name of the argument.</param>
    public ArgumentDescriptor(string name)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name);

        _name = name;

        _storeType = null!;

        ValueHandler = null!;
    }

    /// <summary>
    /// Gets the store value type by a provided <see cref="ArgumentStoreKind"/> value.
    /// </summary>
    /// <param name="kind">The store kind.</param>
    /// <returns>The corresponding value type.</returns>
    public static Type GetStoreType(ArgumentStoreKind kind) => kind switch
    {
        ArgumentStoreKind.Boolean => typeof(bool),
        ArgumentStoreKind.Integer => typeof(int),
        ArgumentStoreKind.Point => typeof(float),
        ArgumentStoreKind.String => typeof(string),
        ArgumentStoreKind.Char => typeof(char),
        _ => typeof(bool)
    };
}