namespace BluDay.Net.Exceptions;

public sealed class ConflictingArgumentTargetPropertyException : Exception
{
    public ConflictingArgumentTargetPropertyException(PropertyInfo property) : base(
        string.Format(
            ExceptionMessages.CONFLICITNG_ARGUMENT_TARGET_PROPERTY,
            property
        )
    )
    { }
}