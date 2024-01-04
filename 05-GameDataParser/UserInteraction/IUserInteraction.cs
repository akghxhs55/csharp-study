namespace GameDataParser.UserInteraction;

public interface IUserInteraction
{
    string GetValidFilename();
    void ShowMessage(string message);
    void ShowError(string message);
    void Exit();
}
