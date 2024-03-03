namespace BluDay.Net.Exceptions;

public sealed class InvalidArgumentFlagException : Exception
{
    public InvalidArgumentFlagException(string flag, string message) : base(message) { }
}