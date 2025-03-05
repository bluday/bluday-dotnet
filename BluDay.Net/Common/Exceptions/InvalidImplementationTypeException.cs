namespace BluDay.Net.Common.Exceptions;

public sealed class InvalidImplementationTypeException : Exception
{
    public InvalidImplementationTypeException(Type implementationType, Type serviceType) : base(
        string.Format(
            ExceptionMessages.INVALID_IMPLEMENTATION_TYPE,
            implementationType,
            serviceType
        )
    )
    { }
}