using _16_QuoteFinder.DataAccess;

namespace _16_QuoteFinder.QuoteData;

public class QuoteDataFetcher : IQuoteDataFetcher
{
    private readonly IQuoteApiDataReader _quoteApiDataReader;

    public QuoteDataFetcher(IQuoteApiDataReader quoteApiDataReader)
    {
        _quoteApiDataReader = quoteApiDataReader;
    }

    public async Task<IEnumerable<string>> FetchDataFromAllPagesAsync(int numberOfPages, int quotesPerPage)
    {
        var tasks = new List<Task<string>>();
        for (int pageNumber = 1; pageNumber <= numberOfPages; pageNumber++)
        {
            var readPageTask = _quoteApiDataReader.ReadAsync(pageNumber, quotesPerPage);
            tasks.Add(readPageTask);
        }
        
        string[] result = await Task.WhenAll(tasks);
        
        return result;
    }
}