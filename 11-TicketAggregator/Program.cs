using System.Globalization;
using System.Text;
using TicketAggregator.DataAccess;
using UglyToad.PdfPig;

const string baseDir = "./data";

var app = new TicketAggregatorApp(
    new PdfToStringsReader(),
    new OutCinemaTicketStringParser(),
    new StringTxtRepository(),
    baseDir);

app.Run();


public class TicketAggregatorApp
{
    private readonly PdfToStringsReader _pdfToStringsReader;
    private readonly ITicketStringParser _ticketParser;
    private readonly IStringRepository _stringRepository;
    private readonly string _baseDir;
    private readonly string _dirToSave;
    private const string _filenameToSave = "aggregatedTickets.txt";

    public TicketAggregatorApp(
        PdfToStringsReader pdfToStringsReader,
        ITicketStringParser ticketParser,
        IStringRepository stringTxtRepository,
        string baseDir)
    {
        _pdfToStringsReader = pdfToStringsReader;
        _ticketParser = ticketParser;
        _stringRepository = stringTxtRepository;
        _baseDir = baseDir;
        _dirToSave = $"{_baseDir}/{_filenameToSave}";
    }

    public void Run()
    {
        DirectoryInfo directory = new(_baseDir);
        FileInfo[] files = directory.GetFiles("*.pdf");

        List<string> ticketStrings = new();

        foreach (var file in files)
        {
            var inputString = _pdfToStringsReader.Read(file.FullName);
            var tickets = _ticketParser.Parse(inputString);
            ticketStrings.AddRange(tickets.Select(t => t.ToString()));
        }

        _stringRepository.Write(_dirToSave, ticketStrings);

        Console.WriteLine($"Result saved to {_dirToSave}");
        Console.WriteLine("Press any key to close.");
        Console.ReadKey();
    }
}

public class PdfToStringsReader
{
    public string Read(string fileName)
    {
        using var document = PdfDocument.Open(fileName);

        var result = new StringBuilder();
        foreach (var page in document.GetPages())
        {
            var text = page.Text;
            result.Append(text);
        }

        return result.ToString();
    }
}

public interface ITicketStringParser
{
    IEnumerable<Ticket> Parse(string ticketString);
}

public class OutCinemaTicketStringParser : ITicketStringParser
{
    private const string _titleStartWord = "Title:";
    private const string _dateStartWord = "Date:";
    private const string _timeStartWord = "Time:";
    private const string _ticketEndWord = "Visit us";
    private readonly Dictionary<string, CultureInfo> _cultures = new()
    {
        ["com"] = new CultureInfo("en-US"),
        ["fr"] = new CultureInfo("fr-FR"),
        ["jp"] = new CultureInfo("ja-JP")
    };

    public IEnumerable<Ticket> Parse(string ticketString)
    {
        var parsedStrings = ticketString.Split(
            new[] { _titleStartWord, _dateStartWord, _timeStartWord, _ticketEndWord },
            StringSplitOptions.None);

        var culture = _cultures[parsedStrings.Last().Split('.').Last()];
        
        var tickets = new List<Ticket>();
        for (int i = 1; i < parsedStrings.Length - 1; i += 3)
        {
            var title = parsedStrings[i];
            var date = DateOnly.Parse(parsedStrings[i + 1], culture);
            var time = TimeOnly.Parse(parsedStrings[i + 2], culture);

            tickets.Add(new Ticket(title, date, time));
        }

        return tickets;
    }
}

public readonly struct Ticket
{
    public string Title { get; init; }
    public DateOnly Date { get; init; }
    public TimeOnly Time { get; init; }

    public Ticket(string title, DateOnly date, TimeOnly time)
    {
        Title = title;
        Date = date;
        Time = time;
    }

    public override string ToString()
    {
        return string.Format("{0, -40} | {1:MM/dd/yyyy} | {2:HH:mm}", Title, Date, Time);
    }
}