namespace BluDay.Net.WPF;

/// <summary>
/// Represents a factory for creating a Windows Presentation Foundation (WPF) app
/// using the derived application type specified via the generic parameter.
/// </summary>
public sealed class WpfApplication
{
    /// <summary>
    /// Creates an app instance of the <typeparamref name="TApp"/> type.
    /// </summary>
    /// <param name="factory">
    /// An <typeparamref name="TApp"/> instance factory.
    /// </param>
    public static Thread Create<TApp>(Func<TApp> factory) where TApp : Application
    {
        Thread thread = new(() => factory().Run());

        thread.TrySetApartmentState(ApartmentState.STA);

        thread.Start();
        
        return thread;
    }
}