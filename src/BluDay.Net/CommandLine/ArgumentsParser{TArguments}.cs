namespace BluDay.Net.CommandLine;

public class ArgumentsParser<TArguments> where TArguments : new()
{
    private readonly PositionalArgument? _positionalArgument;

    private readonly IImmutableList<OptionalArgument> _optionalArguments;

    public PositionalArgument? PositionalArgument
    {
        get => _positionalArgument;
    }

    public IImmutableList<OptionalArgument> OptionalArguments
    {
        get => _optionalArguments;
    }

    public ArgumentsParser(PositionalArgument? positionalArgument) : this([], positionalArgument) { }

    public ArgumentsParser(IImmutableList<OptionalArgument> optionalArguments) : this(optionalArguments, null) { }

    public ArgumentsParser(IImmutableList<OptionalArgument> optionalArguments, PositionalArgument? positionalArgument)
    {
        _optionalArguments = optionalArguments.Distinct().ToImmutableList();

        _positionalArgument = positionalArgument;
    }

    internal static BindingFlags GetTargetPropertyReflectionBindingFlags()
    {
        return BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public;
    }

    public TArguments Parse(string[] args)
    {
        throw new NotImplementedException();
    }

    public TArguments ParseFromCommandLine()
    {
        return Parse(Environment.GetCommandLineArgs());
    }
}