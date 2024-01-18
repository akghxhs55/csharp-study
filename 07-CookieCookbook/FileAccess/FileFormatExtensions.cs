namespace CookieCookbook.FileAccess;

public static class FileFormatExtensions
{
    public static string GetFileExtension(this FileFormat fileFormat)
    {
        return fileFormat switch
        {
            FileFormat.Txt => ".txt",
            FileFormat.Json => ".json",
            _ => throw new NotImplementedException()
        };
    }
}
