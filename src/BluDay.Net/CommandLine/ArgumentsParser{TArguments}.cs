namespace BluDay.Net.CommandLine;

public class ArgumentsParser<TArguments> where TArguments : new()
{
    private PositionalArgumentDescriptor? _positionalArgument;

    private readonly HashSet<OptionalArgumentDescriptor> _optionalArguments = new();

    public bool HasPositionalArgument
    {
        get => _positionalArgument is not null;
    }

    public IReadOnlyList<OptionalArgumentDescriptor> OptionalArguments
    {
        get => _optionalArguments.ToList().AsReadOnly();
    }

    internal static BindingFlags GetTargetPropertyReflectionBindingFlags()
    {
        return BindingFlags.DeclaredOnly
            | BindingFlags.Instance
            | BindingFlags.Public
            | BindingFlags.SetProperty;
    }

    public void AddOptionalArgument(OptionalArgumentDescriptor argument)
    {
        ArgumentNullException.ThrowIfNull(argument);

        if (!_optionalArguments.Add(argument))
        {
            throw new InvalidOperationException();
        }
    }

    public void AddOptionalArguments(params OptionalArgumentDescriptor[] arguments)
    {
        foreach (var argument in arguments)
        {
            AddOptionalArgument(argument);
        }
    }

    public void AddPositionalArgument()
    {
        if (HasPositionalArgument) return;

        _positionalArgument = new();
    }

    public TArguments Parse(string[] args)
    {
        throw new NotImplementedException();
    }
}