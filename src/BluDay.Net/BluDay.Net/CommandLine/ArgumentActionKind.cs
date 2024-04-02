namespace BluDay.Net.CommandLine;

public enum ArgumentActionKind
{
    StoreConstant,
    StoreValue,
    AppendConstant,
    AppendValue,
    CountFlag,
    HelpMessage,
    VersionOutput
};