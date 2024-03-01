namespace _16_QuoteFinder.QuoteData;

public interface IQuoteDataFetcher
{
    Task<IEnumerable<string>> FetchDataFromAllPagesAsync(
        int numberOfPages,
        int quotesPerPage
    );
}