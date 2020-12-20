using System.Collections.Generic;

/// <summary>
/// Represents a row in a table.
/// </summary>
public class Row
{
    public List<string> Cells { get; internal set; }
    public List<int> CellLengths { get; internal set; }

    /// <summary>
    /// Creates a row object with initialized contents.
    /// </summary>
    /// <param name="texts">the content of the row</param>
    /// <remarks>See <see cref="AddRow(string)"/> for the parameters of <c>texts</c>.</remarks>
    public Row(params string[] texts)
    {
        Cells = new List<string>();
        CellLengths = new List<int>();
        AddRow(texts);
    }

    /// <summary>
    /// Creates a row with cells from a string array.
    /// </summary>
    /// <param name="text">the contents of the row</param>
    /// <remarks>Each string object in the string array will be a new cell in the row.</remarks>
    public void AddRow(params string[] texts)
    {
        foreach (var text in texts)
        {
            Cells.Add(text);
            CellLengths.Add(text.Length);
        }
    }
}
