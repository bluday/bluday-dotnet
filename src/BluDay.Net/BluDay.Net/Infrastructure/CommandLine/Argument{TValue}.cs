namespace BluDay.Net.CommandLine;

/// <summary>
/// Base class for creating command-line argument classes.
/// </summary>
public abstract class Argument : IArgument
{
    private readonly ArgumentActionKind _actionKind;

    private readonly ArgumentStoreKind _storeKind;

    private readonly object? _constant;

    private readonly object? _defaultValue;

    /// <summary>
    /// <inheritdoc cref="IArgument.ActionKind"/>
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
    /// <inheritdoc cref="IArgument.StoreKind"/>
    /// </summary>
    public ArgumentStoreKind StoreKind
    {
        get => _storeKind;
        init
        {
            // TODO: Reset invalid constant and default value.

            _storeKind = value;
        }
    }

    /// <summary>
    /// <inheritdoc cref="IArgument.IsRequired"/>
    /// </summary>
    public bool IsRequired { get; init; }

    /// <summary>
    /// <inheritdoc cref="IArgument.Constant"/>
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
    /// <inheritdoc cref="IArgument.DefaultValue"/>
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
    /// <inheritdoc cref="IArgument.Description"/>
    /// </summary>
    public string? Description { get; init; }

    /// <summary>
    /// <inheritdoc cref="IArgument.Name"/>
    /// </summary>
    public string? Name { get; protected set; }

    /// <summary>
    /// <inheritdoc cref="IArgument.MaxValueCount"/>
    /// </summary>
    public int MaxValueCount { get; init; }

    /// <summary>
    /// Gets the value handler delegate for processing a raw store value.
    /// </summary>
    public Func<string, object?> ValueHandler { get; init; }

    /// <summary>
    /// <inheritdoc cref="IArgument.StoreType"/>
    /// </summary>
    public Type StoreType
    {
        get => _storeKind switch
        {
            ArgumentStoreKind.Boolean => typeof(bool),
            ArgumentStoreKind.Integer => typeof(int),
            ArgumentStoreKind.Point   => typeof(float),
            ArgumentStoreKind.String  => typeof(string),
            ArgumentStoreKind.Char    => typeof(char),
            _ => typeof(bool)
        };
    }

    public Argument()
    {
        ValueHandler = null!;
    }
}