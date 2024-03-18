namespace BluDay.Net.Common.Exceptions;

public sealed class UnrecognizedArgumentException : Exception
{
    public UnrecognizedArgumentException(string flag)
        : base($"Unrecognized argument \"{flag}\" has not been registered.") { }
}