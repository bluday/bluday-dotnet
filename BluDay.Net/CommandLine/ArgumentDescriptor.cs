namespace BluDay.Net.CommandLine;

/// <summary>
/// Serves as the foundational class for defining command-line argument descriptors.
/// Provides core functionality for derived descriptor classes.
/// </summary>
public abstract class ArgumentDescriptor : IArgumentDescriptor
{
    private readonly ArgumentActionKind _actionKind;

    private readonly ArgumentStoreKind _storeKind;

    private readonly object? _constant;

    private readonly object? _defaultValue;

    private readonly string _name;

    private readonly Type _storeType;

    /// <inheritdoc cref="IArgumentDescriptor.ActionKind"/>
    public ArgumentActionKind ActionKind
    {
        get => _actionKind;
        init
        {
            // TODO: Reset invalid constant and default value.

            _actionKind = value;
        }
    }

    /// <inheritdoc cref="IArgumentDescriptor.StoreKind"/>
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

    /// <inheritdoc cref="IArgumentDescriptor.IsRequired"/>
    public bool IsRequired { get; init; }

    /// <inheritdoc cref="IArgumentDescriptor.Constant"/>
    public object? Constant
    {
        get => _constant;
        init
        {
            // TODO: Validate value type.

            _constant = value;
        }
    }

    /// <inheritdoc cref="IArgumentDescriptor.DefaultValue"/>
    public object? DefaultValue
    {
        get => _defaultValue;
        init
        {
            // TODO: Validate value type.

            _defaultValue = value;
        }
    }

    /// <inheritdoc cref="IArgumentDescriptor.Description"/>
    public string? Description { get; init; }

    /// <inheritdoc cref="IArgumentDescriptor.Name"/>
    public string Name => _name;

    /// <inheritdoc cref="IArgumentDescriptor.MaxValueCount"/>
    public int MaxValueCount { get; init; }

    /// <summary>
    /// Gets the value handler delegate for processing a raw store value.
    /// </summary>
    public Func<string, object?> ValueHandler { get; init; }

    /// <inheritdoc cref="IArgumentDescriptor.StoreType"/>
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
    /// <param name="kind">
    /// The store kind.
    /// </param>
    /// <returns>
    /// The corresponding value type.
    /// </returns>
    public static Type GetStoreType(ArgumentStoreKind kind) => kind switch
    {
        ArgumentStoreKind.Boolean => typeof(bool),
        ArgumentStoreKind.Integer => typeof(int),
        ArgumentStoreKind.Point   => typeof(float),
        ArgumentStoreKind.String  => typeof(string),
        ArgumentStoreKind.Char    => typeof(char),
        _ => typeof(bool)
    };
}