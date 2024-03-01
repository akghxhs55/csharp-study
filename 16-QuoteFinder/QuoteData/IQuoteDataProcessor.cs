namespace _16_QuoteFinder.QuoteData;

public interface IQuoteDataProcessor
{
    IEnumerable<Quote?> Process(IEnumerable<string> quoteData, string wordToFind);
}