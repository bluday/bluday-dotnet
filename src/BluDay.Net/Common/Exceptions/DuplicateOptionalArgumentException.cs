namespace BluDay.Net.Common.Exceptions;

public sealed class DuplicateOptionalArgumentException : Exception
{
    public DuplicateOptionalArgumentException(OptionalArgument argument)
        : base(ExceptionMessages.DUPLICATE_OPTIONAL_ARGUMENT.Format(argument)) { }
}