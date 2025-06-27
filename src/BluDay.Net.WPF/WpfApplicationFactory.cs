using System.Windows;

namespace BluDay.Net.WPF;

/// <summary>
/// Provides a factory for creating and launching WPF application instances on a dedicated STA
/// thread.
/// </summary>
public sealed class WpfApplicationFactory
{
    /// <summary>
    /// Creates and runs a WPF application instance using the provided factory delegate.
    /// </summary>
    /// <typeparam name="TApp">
    /// The type of WPF application to create. Must inherit from <see cref="Application"/>.
    /// </typeparam>
    /// <param name="factory">
    /// A delegate that constructs the application instance of type <typeparamref name="TApp"/>.
    /// </param>
    /// <returns>
    /// The created instance of <typeparamref name="TApp"/>, after its execution has been
    /// dispatched to a separate thread.
    /// </returns>
    public TApp Create<TApp>(Func<TApp> factory) where TApp : Application
    {
        TApp app = null!;

        Thread thread = new(() => (app = factory()).Run());

        thread.SetApartmentState(ApartmentState.STA);
        thread.Start();

        return app;
    }
}