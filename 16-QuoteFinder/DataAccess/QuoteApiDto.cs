namespace _16_QuoteFinder.DataAccess;

public record QuoteApiRoot(
    int statusCode,
    string message,
    QuoteApiPagination QuoteApiPagination,
    int totalQuotes,
    IReadOnlyList<QuoteApiDatum> data
);

public record QuoteApiPagination(
    int currentPage,
    int nextPage,
    int totalPages
);


public record QuoteApiDatum(
    string _id,
    string quoteText,
    string quoteAuthor,
    string quoteGenre,
    int __v
);