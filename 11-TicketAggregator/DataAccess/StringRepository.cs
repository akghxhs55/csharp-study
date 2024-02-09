namespace TicketAggregator.DataAccess;

public abstract class StringRepository : IStringRepository
{
    public List<string> Read(string filepath)
    {
        if (File.Exists(filepath))
        {
            var fileContents = File.ReadAllText(filepath);
            return FileToString(fileContents)!;
        }
        return new List<string>();
    }

    public void Write(string filepath, List<string> strings)
    {
        File.WriteAllText(filepath, StringToFile(strings));
    }

    protected abstract List<string> FileToString(string fileContents);
    protected abstract string StringToFile(List<string> strings);
}
