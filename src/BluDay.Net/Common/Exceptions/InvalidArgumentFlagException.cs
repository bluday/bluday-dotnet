namespace BluDay.Net.Common.Exceptions;

public sealed class InvalidArgumentFlagException : Exception
{
    public InvalidArgumentFlagException(string flag, string message) : base(message) { }
}