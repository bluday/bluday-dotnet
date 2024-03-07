namespace BluDay.Net.CommandLine;

public readonly struct ArgToken
{
    public bool IsFlag { get; }

    public int Index { get; }

    public string Value { get; }

    public ArgToken(string value, int index)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(value);

        if (index < 0) throw new IndexOutOfRangeException();

        IsFlag = false;

        Value = value;

        Index = index;
    }
}