using GameDataParser.Model;

namespace GameDataParser.DataAccess;

public interface IGameDataDeserializer
{
    List<GameData>? DeserializeFrom(string filename, string fileContent);
}
