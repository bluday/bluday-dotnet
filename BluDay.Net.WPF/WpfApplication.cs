namespace BluDay.Net.WPF;

/// <summary>
/// Represents a factory for creating a Windows Presentation Foundation (WPF) app using the derived
/// application type specified via the generic parameter.
/// </summary>
public sealed class WpfApplication
{
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

        TaskCompletionSource<TApp> taskCompletionSource = new();

        Thread thread = new(() =>
        {
            try
            {
                TApp app = factory();

                taskCompletionSource.SetResult(app);

                app.Run();
            }
            catch (Exception exception)
            {
                taskCompletionSource.SetException(exception);
            }
        });

        thread.TrySetApartmentState(ApartmentState.STA);
        thread.Start();

        return taskCompletionSource.Task;
    }
}