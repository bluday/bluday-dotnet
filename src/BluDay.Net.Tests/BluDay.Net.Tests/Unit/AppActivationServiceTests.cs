namespace BluDay.Net.Tests.Unit;

[TestClass]
public sealed class AppActivationServiceTests
{
    [TestMethod]
    public void GetIsActivated_AfterExplicitActivationCall_AndExpectTrue()
    {
        // Arrange
        AppActivationService service = new(WeakReferenceMessenger.Default);

        // Act
        service.Activate();

        // Assert
        Assert.IsTrue(service.IsActivated);
    }

    [TestMethod]
    public void GetIsActivated_AfterSentActivationRequestMessage_AndExpectTrue()
    {
        // Arrange
        AppActivationService service = new(WeakReferenceMessenger.Default);

        // Act
        WeakReferenceMessenger.Default.Send<AppActivationRequestMessage>();

        // Assert
        Assert.IsTrue(service.IsActivated);
    }
}