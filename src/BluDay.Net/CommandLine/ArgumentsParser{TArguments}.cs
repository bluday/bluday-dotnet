namespace BluDay.Net.CommandLine;

public class ArgumentsParser<TArguments> : ArgumentsParser where TArguments : new()
{
    public ArgumentsParser(IReadOnlyList<IArgument> arguments) : base(typeof(TArguments), arguments) { }

    public new TArguments Parse(string[] args)
    {
        return (TArguments)base.Parse(args);
    }
}