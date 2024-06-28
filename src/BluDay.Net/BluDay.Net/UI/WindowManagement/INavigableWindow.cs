namespace BluDay.Net.UI.WindowManagement;

/// <summary>
/// Represents the control of a window.
/// </summary>
public interface INavigableWindow : IWindow
{
    /// <summary>
    /// Gets the navigator instance for handling view navigation within the window.
    /// </summary>
    IViewNavigator ViewNavigator { get; }
}