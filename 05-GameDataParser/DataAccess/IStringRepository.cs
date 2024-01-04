namespace GameDataParser.DataAccess;

public interface IStringRepository
{
    List<string> Read(string filepath);
    void Write(string filepath, List<string> strings);
    void Append(string filepath, List<string> strings);
}
