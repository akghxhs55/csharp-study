using _16_QuoteFinder.DataAccess;

namespace _16_QuoteFinder.QuoteData;

public class QuoteDataPageConverter
{
    public IEnumerable<Quote> Convert(QuoteApiRoot quoteApiRoot)
    {
        return quoteApiRoot.data
            .Select(datum => new Quote(
                datum.quoteText,
                datum.quoteAuthor,
                datum.quoteGenre));
    }
}