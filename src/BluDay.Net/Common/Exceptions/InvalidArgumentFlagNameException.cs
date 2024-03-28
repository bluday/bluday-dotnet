namespace BluDay.Net.Common.Exceptions;

public sealed class InvalidArgumentFlagNameException : Exception
{
    public InvalidArgumentFlagNameException(string value)
        : base(ExceptionMessages.INVALID_ARGUMENT_FLAG_NAME.Format(value)) { }

    public static void ThrowIfInvalid(string value)
    {
        if (!ArgumentFlag.HasValidName(value))
        {
            throw new InvalidArgumentFlagNameException(value);
        }
    }
}