using System.Collections.Generic;
using System.Text.RegularExpressions;

/// <summary>
/// Represents a row in a table.
/// </summary>
public class Row
{
    public List<string> Cells { get; internal set; }
    public List<int> CellLengths { get; internal set; }

    /// <summary>
    /// Creates an empty row object.
    /// </summary>
    public Row() 
    {
        Cells = new List<string>();
        CellLengths = new List<int>(); 
    }

    /// <summary>
    /// Creates a row object with initialized contents.
    /// </summary>
    /// <param name="text">the content of the row</param>
    /// <remarks>See <see cref="AddRow(string)"/> for the parameters of <c>text</c>.</remarks>

    public Row(string text) 
    {
        Cells = new List<string>();
        CellLengths = new List<int>();
        AddRow(text); 
    }
    
    /// <summary>
    /// Creates a row with cells from a comma deliniated list.
    /// </summary>
    /// <param name="text">the contents of the row</param>
    /// <remarks>To create a new column within the row, use a comma.
    /// If you wish to have a literal comma, you can escape it with a backslash.</remarks>
    public void AddRow(string text)
    {
        if (!Regex.IsMatch(text, @"[^\\],")) //Only one column
        {
            while (Regex.IsMatch(text, @"\\,"))
            {
                var match = Regex.Match(text, @"\\,");
                if (text.Substring(match.Index - 2, 1) != @"\") // foo\, => foo,
                {
                    text.Remove(match.Index, 1);
                }
            }

            Cells.Add(text);
            CellLengths.Add(text.Length);
        }
        else //Multiple columns
        {
            List<int> splice = new List<int>();
            string expression = text;
            for (int c = 1; Regex.IsMatch(expression, @"[^\\],"); c++) //Finds one before ","
            {
                var match = Regex.Match(expression, @"[^\\],");
                splice.Add(match.Index + c);
                expression = expression.Remove(match.Index + 1, 1);
            }

            Cells.Add(text.Substring(0, splice[0]));

            int i = 0;
            for (; i < splice.Count - 1; i++)
            {
                Cells.Add(text[(splice[i] + 2)..splice[i + 1]]);
            }

            Cells.Add(text[(splice[i] + 2)..]);

            for (int c = 0; c < Cells.Count; c++)
            {
                while (Regex.IsMatch(Cells[c], @"\\,"))
                {
                    var match = Regex.Match(Cells[c], @"\\,");
                    if (Cells[c].Substring(match.Index - 2, 1) != @"\") // foo\\, => foo,
                    {
                        Cells[c] = Cells[c].Remove(match.Index, 1);
                    }
                }
            }

            CellLengths = new List<int> ();
            foreach (var cell in Cells)
            {
                CellLengths.Add(cell.Length);
            }
        }
    }
}