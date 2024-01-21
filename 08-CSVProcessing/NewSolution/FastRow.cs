namespace CsvDataAccess.NewSolution;

public class FastRow
{
    private readonly Dictionary<string, bool> _boolData = new();
    private readonly Dictionary<string, decimal> _decimalData = new();
    private readonly Dictionary<string, int> _intData = new();
    private readonly Dictionary<string, string> _stringData = new();

    public object GetAtColumn(string columnName)
    {
        if (_boolData.ContainsKey(columnName))
        {
            return _boolData[columnName];
        }
        if (_decimalData.ContainsKey(columnName))
        {
            return _decimalData[columnName];
        }
        if (_intData.ContainsKey(columnName))
        {
            return _intData[columnName];
        }
        if (_stringData.ContainsKey(columnName))
        {
            return _stringData[columnName];
        }

        return null;
    }

    public void AssignCell(string columnName, bool value)
    {
        _boolData.Add(columnName, value);
    }

    public void AssignCell(string columnName, decimal value)
    {
        _decimalData.Add(columnName, value);
    }

    public void AssignCell(string columnName, int value)
    {
        _intData.Add(columnName, value);
    }

    public void AssignCell(string columnName, string value)
    {
        _stringData.Add(columnName, value);
    }
}