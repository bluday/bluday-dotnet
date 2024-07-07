namespace BluDay.Net.Tests.Unit;

[TestClass]
public sealed class AppActivationServiceTests
{
    [TestMethod]
    public void GetIsActivated_AfterActivation_AndExpectTrue()
    {
        // Arrange
        AppActivationService service = new(WeakReferenceMessenger.Default);

        // Act
        service.Activate();

        // Assert
        Assert.IsTrue(service.IsActivated);
    }
}