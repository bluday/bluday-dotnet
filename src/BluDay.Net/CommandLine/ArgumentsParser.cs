namespace BluDay.Net.CommandLine;

public class ArgumentsParser
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

    public object Parse(Type objectType, string[] args)
    {
        throw new NotImplementedException();
    }
}