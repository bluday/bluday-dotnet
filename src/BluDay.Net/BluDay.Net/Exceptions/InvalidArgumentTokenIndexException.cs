namespace BluDay.Net.Exceptions;

public sealed class InvalidArgumentTokenIndexException : Exception
{
    public InvalidArgumentTokenIndexException(string token)
        : base(string.Format(ExceptionMessages.INVALID_ARGUMENT_TOKEN_INDEX, token)) { }
}