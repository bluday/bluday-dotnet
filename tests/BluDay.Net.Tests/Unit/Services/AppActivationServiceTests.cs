namespace BluDay.Net.Tests.Unit.Services;

[TestClass]
public sealed class AppActivationServiceTests
{
    // TODO: Use a mocked messenger class instead of an actual instance.
    private readonly WeakReferenceMessenger _messenger = WeakReferenceMessenger.Default;

    #region Activate
    [TestMethod]
    public void Activate_AppExplicitly_AndGetIsActivated_AndReturnTrue()
    {
        // Arrange.
        AppActivationService service = new(_messenger);

        // Act.
        service.Activate();

        // Assert.
        Assert.IsTrue(service.IsActivated);
    }

    [TestMethod]
    public void Activate_UsingMessenger_AndGetIsActivated_AndReturnTrue()
    {
        // Arrange.
        AppActivationService service = new(_messenger);

        // Act.
        // _messenger.Send<AppActivationRequestMessage>();

        // Assert.
        Assert.IsTrue(service.IsActivated);
    }
    #endregion

    #region Deactivate
    [TestMethod]
    public void Deactivate_AppExplicitly_AndGetIsActivated_AndReturnFalse()
    {
        // Arrange.
        AppActivationService service = new(_messenger);

        // Act.
        service.Deactivate();

        // Assert.
        Assert.IsFalse(service.IsActivated);
    }

    [TestMethod]
    public void Deactivate_UsingMessenger_AndGetIsActivated_AndReturnTrue()
    {
        // Arrange.
        AppActivationService service = new(_messenger);

        // Act.
        // _messenger.Send<AppDeactivationRequestMessage>();

        // Assert.
        Assert.IsFalse(service.IsActivated);
    }
    #endregion
}