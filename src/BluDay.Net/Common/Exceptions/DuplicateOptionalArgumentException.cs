namespace BluDay.Net.Common.Exceptions;

public sealed class DuplicateOptionalArgumentException : Exception
{
    public DuplicateOptionalArgumentException(IOptionalArgument argument)
        : base(ExceptionMessages.DUPLICATE_OPTIONAL_ARGUMENT.Format(argument)) { }
}