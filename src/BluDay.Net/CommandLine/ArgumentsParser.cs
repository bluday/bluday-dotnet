namespace BluDay.Net.CommandLine;

public class ArgumentsParser
{
    private readonly PositionalArgument? _positionalArgument;

    private readonly IImmutableList<OptionalArgument> _optionalArguments;

    private readonly Type _resultType;

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

    public ArgumentsParser(Type resultType)
    {
        ArgumentNullException.ThrowIfNull(resultType);

        _optionalArguments = ImmutableList<OptionalArgument>.Empty;

        _resultType = resultType;
    }

    internal static BindingFlags GetTargetPropertyReflectionBindingFlags()
    {
        return BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public;
    }

    public object Parse(string[] args)
    {
        throw new NotImplementedException();
    }

    public object ParseFromCommandLine()
    {
        return Parse(Environment.GetCommandLineArgs());
    }
}