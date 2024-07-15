namespace BluDay.Net.Tests.Unit;

[TestClass]
public sealed class AppThemeServiceTests
{
    private readonly WeakReferenceMessenger _messenger = WeakReferenceMessenger.Default;

    [TestMethod]
    public void SetAndGetCurrentThemeExplicitly()
    {
        // Arrange.
        AppThemeService service = new(_messenger);

        // Act.
        service.CurrentTheme = AppTheme.Dark;

        // Assert.
        Assert.IsTrue(service.CurrentTheme is AppTheme.Dark);
    }

    [TestMethod]
    public void SetCurrentThemeAndReceiveUpdateMessage()
    {
        // Arrange.
        AppThemeService service = new(_messenger);

        AppTheme currentTheme = default;

        void MessageHandler(object sender, AppThemeChangedMessage e)
        {
            currentTheme = service.CurrentTheme;

            _messenger.Unregister<AppThemeChangedMessage>(this);
        }

        _messenger.Register<AppThemeChangedMessage>(this, MessageHandler);

        // Act.
        service.CurrentTheme = AppTheme.Dark;

        // Assert.
        Assert.IsTrue(currentTheme is AppTheme.Dark);
    }
}