namespace BluDay.Net.Common.Exceptions;

public sealed class InvalidImplementationTypeException : Exception
{
    public InvalidImplementationTypeException(Type implementationType, Type serviceType)
        : base(ExceptionMessages.INVALID_IMPLEMENTATION_TYPE.Format(implementationType, serviceType)) { }
}