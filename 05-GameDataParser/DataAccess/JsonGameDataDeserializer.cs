namespace GameDataParser.DataAccess;

using System.Text.Json;
using GameDataParser.Model;
using GameDataParser.UserInteraction;

public class JsonGameDataDeserializer : IGameDataDeserializer
{
    private readonly IUserInteraction _userInteraction;

    public JsonGameDataDeserializer(IUserInteraction userInteraction)
    {
        _userInteraction = userInteraction;
    }

    public List<GameData>? DeserializeFrom(string filename, string fileContent)
    {
        try
        {
            return JsonSerializer.Deserialize<List<GameData>>(fileContent);
        }
        catch (JsonException ex)
        {
            _userInteraction.ShowError(
                $"JSON in the {filename} was not in a valid format. JSON body:"
                + fileContent
            );

            throw new JsonException($"{ex.Message} The file is: {filename}", ex);
        }
    }
}
