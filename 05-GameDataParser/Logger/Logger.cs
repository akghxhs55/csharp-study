using GameDataParser.DataAccess;

namespace GameDataParser.Logger;

public class Logger
{
    private readonly string _logFilepath;
    private readonly IStringRepository _stringRepository;

    public Logger(string logFilepath, IStringRepository stringRepository)
    {
        _logFilepath = logFilepath;
        _stringRepository = stringRepository;
    }

    public void log(Exception ex)
    {
        List<string> logMessages = new List<string>() {
            $"{DateTime.Now}",
            "Exception message:\t" + ex.Message,
            "Stack trace:\t" + ex.StackTrace,
            Environment.NewLine
        };

        _stringRepository.Append(_logFilepath, logMessages);
    }
}
