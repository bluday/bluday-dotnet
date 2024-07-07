namespace BluDay.Net.Tests.Unit;

[TestClass]
public sealed class AppActivationServiceTests
{
    private readonly WeakReferenceMessenger _messenger = WeakReferenceMessenger.Default;

    [TestMethod]
    public void GetIsActivated_AfterExplicitActivationCall_AndExpectTrue()
    {
        // Arrange
        AppActivationService service = new(_messenger);

        // Act
        service.Activate();

        // Assert
        Assert.IsTrue(service.IsActivated);
    }

    [TestMethod]
    public void GetIsActivated_AfterExplicitDeactivationCall_AndExpectTrue()
    {
        // Arrange
        AppActivationService service = new(_messenger);

        // Act
        service.Deactivate();

        // Assert
        Assert.IsFalse(service.IsActivated);
    }

    [TestMethod]
    public void GetIsActivated_AfterSentActivationRequestMessage_AndExpectTrue()
    {
        // Arrange
        AppActivationService service = new(_messenger);

        // Act
        _messenger.Send<AppActivationRequestMessage>();

        // Assert
        Assert.IsTrue(service.IsActivated);
    }

    [TestMethod]
    public void GetIsActivated_AfterSentDeactivationRequestMessage_AndExpectTrue()
    {
        // Arrange
        AppActivationService service = new(_messenger);

        // Act
        _messenger.Send<AppDeactivationRequestMessage>();

        // Assert
        Assert.IsFalse(service.IsActivated);
    }
}