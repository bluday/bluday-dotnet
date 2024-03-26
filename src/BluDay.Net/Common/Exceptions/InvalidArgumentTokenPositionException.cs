namespace BluDay.Net.Common.Exceptions;

public sealed class InvalidArgumentTokenPositionException : Exception
{
    public InvalidArgumentTokenPositionException(string token)
        : base(ExceptionMessages.INVALID_ARGUMENT_TOKEN_POSITION.Format(token)) { }
}