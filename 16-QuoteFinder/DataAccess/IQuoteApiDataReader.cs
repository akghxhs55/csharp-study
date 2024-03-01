namespace _16_QuoteFinder.DataAccess;

public interface IQuoteApiDataReader : IDisposable
{
    Task<string> ReadAsync(int page, int quotesPerPage);
}