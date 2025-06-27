using Microsoft.UI.Dispatching;
using Microsoft.UI.Xaml;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace BluDay.Net.WinUI3;

/// <summary>
/// Provides a factory for creating and initializing WinUI 3 application instances.
/// </summary>
public sealed class WinUI3ApplicationFactory
{
    /// <summary>
    /// Asynchronously creates and launches a WinUI 3 application instance using the specified
    /// factory delegate.
    /// </summary>
    /// <typeparam name="TApp">
    /// The type of application to create. Must inherit from <see cref="Application"/>.
    /// </typeparam>
    /// <param name="factory">
    /// A delegate that constructs the application instance of type <typeparamref name="TApp"/>.
    /// </param>
    /// <returns>
    /// A task that completes with the created <typeparamref name="TApp"/> instance if successful,
    /// or completes with an exception if an error occurs during startup.
    /// </returns>
    [STAThread]
    public Task<TApp> CreateAsync<TApp>(Func<TApp> factory) where TApp : Application
    {
        TaskCompletionSource<TApp> taskCompletionSource = new();

        WinRT.ComWrappersSupport.InitializeComWrappers();

        Application.Start(_ =>
        {
            SynchronizationContext.SetSynchronizationContext(
                new DispatcherQueueSynchronizationContext(DispatcherQueue.GetForCurrentThread())
            );

            try
            {
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