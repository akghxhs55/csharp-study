namespace StarWarsPlanetStats.Swapi;

using System.Text.Json;

public class ApiReader<TRoot> : IApiReader<TRoot>, IDisposable
{
    private readonly HttpClient _client;

    public ApiReader(string baseAddress)
    {
        _client = new HttpClient
        {
            BaseAddress = new Uri(baseAddress)
        };
    }

    public async Task<TRoot?> Read(string requestUri)
    {
        var response = await _client.GetAsync(requestUri);
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadAsStringAsync();
        
        return JsonSerializer.Deserialize<TRoot>(content);
    }

    public void Dispose()
    {
        _client.Dispose();
    }
}
