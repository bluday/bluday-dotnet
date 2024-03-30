namespace BluDay.Net.CommandLine;

public class ArgumentsParser<TArguments> where TArguments : new()
{
    private readonly PositionalArgument? _positionalArgument;

    private readonly IReadOnlyList<OptionalArgument> _optionalArguments;

    public PositionalArgument? PositionalArgument => _positionalArgument;

    public IReadOnlyList<OptionalArgument> OptionalArguments => _optionalArguments;

    public ArgumentsParser(OptionalArgument[]? optionalArguments, PositionalArgument? positionalArgument)
    {
        ArgumentNullException.ThrowIfNull(optionalArguments);

        _positionalArgument = positionalArgument;

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