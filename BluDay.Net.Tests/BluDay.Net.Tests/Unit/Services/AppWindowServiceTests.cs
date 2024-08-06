namespace BluDay.Net.Tests.Unit.Services;

[TestClass]
public sealed class AppWindowServiceTests
{
    // TODO: Use a mocked messenger class instead of an actual instance.
    private readonly WeakReferenceMessenger _messenger = WeakReferenceMessenger.Default;

    #region CreateWindow
    [TestMethod]
    public void CreateWindow_AndReturnRegisteredInstance()
    {
        // Arrange.
        AppWindowService service = new(_messenger);

        // Act.
        IBluWindow window = service.CreateWindow<FakeWindow>();

        // Assert.
        Assert.IsNotNull(window);
    }

    [TestMethod]
    public void CreateWindow_AndCheckIfHasWindowByInstance_AndReturnTrue()
    {
        // Arrange.
        AppWindowService service = new(_messenger);

        // Act.
        IBluWindow window = service.CreateWindow<FakeWindow>();

        bool hasWindow = service.HasWindow(window);

        // Assert.
        Assert.IsTrue(hasWindow);
    }
    #endregion

    #region DestroyWindow
    [TestMethod]
    public void DestroyWindow_AndReturnTrue()
    {
        // Arrange.
        AppWindowService service = new(_messenger);

        // Act.
        IBluWindow window = service.CreateWindow<FakeWindow>();

        bool isDestroyed = service.DestroyWindow(window);

        // Assert.
        Assert.IsTrue(isDestroyed);
    }

    [TestMethod]
    public void DestroyWindow_ById_AndReturnTrue()
    {
        // Arrange.
        AppWindowService service = new(_messenger);

        // Act.
        IBluWindow window = service.CreateWindow<FakeWindow>();

        bool isDestroyed = service.DestroyWindow(window.Id);

        // Assert.
        Assert.IsTrue(isDestroyed);
    }

    [TestMethod]
    public void DestroyWindow_UsingManuallyCreatedInstance_AndReturnFalse()
    {
        // Arrange.
        AppWindowService service = new(_messenger);

        // Act.
        bool isDestroyed = service.DestroyWindow(new FakeWindow());

        // Assert.
        Assert.IsFalse(isDestroyed);
    }

    [TestMethod]
    public void DestroyWindow_ById_UsingManuallyCreatedInstance_AndReturnFalse()
    {
        // Arrange.
        AppWindowService service = new(_messenger);

        // Act.
        bool isDestroyed = service.DestroyWindow(new FakeWindow().Id);

        // Assert.
        Assert.IsFalse(isDestroyed);
    }
    #endregion

    #region HasWindow
    [TestMethod]
    public void CheckIf_HasWindow_AndReturnTrue()
    {
        // Arrange.
        AppWindowService service = new(_messenger);

        // Act.
        IBluWindow window = service.CreateWindow<FakeWindow>();

        bool hasWindow = service.HasWindow(window.Id);

        // Assert.
        Assert.IsTrue(hasWindow);
    }

    [TestMethod]
    public void CheckIf_HasWindow_CreatedManually_AndReturnFalse()
    {
        // Arrange.
        AppWindowService service = new(_messenger);

        // Act.
        bool hasWindow = service.HasWindow(new FakeWindow());

        // Assert.
        Assert.IsFalse(hasWindow);
    }

    [TestMethod]
    public void CheckIf_HasWindow_CreateManually_ById_AndReturnFalse()
    {
        // Arrange.
        AppWindowService service = new(_messenger);

        // Act.
        bool hasWindow = service.HasWindow(new FakeWindow().Id);

        // Assert.
        Assert.IsFalse(hasWindow);
    }
    #endregion
}

// Temporary solution. Am going to use Moq soon.
public sealed class FakeWindow : IBluWindow
{
    public ViewNavigator ViewNavigator { get; } = new();

    public Guid Id { get; } = Guid.NewGuid();

    public bool IsResizable { get; set; }

    public string? Title { get; set; }

    public Size Size { get; private set; }

    public void Activate() { }

    public void Close() { }

    public void Configure(WindowConfiguration config)
    {
        ArgumentNullException.ThrowIfNull(config);

        IsResizable = config.IsResizable;
        Title = config.Title;

        if (config.Size.HasValue)
        {
            Size size = config.Size.Value;

            Resize(size.Width, size.Height);
        }
    }

    public void Resize(int width, int height)
    {
        Size = new(width, height);
    }
}