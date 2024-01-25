namespace StarWarsPlanetStats.UserInteraction;

public interface IObjectsPrinter<TObject>
{
    void Print(IEnumerable<TObject> obj);
}