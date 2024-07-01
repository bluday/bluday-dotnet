namespace BluDay.Net.Exceptions;

/// <summary>
/// Represents an exception for invalid view model types.
/// </summary>
public sealed class InvalidViewModelTypeException : Exception
{
    /// <summary>
    /// Initializes a new instance of the <see cref="InvalidViewModelTypeException"/> class.
    /// </summary>
    /// <param name="value">The invalid view model type.</param>
    public InvalidViewModelTypeException(Type value)
        : base(string.Format(ExceptionMessages.INVALID_VIEWMODEL_TYPE, value)) { }

    /// <summary>
    /// Validates the provided view model type.
    /// </summary>
    /// <param name="value">The view model type.</param>
    /// <exception cref="InvalidViewModelTypeException">
    /// If the view model type is null or not of type <see cref="ViewModel"/>.
    /// </exception>
    public static void ThrowIfInvalid(Type value)
    {
        ArgumentNullException.ThrowIfNull(value);

        if (value.IsAssignableFrom(typeof(ViewModel)))
        {
            throw new InvalidViewModelTypeException(value);
        }
    }
}