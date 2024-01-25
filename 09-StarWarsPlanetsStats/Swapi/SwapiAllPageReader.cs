namespace StarWarsPlanetStats.Swapi;

public class SwapiAllPageReader<TTarget> : ISwapiAllPageReader<TTarget>
{
    private readonly IApiReader<SwapiRoot<TTarget>> _apiReader;

    public SwapiAllPageReader(IApiReader<SwapiRoot<TTarget>> apiReader)
    {
        _apiReader = apiReader;
    }

    public async Task<IEnumerable<TTarget>> ReadAll(string requestUri)
    {
        var planets = new List<TTarget>();

        while (!string.IsNullOrEmpty(requestUri))
        {
            var root = await _apiReader.Read(requestUri);
            if (root is null)
            {
                throw new Exception("No data");
            }

            planets.AddRange(root.Results);

            requestUri = root.Next;
        }

        return planets;
    }
}
