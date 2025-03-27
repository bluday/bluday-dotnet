namespace BluDay.Net.Abstractions.UI.Navigation;

/// <summary>
/// Represents a navigation host responsible for managing navigation between child views
/// or viewmodels in the application's navigation hierarchy.
/// </summary>
public interface INavigationHost
{
    /// <summary>
    /// Gets the current active view being managed by the navigation host.
    /// </summary>
    INavigationAware? CurrentView { get; }

    /// <summary>
    /// Asynchronously navigates to a specified view, passing an optional view parameter.
    /// </summary>
    /// <param name="viewType">
    /// The type of the navigation-aware view to navigate to.
    /// </typeparam>
    /// <param name="parameter">
    /// An optional parameter containing data to be passed to the target view during
    /// navigation.
    /// </param>
    Task NavigateAsync(Type viewType, object? parameter);
}