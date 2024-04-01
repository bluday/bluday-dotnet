namespace BluDay.Net.Services;

public sealed class AppWindowService : IAppWindowService
{
    private readonly IMessenger _messenger;

    private readonly HashSet<IWindow> _windows = new();

    public IWindow? MainWindow => _windows.FirstOrDefault();

    public int WindowCount => _windows.Count;

    public IEnumerable<IWindow> Windows => _windows;

    public AppWindowService(IMessenger messenger)
    {
        _messenger = messenger;
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