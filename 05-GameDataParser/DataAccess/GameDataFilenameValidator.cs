namespace GameDataParser.DataAccess;

public class GameDataFilenameValidator : IStringValidator
{
    public bool Validate(string? filename, out string validationMessage)
    {
        if (filename is null)
        {
            validationMessage = "File name cannot be null.";
            return false;
        }

        if (filename.Length == 0)
        {
            validationMessage = "File name cannot be empty.";
            return false;
        }

        if (!File.Exists(filename))
        {
            validationMessage = "File not found.";
            return false;
        }

        validationMessage = string.Empty;
        return true;
    }
}
