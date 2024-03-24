namespace BluDay.Net.Common.Exceptions;

public sealed class InvalidLongArgumentFlagLengthException : Exception
{
    public InvalidLongArgumentFlagLengthException(string longName, string shortName)
        : base(ExceptionMessages.INVALID_LONG_ARGUMENT_FLAG_LENGTH.Format(longName, shortName)) { }
}