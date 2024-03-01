using System.Text.Json;
using _16_QuoteFinder.DataAccess;

namespace _16_QuoteFinder.QuoteData;

public class QuoteDataProcessorSingleThreaded : IQuoteDataProcessor
{
    private readonly QuoteDataPageConverter _quoteDataPageConverter;

    public QuoteDataProcessorSingleThreaded(QuoteDataPageConverter quoteDataPageConverter)
    {
        _quoteDataPageConverter = quoteDataPageConverter;
    }

    public IEnumerable<Quote?> Process(IEnumerable<string> quoteData, string wordToFind)
    {
        var result = new List<Quote?>();
        
        foreach (string quoteDataPage in quoteData)
        {
            var quoteApiRoot = ProcessRoot(quoteDataPage);
            var quotePage = _quoteDataPageConverter.Convert(quoteApiRoot);
            var quote = ProcessPage(quotePage, wordToFind);
            
            result.Add(quote);
        }

        return result;
    }

    private static QuoteApiRoot ProcessRoot(string quoteDataPage)
    {
        return JsonSerializer.Deserialize<QuoteApiRoot>(quoteDataPage)!;
    }

    private static Quote? ProcessPage(IEnumerable<Quote> quotePage, string wordToFind)
    {
        return quotePage
            .Where(quote => quote.ContainsWord(wordToFind))
            .MinBy(quote => quote.Text.Length);
    }
}