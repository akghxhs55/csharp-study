namespace TicketAggregator.DataAccess;

public interface IStringRepository
{
    List<string> Read(string filepath);
    void Write(string filepath, List<string> strings);
}
