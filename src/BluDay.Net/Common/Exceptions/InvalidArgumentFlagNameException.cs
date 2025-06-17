namespace BluDay.Net.Common.Exceptions;

public sealed class InvalidArgumentFlagNameException : Exception
{
    public InvalidArgumentFlagNameException(string value)
        : base(string.Format(ExceptionMessages.INVALID_ARGUMENT_FLAG_NAME, value)) { }
}