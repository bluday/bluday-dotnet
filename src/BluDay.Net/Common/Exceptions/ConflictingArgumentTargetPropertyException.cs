namespace BluDay.Net.Common.Exceptions;

public sealed class ConflictingArgumentTargetPropertyException : Exception
{
    public ConflictingArgumentTargetPropertyException(PropertyInfo property)
        : base(ExceptionMessages.CONFLICITNG_ARGUMENT_TARGET_PROPERTY.Format(property)) { }
}