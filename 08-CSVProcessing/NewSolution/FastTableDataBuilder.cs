using System.Text;
using CsvDataAccess.CsvReading;
using CsvDataAccess.Interface;
using CsvDataAccess.OldSolution;

namespace CsvDataAccess.NewSolution;

public class FastTableDataBuilder : ITableDataBuilder
{
    public ITableData Build(CsvData csvData)
    {
        var rows = new List<FastRow>(csvData.Rows.Count());

        foreach (var row in csvData.Rows)
        {
            FastRow newRow = new();

            for (int i = 0; i < row.Length; i++)
            {
                var value = row[i];

                if (string.IsNullOrEmpty(value))
                {
                    continue;
                }
                else if (value == "TRUE")
                {
                    newRow.AssignCell(csvData.Columns[i], true);
                }
                else if (value == "FALSE")
                {
                    newRow.AssignCell(csvData.Columns[i], false);
                }
                else if (value.Contains(".") && decimal.TryParse(value, out var valueAsDecimal))
                {
                    newRow.AssignCell(csvData.Columns[i], valueAsDecimal);
                }
                else if (int.TryParse(value, out var valueAsInt))
                {
                    newRow.AssignCell(csvData.Columns[i], valueAsInt);
                }
                else
                {
                    newRow.AssignCell(csvData.Columns[i], value);
                }
            }

            rows.Add(newRow);
        }

        return new FastTableData(csvData.Columns, rows);
    }
}
