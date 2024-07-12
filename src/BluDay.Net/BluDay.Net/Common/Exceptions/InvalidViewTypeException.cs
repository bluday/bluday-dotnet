namespace BluDay.Net.Common.Exceptions;

/// <summary>
/// Represents an exception for invalid view types.
/// </summary>
public sealed class InvalidViewTypeException : Exception
{
    /// <summary>
    /// Initializes a new instance of the <see cref="InvalidViewTypeException"/> class.
    /// </summary>
    /// <param name="value">The invalid view type.</param>
    public InvalidViewTypeException(Type value)
        : base(string.Format(ExceptionMessages.INVALID_VIEW_TYPE, value)) { }

    /// <summary>
    /// Validates the provided view type.
    /// </summary>
    /// <param name="value">The view type.</param>
    /// <exception cref="InvalidViewTypeException">
    /// If the view type is null or not of type <see cref="IView"/>.
    /// </exception>
    public static void ThrowIfInvalid(Type value)
    {
        ArgumentNullException.ThrowIfNull(value);

        if (!value.IsAssignableTo(typeof(IView)))
        {
            throw new InvalidViewTypeException(value);
        }
    }
}