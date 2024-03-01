namespace _16_QuoteFinder.UserInteraction;

public class ConsoleUserInteraction : IUserInteraction
{
    public void DisplayMessage(string message)
    {
        Console.WriteLine(message);
    }

    public string GetInputString()
    {
        return Console.ReadLine() ?? string.Empty;
    }

    public int GetInputInt()
    {
        return int.Parse(GetInputString());
    }

    public bool GetInputBool()
    {
        return GetInputString() == "Y";
    }
    
    public void EndInteraction()
    {
        Console.ReadKey();
    }
}