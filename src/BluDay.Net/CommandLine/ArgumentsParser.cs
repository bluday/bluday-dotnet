namespace BluDay.Net.CommandLine;

public sealed class ArgumentsParser
{
    private readonly IEnumerable<Argument> _arguments;

    internal static readonly BindingFlags _propertyBindingFlags;

    public IEnumerable<Argument> Arguments => _arguments;

    static ArgumentsParser()
    {
        _propertyBindingFlags = BindingFlags.DeclaredOnly
            | BindingFlags.Instance
            | BindingFlags.Public
            | BindingFlags.SetProperty;
    }

    public ArgumentsParser(IEnumerable<Argument> arguments)
    {
        _arguments = arguments;
    }

    public TArguments Parse<TArguments>(string[] args) where TArguments : new()
    {
        return (TArguments)Parse(args);
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