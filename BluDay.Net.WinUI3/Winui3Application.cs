namespace BluDay.Net.WinUI3;

/// <summary>
/// Represents a factory for creating a WinUI 3 app using the derived application type specified via
/// the generic parameter.
/// </summary>
public sealed class Winui3Application
{
    [DllImport("Microsoft.UI.Xaml.dll")]
    internal static extern void XamlCheckProcessRequirements();

    /// <summary>
    /// Creates an app instance of the <typeparamref name="TApp"/> type asynchronously.
    /// </summary>
    /// <param name="factory">
    /// An <typeparamref name="TApp"/> instance factory.
    /// </param>
    /// <returns>
    /// A task that represents the asynchronous creation of the <typeparamref name="TApp"/> instance.
    /// </returns>
    /// <exception cref="ArgumentNullException">
    /// Throws if <paramref name="factory"/> is null.
    /// </exception>
    public static Task<TApp> CreateAsync<TApp>(Func<TApp> factory) where TApp : Application
    {
        ArgumentNullException.ThrowIfNull(factory);

        XamlCheckProcessRequirements();

        WinRT.ComWrappersSupport.InitializeComWrappers();

        TaskCompletionSource<TApp> taskCompletionSource = new();

        Application.Start(_ =>
        {
            try
            {
                DispatcherQueueSynchronizationContext context = new(DispatcherQueue.GetForCurrentThread());

                SynchronizationContext.SetSynchronizationContext(context);

                taskCompletionSource.SetResult(factory());
            }
            catch (Exception exception)
            {
                taskCompletionSource.SetException(exception);
            }
        });

        return taskCompletionSource.Task;
    }
}