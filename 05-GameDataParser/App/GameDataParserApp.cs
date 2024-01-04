using GameDataParser.DataAccess;
using GameDataParser.UserInteraction;

namespace GameDataParser.App;

public class GameDataParserApp
{
    private readonly IUserInteraction _userInteraction;
    private readonly IFileReader _fileReader;
    private readonly IGameDataDeserializer _gameDataDeserializer;
    private readonly IGamesPrinter _gamesPrinter;

    public GameDataParserApp(
        IUserInteraction userInteraction,
        IFileReader fileReader,
        IGameDataDeserializer gameDataDeserializer,
        IGamesPrinter gamesPrinter)
    {
        _userInteraction = userInteraction;
        _fileReader = fileReader;
        _gameDataDeserializer = gameDataDeserializer;
        _gamesPrinter = gamesPrinter;
    }

    public void Run()
    {
        string filename = _userInteraction.GetValidFilename();
        string fileContent = _fileReader.Read(filename);
        var gameData = _gameDataDeserializer.DeserializeFrom(filename, fileContent);
        _gamesPrinter.PrintAll(gameData!); // assume that DeserializeFrom will never return null

        _userInteraction.Exit();
    }
}
