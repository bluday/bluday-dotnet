namespace BluDay.Net.Exceptions;

public sealed class InvalidArgumentFlagLengthException : Exception
{
    public InvalidArgumentFlagLengthException(string shortName, string longName) : base(
        string.Format(
            ExceptionMessages.INVALID_LONG_ARGUMENT_FLAG_LENGTH,
            longName,
            shortName
        )
    )
    { }
}