using GameDataParser.Model;

namespace GameDataParser.UserInteraction;

public interface IGamesPrinter
{
    void PrintAll(List<GameData> games);
}
