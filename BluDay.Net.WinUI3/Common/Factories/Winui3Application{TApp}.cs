namespace BluDay.Net.Factories;

internal class Winui3Application
{
    [DllImport("Microsoft.UI.Xaml.dll")]
    internal static extern void XamlCheckProcessRequirements();
}

/// <summary>
/// Represents a factory for creating a WinUI 3 app using the derived application type
/// specified via the generic parameter.
/// </summary>
/// <typeparam name="TApp">
/// The derived <see cref="Application"/> type for the WinUI 3 app.
/// </typeparam>
public sealed class Winui3Application<TApp> where TApp : Application
{
    /// <summary>
    /// Creates an app instance of the <typeparamref name="TApp"/> type.
    /// </summary>
    /// <param name="postInitalizationCallback">
    /// The callback function for instantiating a <typeparamref name="TApp"/> instance in.
    /// </param>
    public static void Create(Func<TApp> postInitalizationCallback)
    {
        Winui3Application.XamlCheckProcessRequirements();

        WinRT.ComWrappersSupport.InitializeComWrappers();

        Application.Start(callback =>
        {
            DispatcherQueueSynchronizationContext context = new(DispatcherQueue.GetForCurrentThread());

            SynchronizationContext.SetSynchronizationContext(context);

            postInitalizationCallback();
        });
    }
}