namespace BluDay.Net.CommandLine;

public abstract class Argument : IArgument
{
    private readonly ArgumentActionKind _actionKind;

    private readonly ArgumentStoreKind _storeKind;

    private readonly object? _constant;

    private readonly object? _defaultValue;

    public ArgumentActionKind ActionKind
    {
        get => _actionKind;
        init
        {
            _actionKind = value;
        }
    }

    public ArgumentStoreKind StoreKind
    {
        get => _storeKind;
        init
        {
            _storeKind = value;
        }
    }

    public bool IsRequired { get; init; }

    public object? Constant
    {
        get => _constant;
        init
        {
            _constant = value;
        }
    }

    public object? DefaultValue
    {
        get => _defaultValue;
        init
        {
            _defaultValue = value;
        }
    }

    public string? Description { get; init; }

    public string? Name { get; protected set; }

    public int MaxValueCount { get; init; }

    public Func<string, object?> ValueHandler { get; init; }

    public Argument()
    {
        ValueHandler = null!;
    }

    private void ValidateStoreValue(object value)
    {
        if (value.GetType() != GetStoreValueType(_storeKind))
        {
            throw new InvalidOperationException();
        }
    }

    public static Type GetStoreValueType(ArgumentStoreKind kind)
    {
        switch (kind)
        {
            case ArgumentStoreKind.Integer: return typeof(int);
            case ArgumentStoreKind.Point:   return typeof(float);
            case ArgumentStoreKind.String:  return typeof(string);
            case ArgumentStoreKind.Char:    return typeof(char);
        }

        return typeof(bool);
    }
}