namespace BluDay.Net.CommandLine;

public class ArgumentsParser<TArguments> : ArgumentsParser where TArguments : new()
{
    public ArgumentsParser() : base(typeof(TArguments)) { }

    public new TArguments Parse(string[] args)
    {
        return (TArguments)base.Parse(args);
    }

    public new TArguments ParseFromCommandLine()
    {
        return Parse(Environment.GetCommandLineArgs());
    }
}