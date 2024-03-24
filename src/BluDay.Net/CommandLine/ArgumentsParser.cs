namespace BluDay.Net.CommandLine;

public class ArgumentsParser
{
    private readonly Type _resultType;

    private readonly IEnumerable<Argument> _arguments;

    public Type ResultType => _resultType;

    public IEnumerable<Argument> Arguments => _arguments;

    public ArgumentsParser(Type resultType, IEnumerable<Argument> arguments)
    {
        _arguments = arguments;

        _resultType = resultType;
    }

    internal static BindingFlags GetTargetPropertyBindingFlags()
    {
        return BindingFlags.DeclaredOnly
            | BindingFlags.Instance
            | BindingFlags.Public
            | BindingFlags.SetProperty;
    }

    public object Parse(string[] args)
    {
        throw new NotImplementedException();
    }

    public object ParseFromCommandLine()
    {
        string[] args = Environment.GetCommandLineArgs()[1..];

        return Parse(args);
    }
}