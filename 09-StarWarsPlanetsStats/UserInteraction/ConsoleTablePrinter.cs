namespace StarWarsPlanetStats.UserInteraction;

public class ConsoleTablePrinter<TObject> : IObjectsPrinter<TObject>
{
    private readonly int _columnWidth;

    public ConsoleTablePrinter(int columnWidth)
    {
        this._columnWidth = columnWidth;
    }

    public void Print(IEnumerable<TObject> obj)
    {
        var properties = typeof(TObject).GetProperties();
        Console.WriteLine(
            string.Join(
                "|",
                properties.Select(p => StringInColumn(p.Name))
            )
            + "|"
        );
        Console.WriteLine(new string('-', (_columnWidth + 1) * properties.Length));

        foreach (var item in obj)
        {
            Console.WriteLine(
                string.Join(
                    "|",
                    properties.Select(p => {
                        var value = p.GetValue(item);
                        if (value is null)
                        {
                            return StringInColumn("");
                        }

                        return StringInColumn(value.ToString());
                    })
                )
                + "|"
            );
        }
    }

    private string StringInColumn(string str)
    {
        if (str is null)
        {
            return new string(' ', _columnWidth);
        }
        return str + new string(' ', _columnWidth - str.Length);
    }
}
