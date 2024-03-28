namespace BluDay.Net.CommandLine;

public class ArgumentsParser<TArguments> where TArguments : new()
{
    private PositionalArgumentDescriptor? _positionalArgument;

    private readonly IReadOnlyList<OptionalArgumentDescriptor> _optionalArguments;

    public IReadOnlyList<OptionalArgumentDescriptor> OptionalArguments
    {
        get => _optionalArguments;
    }

    public ArgumentsParser(IReadOnlyList<OptionalArgumentDescriptor> optionalArguments)
    {
        _optionalArguments = optionalArguments
            .Distinct()
            .ToList()
            .AsReadOnly();
    }

    internal static BindingFlags GetTargetPropertyReflectionBindingFlags()
    {
        return BindingFlags.DeclaredOnly
            | BindingFlags.Instance
            | BindingFlags.Public
            | BindingFlags.SetProperty;
    }

    public TArguments Parse(string[] args)
    {
        throw new NotImplementedException();
    }
}