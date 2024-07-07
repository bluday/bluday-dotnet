namespace BluDay.Net.Services;

public sealed class AppWindowService
{
    private readonly WeakReferenceMessenger _messenger;

    private readonly HashSet<IWindow> _windows;

    public IWindow? MainWindow => _windows.FirstOrDefault();

    public int WindowCount => _windows.Count;

    public IEnumerable<IWindow> Windows => _windows;

    public AppWindowService(WeakReferenceMessenger messenger)
    {
        _messenger = messenger;

        _windows = new HashSet<IWindow>();
    }

    public IWindow CreateWindow()
    {
        throw new NotImplementedException();
    }

    public bool HasWindow(IWindow window)
    {
        throw new NotImplementedException();
    }
}