namespace BluDay.Net.Common.Exceptions;

public sealed class UnrecognizedArgumentFlagException : Exception
{
    public UnrecognizedArgumentFlagException(string value)
        : base(ExceptionMessages.UNRECOGNIZED_ARGUMENT_FLAG.Format(value)) { }
}