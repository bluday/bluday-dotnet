namespace BluDay.Net.Common.Exceptions;

public sealed class DuplicateOptionalArgumentException : Exception
{
    public DuplicateOptionalArgumentException(OptionalArgumentDescriptor descriptor)
        : base(ExceptionMessages.DUPLICATE_OPTIONAL_ARGUMENT.Format(descriptor)) { }
}