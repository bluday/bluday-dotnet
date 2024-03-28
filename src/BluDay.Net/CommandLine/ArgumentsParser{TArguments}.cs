namespace BluDay.Net.CommandLine;

public class ArgumentsParser<TArguments> where TArguments : new()
{
    private readonly IReadOnlyList<IArgumentDescriptor> _argumentDescriptors;

    public IReadOnlyList<IArgumentDescriptor> ArgumentDescriptors => _argumentDescriptors;

    public ArgumentsParser(IReadOnlyList<IArgumentDescriptor> argumentDescriptors)
    {
        _argumentDescriptors = argumentDescriptors;
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