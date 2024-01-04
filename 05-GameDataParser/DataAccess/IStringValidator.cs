namespace GameDataParser.DataAccess;

public interface IStringValidator
{
    bool Validate(string? input, out string validationMessage);
}
