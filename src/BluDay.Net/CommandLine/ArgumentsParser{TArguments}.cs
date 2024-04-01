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

    public ArgumentsParser()
    {
        _positionalArgument = CreatePositional();

        _optionalArguments = CreateOptionals().Distinct().ToImmutableList();
    }

    protected virtual PositionalArgument? CreatePositional()
    {
        return null;
    }

    protected virtual IEnumerable<OptionalArgument> CreateOptionals()
    {
        yield break;
    }

    public TArguments Parse(params string[] values)
    {
        throw new NotImplementedException();
    }

    public TArguments ParseFromCommandLine()
    {
        return Parse(Environment.GetCommandLineArgs());
    }
}