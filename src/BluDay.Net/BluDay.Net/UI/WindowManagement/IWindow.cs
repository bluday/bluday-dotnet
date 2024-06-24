namespace BluDay.Net.UI.WindowManagement;

/// <summary>
/// Represents the control of a window.
/// </summary>
public interface IWindow
{
    /// <summary>
    /// Activates and shows the current window.
    /// </summary>
    void Activate();

    /// <summary>
    /// Closes the current window.
    /// </summary>
    void Close();
}