namespace BluDay.Net.CommandLine;

public interface IPositionalArgument : IArgument
{
    string Symbol { get; }
}