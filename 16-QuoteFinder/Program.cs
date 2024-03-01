using _16_QuoteFinder.DataAccess;
using _16_QuoteFinder.QuoteData;
using _16_QuoteFinder.UserInteraction;

try
{
    var app = new QuoteFinderApp(
        new ConsoleUserInteraction(),
        new QuoteDataFetcher(
            new QuoteApiDataReader()
        ),
        new QuoteDataProcessorSingleThreaded(
            new QuoteDataPageConverter()
        )
    );

    await app.RunAsync();
}
catch (Exception e)
{
    Console.WriteLine(e);
    throw;
}

public class QuoteFinderApp
{
    private readonly IUserInteraction _userInteraction;
    private readonly IQuoteDataFetcher _quoteDataFetcher;
    private readonly IQuoteDataProcessor _quoteDataProcessor;

    public QuoteFinderApp(
        IUserInteraction userInteraction,
        IQuoteDataFetcher quoteDataFetcher, IQuoteDataProcessor quoteDataProcessor)
    {
        _userInteraction = userInteraction;
        _quoteDataFetcher = quoteDataFetcher;
        _quoteDataProcessor = quoteDataProcessor;
    }

    public async Task RunAsync()
    {
        _userInteraction.DisplayMessage("Welcome to Quote Finder!");

        _userInteraction.DisplayMessage("Please enter a word to search for quotes:");
        string wordToSearch = _userInteraction.GetInputString();

        _userInteraction.DisplayMessage("Please enter a number of pages of data to search:");
        int numberOfPages = _userInteraction.GetInputInt();

        _userInteraction.DisplayMessage("Please enter a number of quotes to be on each page:");
        int numberOfQuotesPerPage = _userInteraction.GetInputInt();

        var quoteData = await _quoteDataFetcher.FetchDataFromAllPagesAsync(
            numberOfPages,
            numberOfQuotesPerPage
        );

        var foundQuotes = _quoteDataProcessor.Process(quoteData, wordToSearch);
        
        _userInteraction.DisplayMessage("Found quotes:");
        foreach (var quote in foundQuotes)
        {
            _userInteraction.DisplayMessage(quote?.Text ?? "No quotes found.");
        }

        _userInteraction.DisplayMessage("Program is finished. Press any key to exit.");
        _userInteraction.EndInteraction();
    }
}