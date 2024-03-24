namespace BluDay.Net.CommandLine;

public class ArgumentsParser
{
    private readonly IEnumerable<Argument> _arguments;

    public IEnumerable<Argument> Arguments => _arguments;

    public ArgumentsParser(IEnumerable<Argument> arguments)
    {
        _arguments = arguments;
    }

    internal static BindingFlags GetTargetPropertyBindingFlags()
    {
        return BindingFlags.DeclaredOnly
            | BindingFlags.Instance
            | BindingFlags.Public
            | BindingFlags.SetProperty;
    }

    public object Parse(Type objectType, string[] args)
    {
        throw new NotImplementedException();
    }

    public object ParseFromCommandLine(Type objectType)
    {
        string[] args = Environment.GetCommandLineArgs()[1..];

        return Parse(objectType, args);
    }
}