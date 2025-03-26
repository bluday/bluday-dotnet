namespace BluDay.Net.Abstractions.Navigation;

/// <summary>
/// Defines an interface for handling navigation events and their lifecycle stages.
/// </summary>
public interface INavigationAware
{
    /// <summary>
    /// Called after the object has been navigated away from. Typically used for
    /// cleanup or finalization tasks.
    /// </summary>
    void OnNavigatedFrom();

    /// <summary>
    /// Called before the object is navigated away from. Allows for validation, user
    /// prompts, or cancellation of navigation.
    /// </summary>
    /// <returns>
    /// <c>true</c> if navigation can proceed; otherwise, <c>false</c>.
    /// </returns>
    bool OnNavigatingFrom();

    /// <summary>
    /// Called after the object has been navigated to, with optional navigation
    /// parameters provided. Typically used for initialization or setting up state.
    /// </summary>
    /// <param name="parameter">
    /// An optional parameter containing data passed during navigation.
    /// </param>
    void OnNavigatedTo(object? parameter);
}