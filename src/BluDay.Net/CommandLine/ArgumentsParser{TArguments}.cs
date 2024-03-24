namespace BluDay.Net.CommandLine;

public class ArgumentsParser<TArguments> : ArgumentsParser where TArguments : new()
{
    public ArgumentsParser(IEnumerable<Argument> arguments) : base(typeof(TArguments), arguments) { }

    public new TArguments Parse(string[] args)
    {
        return (TArguments)base.Parse(args);
    }

    public new TArguments ParseFromCommandLine()
    {
        return (TArguments)base.ParseFromCommandLine();
    }
}