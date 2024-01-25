namespace StarWarsPlanetStats.Swapi;

public interface IApiReader<TRoot>
{
    Task<TRoot?> Read(string requestUri);
}
