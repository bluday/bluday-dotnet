namespace BluDay.Net.Exceptions;

public sealed class InvalidArgumentFlagLengthException : Exception
{
    public InvalidArgumentFlagLengthException(string shortName, string longName)
        : base(ExceptionMessages.INVALID_LONG_ARGUMENT_FLAG_LENGTH.Format(longName, shortName)) { }
}