namespace BluDay.Net.Tests.Unit;

// TODO: Use a mocked messenger class instead of an actual instance.
[TestClass]
public sealed class AppThemeServiceTests
{
    private readonly WeakReferenceMessenger _messenger = WeakReferenceMessenger.Default;

    [TestMethod]
    public void SetCurrentThemeExplicitly_AndGetValue()
    {
        // Arrange.
        AppThemeService service = new(_messenger);

        // Act.
        service.CurrentTheme = AppTheme.Dark;

        // Assert.
        Assert.IsTrue(service.CurrentTheme is AppTheme.Dark);
    }

    [TestMethod]
    public void SetCurrentTheme_AndReceiveValueChangedMessage()
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

    [TestMethod]
    public void RequestThemeChange_AndValidateValue()
    {
        // Arrange.
        AppThemeService service = new(_messenger);

        // Act.
        var message = _messenger.Send(new AppThemeChangeRequestMessage(AppTheme.Light));

        // Assert.
        Assert.IsTrue(message.Response     is AppTheme.Light);
        Assert.IsTrue(service.CurrentTheme is AppTheme.Light);
    }
}