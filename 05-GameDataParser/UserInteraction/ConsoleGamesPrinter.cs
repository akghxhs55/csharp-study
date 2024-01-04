using GameDataParser.Model;

namespace GameDataParser.UserInteraction;

public class ConsoleGamesPrinter : IGamesPrinter
{
    private readonly IUserInteraction _userInteraction;

    public ConsoleGamesPrinter(IUserInteraction userInteraction)
    {
        _userInteraction = userInteraction;
    }

    public void PrintAll(List<GameData> games)
    {
        if (games.Count == 0)
        {
            _userInteraction.ShowMessage("No games are present in the input file.");
        }
        else
        {
            _userInteraction.ShowMessage("Loaded games are:");
            foreach (var game in games)
            {
                _userInteraction.ShowMessage(game.ToString());
            }
        }
    }
}
