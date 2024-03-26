namespace BluDay.Net.CommandLine;

public class ArgumentsParser<TArguments> where TArguments : new()
{
    private readonly IReadOnlyList<IArgument> _arguments;

    public IReadOnlyList<IArgument> Arguments => _arguments;

    public ArgumentsParser(IReadOnlyList<IArgument> arguments)
    {
        _arguments = arguments;
    }

    internal static BindingFlags GetTargetPropertyReflectionBindingFlags()
    {
        return BindingFlags.DeclaredOnly
            | BindingFlags.Instance
            | BindingFlags.Public
            | BindingFlags.SetProperty;
    }

    public TArguments Parse(IReadOnlyList<string> args)
    {
        throw new NotImplementedException();
    }
}