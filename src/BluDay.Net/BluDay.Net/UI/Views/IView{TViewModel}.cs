namespace BluDay.Net.UI.Views;

/// <summary>
/// Represents a view control.
/// </summary>
public interface IView<TViewModel> : IView where TViewModel : IViewModel
{
    /// <summary>
    /// Gets the view model instance for the view.
    /// </summary>
    TViewModel ViewModel { get; }
}