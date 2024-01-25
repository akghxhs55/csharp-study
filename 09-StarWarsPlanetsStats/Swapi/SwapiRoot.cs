namespace StarWarsPlanetStats.Swapi;

using System.Text.Json.Serialization;

public record SwapiRoot<TResult>(
    [property: JsonPropertyName("count")] int Count,
    [property: JsonPropertyName("next")] string Next,
    [property: JsonPropertyName("previous")] object Previous,
    [property: JsonPropertyName("results")] IEnumerable<TResult> Results
);
