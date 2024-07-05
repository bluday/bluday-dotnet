namespace BluDay.Net.Common.Attributes;

/// <summary>
/// Specifies which viewmodel type to use.
/// </summary>
public sealed class ViewModelAttribute : Attribute
{
    /// <summary>
    /// Gets the targeted viewmodel type.
    /// </summary>
    public Type ViewModelType { get; }

    /// <summary>
    /// Initializes a new instance with the provided viewmodel type.
    /// </summary>
    /// <param name="viewModelType">The targeted viewmodel type.</param>
    /// <exception cref="ArgumentNullException">If the viewmodel type is null or invalid.</exception>
    public ViewModelAttribute(Type viewModelType)
    {
        ArgumentNullException.ThrowIfNull(viewModelType);

        if (!viewModelType.IsAssignableTo(typeof(IViewModel)))
        {
            throw new ArgumentException(ExceptionMessages.INVALID_VIEWMODEL_TYPE);
        }

        ViewModelType = viewModelType;
    }
}