namespace GameDataParser.DataAccess;

public class LocalFileReader : IFileReader
{
    public string Read(string filename)
    {
        return File.ReadAllText(filename);
    }
}