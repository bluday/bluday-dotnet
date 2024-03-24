namespace BluDay.Net.Common.Exceptions;

public sealed class ConflictingArgumentTargetPropertyException : Exception
{
    public ConflictingArgumentTargetPropertyException(Argument argument)
        : base(ExceptionMessages.CONFLICITNG_ARGUMENT_TARGET_PROPERTY.Format(argument)) { }
}