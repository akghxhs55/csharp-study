namespace GameDataParser.Model;

public class GameData
{
    public string Title { get; init; }
    public int ReleaseYear { get; init; }
    public decimal Rating { get; init; }

    public GameData(string title, int releaseYear, decimal rating)
    {
        Title = title;
        ReleaseYear = releaseYear;
        Rating = rating;
    }

    public override string ToString()
    {
        return $"{Title}, released in {ReleaseYear}, rating: {Rating}";
    }
}
