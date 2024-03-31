namespace BluDay.Net.CommandLine;

public sealed class OptionalArgument : OptionalArgument<bool>
{
    public OptionalArgument(string flagDescriptor) : base(flagDescriptor) { }
}