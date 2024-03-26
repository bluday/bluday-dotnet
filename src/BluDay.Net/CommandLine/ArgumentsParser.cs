namespace BluDay.Net.CommandLine;

public class ArgumentsParser
{
    private readonly Type _resultType;

    private readonly IReadOnlyList<IArgument> _arguments;

    public Type ResultType => _resultType;

    public IReadOnlyList<IArgument> Arguments => _arguments;

    public ArgumentsParser(Type resultType, IReadOnlyList<IArgument> arguments)
    {
        _arguments = arguments;

        _resultType = resultType;
    }

    internal static BindingFlags GetPropertyReflectionBindingFlags()
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