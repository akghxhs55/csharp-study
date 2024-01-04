using GameDataParser.DataAccess;

namespace GameDataParser.UserInteraction;

public class ConsoleUserInteraction : IUserInteraction
{
    private readonly IStringValidator _filenameValidator;

    public ConsoleUserInteraction(IStringValidator filenameValidator)
    {
        _filenameValidator = filenameValidator;
    }

    public string GetValidFilename()
    {
        bool shallContinue = true;
        string? filename = null;
        while (shallContinue)
        {
            Console.WriteLine("Enter the name of the file you want to read:");

            filename = Console.ReadLine();
            bool isFilenameValid = _filenameValidator.Validate(filename, out string validationMessage);

            if (!isFilenameValid)
            {
                Console.WriteLine(validationMessage);
            }
            else
            {
                shallContinue = false;
            }
        }

        return filename!;
    }

    public void ShowMessage(string message)
    {
        Console.WriteLine(message);
    }

    public void ShowError(string message)
    {
        var currentConsoleColor = Console.ForegroundColor;
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(message);
        Console.ForegroundColor = currentConsoleColor;
    }

    public void Exit()
    {
        Console.WriteLine("Press any key to close.");
        Console.ReadKey();
    }
}
