namespace BluDay.Net.Services;

public sealed class AppWindowService : IAppWindowService
{
    private readonly IMessenger _messenger;

    private readonly HashSet<IWindow> _windows;

    public IWindow? MainWindow => _windows.FirstOrDefault();

    public int WindowCount => _windows.Count;

    public IImmutableList<IWindow> Windows => _windows.ToImmutableList();

    public AppWindowService(IMessenger messenger)
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