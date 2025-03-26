namespace BluDay.Net.Abstractions.Navigation;

/// <summary>
/// Defines an interface for handling navigation events and their lifecycle stages with
/// asynchronous operations.
/// </summary>
/// <typeparam name="TParameter">
/// The type of parameter data passed during navigation, used for initialization or
/// contextual information.
/// </typeparam>
public interface INavigationAware<TParameter> where TParameter : class
{
    /// <summary>
    /// Asynchronously called after the object has been navigated away from. Typically
    /// used for cleanup or releasing resources associated with the view or viewmodel.
    /// </summary>
    Task OnNavigatedFromAsync();

    /// <summary>
    /// Asynchronously called after the object has been navigated to, providing optional 
    /// navigation parameters. Typically used for setting up the state or initializing
    /// data.
    /// </summary>
    /// <param name="parameter">
    /// An optional parameter containing data passed during navigation.
    /// </param>
    Task OnNavigatedToAsync(TParameter? parameter);

    /// <summary>
    /// Asynchronously called before the object is navigated away from. Allows for
    /// pre-navigation tasks such as validation, prompting the user, or performing
    /// cleanup operations.
    /// </summary>
    /// <returns>
    /// A task representing the asynchronous operation. Returns <c>true</c> if
    /// navigation can proceed; otherwise, <c>false</c>.
    /// </returns>
    Task<bool> OnNavigatingFromAsync();
}
