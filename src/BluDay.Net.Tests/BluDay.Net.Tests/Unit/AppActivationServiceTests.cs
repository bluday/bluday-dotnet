namespace BluDay.Net.Tests.Unit;

[TestClass]
public sealed class AppActivationServiceTests
{
    [TestMethod]
    public void Check_If_IsActivated_Is_True()
    {
        // Arrange
        AppActivationService service = new(WeakReferenceMessenger.Default);

        // Act
        service.Activate();

        // Assert
        Assert.IsTrue(service.IsActivated);
    }
}