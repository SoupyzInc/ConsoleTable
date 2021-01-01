using System;
using System.Linq;
using System.Collections.Generic;

/// <summary>
/// Contains the conents of a table and all necessary means to print the table.
/// </summary>
public class Table
{
	private readonly string topLeft = "┌";
	private readonly string topRight = "┐";
	private readonly string topT = "┬";

	private readonly string bottomLeft = "└";
	private readonly string bottomRight = "┘";
	private readonly string bottomT = "┴";

	private readonly string middle = "─";
	private readonly string plus = "┼";

	private readonly string side = "│";
	private readonly string leftSide = "├";
	private readonly string rightSide = "┤";

	private readonly List<Row> table = new List<Row>();

	/// <summary>
	/// Creates an empty table object.
	/// </summary>
	public Table() { }

	/// <summary>
	/// Adds a row to the table.
	/// </summary>
	/// <param name="text">the contents of the row.</param>
	/// <remarks>See <see cref="Row.AddRow(string)"/> for the parameters of <c>text</c>.</remarks>
	public void AddRow(string text)
	{
		table.Add(new Row(text));
	}

	/// <summary>
	/// Prints the table to console.
	/// </summary>
	public void Render()
	{
		//Find borders
		string maxRow = "";
		
		for (int column = 0; column < table[0].CellLengths.Count; column++)
		{
			string maxCell = "";
			for (int row = 0; row < table.Count; row++)
			{
				if (table[row].Cells[column].Length > maxCell.Length)
				{
					maxCell = table[row].Cells[column];
				}
			}
			
			maxRow += side + " " + maxCell + " ";
		}

		maxRow += side;

		List<int> borders = maxRow.AllIndexesOf(side).ToList();
		borders.RemoveAt(0);

		//Render Top
		string tableTop = topLeft;
		int maxWidth = maxRow.Length;

		for (int i = 1, c = 0; i <= maxWidth - 2; i++)
		{
			if (i != borders[c])
			{
				tableTop += middle;
			}
			else
			{
				if (c != borders.Count - 1)
				{
					c++;
				}

				tableTop += topT;
			}
		}

		tableTop += topRight;

		//Render Bottom
		string tableBottom = bottomLeft;

		for (int i = 1, c = 0; i <= maxWidth - 2; i++)
		{
			if (i != borders[c])
			{
				tableBottom += middle;
			}
			else
			{
				if (c != borders.Count - 1)
				{
					c++;
				}

				tableBottom += bottomT;
			}
		}

		tableBottom += bottomRight;

		//Render Rows
		string[] rows;

		if (table.Count == 1) //One Row
		{
			rows = new string[table.Count];
			for (int i = 0; i < rows.Length; i++) //Iterate through rows
			{
				string row = "";
				for (int j = 0; j < table[i].Cells.Count; j++) //Iterate through row's cells
				{
					row += side + " " + table[i].Cells[j] + " ";
				}

				rows[i] = row + side;
			}
		}
		else //Multiple Rows
		{
			rows = new string[table.Count * 2 - 1];
			for (int i = 0, rowCount = 0; i < table.Count * 2 - 1; i++) //Iterate through rows
			{
				int fill = 0;
				string row = "";
				if (i % 2 == 0) //Text row
				{
					int index = 0;
					for (int j = 0; j < table[rowCount].Cells.Count; j++) //Iterate through row's cells
					{
						row += side + " " + table[rowCount].Cells[j] + " ";
						index += 3 + table[rowCount].Cells[j].Length;

						while (index < borders[fill])
						{
							row += " ";
							index++;
						}

						if (fill < borders.Count - 1)
						{
							fill++;
						}
					}

					rowCount++;
					rows[i] = row + side;
				}
				else //Divieder Row
				{
					row += leftSide;
					for (int k = 1, c = 0; k <= maxWidth - 2; k++)
					{
						if (k != borders[c])
						{
							row += middle;
						}
						else
						{
							if (c != borders.Count - 1)
							{
								c++;
							}

							row += plus;
						}
					}

					rows[i] = row + rightSide;
				}
			}
		}

		//Render Table
		Console.WriteLine(tableTop);
		
		foreach (var rowToPrint in rows)
		{
			Console.WriteLine(rowToPrint);
		}
		
		Console.WriteLine(tableBottom);
	}
}
