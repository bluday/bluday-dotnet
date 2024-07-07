namespace BluDay.Net.Services;

public sealed class AppDialogService
{
    private readonly WeakReferenceMessenger _messenger;

    public AppDialogService(WeakReferenceMessenger messenger)
    {
        _messenger = messenger;
    }
}