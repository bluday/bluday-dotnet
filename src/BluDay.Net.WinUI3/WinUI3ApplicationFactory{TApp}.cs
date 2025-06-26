using Microsoft.UI.Dispatching;
using Microsoft.UI.Xaml;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace BluDay.Net.WinUI3;

/// <summary>
/// Represents a WinUI 3 application factory.
/// </summary>
/// <typeparam name="TApp">
/// The derived <see cref="Application"/> type.
/// </typeparam>
public sealed class WinUI3ApplicationFactory<TApp> where TApp : Application
{
    /// <summary>
    /// Creates the application instance.
    /// </summary>
    /// <param name="factory">
    /// A factory for the derived application type.
    /// </param>
    [STAThread]
    public Task<TApp> CreateAsync(Func<TApp> factory)
    {
        TaskCompletionSource<TApp> taskCompletionSource = new();

        WinRT.ComWrappersSupport.InitializeComWrappers();

        Application.Start(_ =>
        {
            DispatcherQueueSynchronizationContext context = new(DispatcherQueue.GetForCurrentThread());

            SynchronizationContext.SetSynchronizationContext(context);

            try
            {
                taskCompletionSource.SetResult(factory());
            }
            catch (Exception ex)
            {
                taskCompletionSource.SetException(ex);
            }
        });

        return taskCompletionSource.Task;
    }
}