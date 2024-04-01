namespace BluDay.Net.Services;

public sealed class AppDialogService : IAppDialogService
{
    private readonly IMessenger _messenger;

    public AppDialogService(IMessenger messenger)
    {
        _messenger = messenger;
    }
}