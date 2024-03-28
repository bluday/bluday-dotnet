namespace BluDay.Net.CommandLine;

public class ArgumentsParser<TArguments> where TArguments : new()
{
    private PositionalArgumentDescriptor? _positionalArgumentDescriptor;

    private readonly HashSet<OptionalArgumentDescriptor> _optionalArgumentDescriptors;

    public PositionalArgumentDescriptor? PositionalArgumentDescriptor
    {
        get => _positionalArgumentDescriptor;
    }

    public IReadOnlyList<OptionalArgumentDescriptor> OptionalArgumentDescriptors
    {
        get => _optionalArgumentDescriptors.ToList().AsReadOnly();
    }

    public ArgumentsParser()
    {
        _optionalArgumentDescriptors = new();
    }

    internal static BindingFlags GetTargetPropertyReflectionBindingFlags()
    {
        return BindingFlags.DeclaredOnly
            | BindingFlags.Instance
            | BindingFlags.Public
            | BindingFlags.SetProperty;
    }

    public void AddOptionalArgument(OptionalArgumentDescriptor descriptor)
    {
        ArgumentNullException.ThrowIfNull(descriptor);

        if (!_optionalArgumentDescriptors.Add(descriptor))
        {
            throw new DuplicateOptionalArgumentException(descriptor);
        }
    }

    public void AddOptionalArguments(params OptionalArgumentDescriptor[] descriptors)
    {
        foreach (var descriptor in descriptors)
        {
            AddOptionalArgument(descriptor);
        }
    }

    public void AddPositionalArgument()
    {
        if (_positionalArgumentDescriptor is null)
        {
            _positionalArgumentDescriptor = new();
        }
    }

    public TArguments Parse(string[] args)
    {
        throw new NotImplementedException();
    }
}