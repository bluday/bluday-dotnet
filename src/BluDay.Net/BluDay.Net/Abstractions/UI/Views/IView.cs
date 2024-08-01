namespace BluDay.Net.UI.Views;

/// <summary>
/// Represents a view control.
/// </summary>
public interface IView
{
    /// <summary>
    /// Gets the view model instance for the view.
    /// </summary>
    IViewModel? ViewModel { get; }

    /// <summary>
    /// Gets the id of the window the view control instance belongs to.
    /// </summary>
    Guid? WindowId { get; }
}