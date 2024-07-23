namespace BluDay.Net.Abstractions.UI.Windowing;

/// <summary>
/// Represents a window factory for creating windows of a concrete type.
/// </summary>
public sealed class WindowFactory<TWindow> : IWindowFactory<TWindow> where TWindow : IWindow
{
    public Type ConcreteTargetType { get; } = typeof(TWindow);

    /// <summary>
    /// Initializes a new instance of the <see cref="WindowFactory{TWindow}"/> class.
    /// </summary>
    public WindowFactory()
    {
        // TODO: Use reflection to analyze the constructor properties of the provided
        //       concrete target type, and create a factory---accepting an `object`
        //       array of values---to pass as parameters to the targeted constructor
        //       when instantiating a new window instance.
    }

    public TWindow Create()
    {
        throw new NotImplementedException();
    }

    public TWindow Create(WindowConfiguration config)
    {
        TWindow window = Create();

        window.Configure(config);

        return window;
    }

    public IWindow CreateImplicit()
    {
        return Create();
    }

    public IWindow CreateImplicit(WindowConfiguration config)
    {
        return Create(config);
    }
}