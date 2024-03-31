namespace BluDay.Net.CommandLine;

public interface IOptionalArgument : IArgument
{
    ArgumentFlag PrimaryFlag { get; }

    ArgumentFlag? LongFlag { get; }

    ArgumentFlag? ShortFlag { get; }
}