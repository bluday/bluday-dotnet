namespace BluDay.Net.Attributes;

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
    /// <exception cref="ArgumentNullException">If the viewmodel type is null.</exception>
    public ViewModelAttribute(Type viewModelType)
    {
        ArgumentNullException.ThrowIfNull(viewModelType);

        ViewModelType = viewModelType;
    }
}