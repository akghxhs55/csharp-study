namespace StarWarsPlanetStats.Swapi;

public interface ISwapiAllPageReader<TTarget>
{
    Task<IEnumerable<TTarget>> ReadAll(string requestUri);
}
