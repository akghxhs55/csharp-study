namespace _16_QuoteFinder.DataAccess;

public class QuoteApiDataReader : IQuoteApiDataReader
{
    private readonly HttpClient _httpClient = new HttpClient();
    
    public async Task<string> ReadAsync(int page, int quotesPerPage)
    {
        string endPoint = $"https://quote-garden.onrender.com/api/v3/quotes?limit={quotesPerPage}&page={page}";
        
        var response = await _httpClient.GetAsync(endPoint);
        response.EnsureSuccessStatusCode();
        
        return await response.Content.ReadAsStringAsync();
    }

    public void Dispose()
    {   
        _httpClient.Dispose();
    }
}