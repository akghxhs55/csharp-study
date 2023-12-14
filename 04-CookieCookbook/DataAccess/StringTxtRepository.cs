namespace CookieCookbook.DataAccess;

public class StringTxtRepository : StringRepository
{
    private static readonly string Seperator = Environment.NewLine;

    protected override List<string> FileToString(string fileContents)
    {
        return fileContents.Split(Seperator).ToList();
    }

    protected override string StringToFile(List<string> strings)
    {
        return string.Join(Seperator, strings);
    }
}
