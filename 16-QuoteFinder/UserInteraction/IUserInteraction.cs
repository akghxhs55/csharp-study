namespace _16_QuoteFinder.UserInteraction;

public interface IUserInteraction
{
    void DisplayMessage(string message);
    string GetInputString();
    int GetInputInt();
    bool GetInputBool();
    void EndInteraction();
}