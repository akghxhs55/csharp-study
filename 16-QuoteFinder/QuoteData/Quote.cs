namespace _16_QuoteFinder.QuoteData;

public record Quote(
    string Text,
    string Author,
    string Genre
)
{
    static readonly string[] _punctuation = { " ", ".", ",", "!", "?", ";", ":" };
    
    public bool ContainsWord(string inputWord)
    {
        string[] words = Text.Split(
            _punctuation,
            StringSplitOptions.RemoveEmptyEntries
        );

        return words.Any(word => word.Equals(inputWord, StringComparison.OrdinalIgnoreCase));
    }
}