using BluDay.Net.Common.CommandLine;

namespace BluDay.Net.Tests.Unit;

[TestClass]
public sealed class ArugmentsParserTests
{
    private static ArgumentDescriptors CreateArguments()
    {
        return new ArgumentDescriptors(
            optionals: [
                new(nameof(TestArgs.DemoMode))
                {
                    FlagDescriptor = "-d|--demo-mode"
                },
                new(nameof(TestArgs.Verbosity))
                {
                    FlagDescriptor = "-v|--verbosity=",
                    ActionKind     = ArgumentActionKind.CountFlag,
                    StoreKind      = ArgumentStoreKind.Integer,
                    Constant       = 1
                }
            ],
            positionals: [
                new PositionalArgumentDescriptor(nameof(TestArgs.FileNames))
                {
                    ActionKind = ArgumentActionKind.AppendValue,
                    StoreKind  = ArgumentStoreKind.String
                }
            ]
        );
    }

    [TestMethod]
    public void Parse_All_Positional_And_Optional_Arguments()
    {
        // Arrange.
        string[] args = ["-d", "-vvv -v", "--", "file0.txt", "file1.txt"];

        ArgumentsParser<TestArgs> parser = new(CreateArguments());

        // Act.
        TestArgs parsedArgs = parser.Parse(args);

        // Assert.
        Assert.IsTrue(parsedArgs?.DemoMode is true);
    }
}

public sealed class TestArgs
{
    [OptionalArgument]
    public bool? DemoMode { get; init; }

    [OptionalArgument]
    public bool? PerformanceMode { get; init; }

    [OptionalArgument]
    public bool? SkipIntro { get; init; }

    [OptionalArgument]
    public uint? Verbosity { get; init; }

    [PositionalArgument]
    public IReadOnlyList<string>? FileNames { get; }
}