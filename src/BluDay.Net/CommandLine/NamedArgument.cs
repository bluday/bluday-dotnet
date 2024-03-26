namespace BluDay.Net.CommandLine;

public sealed class NamedArgument : Argument
{
    public ArgumentFlag? ShortFlag { get; }

    public ArgumentFlag? LongFlag { get; }

    public NamedArgument(string flagDescriptor)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(flagDescriptor);

        // TODO: Parse flag descriptor string and create short and long flag instances.
    }
}