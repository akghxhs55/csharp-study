using System.Text.Json;

namespace GameDataParser.DataAccess;

public class StringJsonRepository : StringRepository
{
    protected override List<string> FileToString(string fileContents)
    {
        return JsonSerializer.Deserialize<List<string>>(fileContents)!;
    }

    protected override string StringToFile(List<string> strings)
    {
        return JsonSerializer.Serialize(strings);
    }
}
