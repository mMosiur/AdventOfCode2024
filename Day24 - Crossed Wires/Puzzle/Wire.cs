namespace AdventOfCode.Year2024.Day24.Puzzle;

internal sealed class Wire(string name, bool initialValue = false)
{
    public string Name { get; set; } = name;
    public bool Value { get; set; } = initialValue;

    public override string ToString() => $"{Name}: {Value}";
}
