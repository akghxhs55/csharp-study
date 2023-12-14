using System.Text.Json;

namespace CookieCookbook.DataAccess;

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
