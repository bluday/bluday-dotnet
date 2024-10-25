namespace BluDay.Net.WinUI3;

/// <summary>
/// Represents a factory for creating a WinUI 3 app using the derived application
/// type specified via the generic parameter.
/// </summary>
public sealed class Winui3Application
{
    [DllImport("Microsoft.UI.Xaml.dll")]
    internal static extern void XamlCheckProcessRequirements();

    /// <summary>
    /// Creates an app instance of the <typeparamref name="TApp"/> type.
    /// </summary>
    /// <param name="factory">
    /// An <typeparamref name="TApp"/> instance factory.
    /// </param>
    public static void Create<TApp>(Func<TApp> factory) where TApp : Application
    {
        ArgumentNullException.ThrowIfNull(factory);

        XamlCheckProcessRequirements();

        WinRT.ComWrappersSupport.InitializeComWrappers();

        Application.Start(callback =>
        {
            DispatcherQueueSynchronizationContext context = new(DispatcherQueue.GetForCurrentThread());

            SynchronizationContext.SetSynchronizationContext(context);

            factory();
        });
    }
}