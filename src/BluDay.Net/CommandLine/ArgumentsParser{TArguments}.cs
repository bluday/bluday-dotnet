namespace BluDay.Net.CommandLine;

public class ArgumentsParser<TArguments> where TArguments : new()
{
    private readonly PositionalArgument? _positionalArgument;

    private readonly IImmutableList<OptionalArgument> _optionalArguments;

    public PositionalArgument? PositionalArgument
    {
        get  => _positionalArgument;
        init => _positionalArgument = value;
    }

    [DisallowNull]
    public IImmutableList<OptionalArgument> OptionalArguments
    {
        get  => _optionalArguments;
        init => _optionalArguments = value.Distinct().ToImmutableList();
    }

    public ArgumentsParser()
    {
        _optionalArguments = ImmutableList<OptionalArgument>.Empty;
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