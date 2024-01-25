using StarWarsPlanetStats.Swapi;
using StarWarsPlanetStats.UserInteraction;

const string baseAddress = "https://swapi.dev/api/";
const string requestUri = "planets/";
const int columnWidth = 15;

var apiReader = new ApiReader<SwapiRoot<Planet>>(baseAddress);
var swapiAllPageReader = new SwapiAllPageReader<Planet>(apiReader);
var printer = new ConsoleTablePrinter<Planet>(columnWidth);

var app = new StarWarsStatsApp<Planet>(requestUri, swapiAllPageReader, printer);

await app.Run();

public class StarWarsStatsApp<TTarget>
    where TTarget : class
{
    private readonly string requestUri;
    private readonly ISwapiAllPageReader<TTarget> swapiAllPageReader;
    private readonly IObjectsPrinter<TTarget> objectsPrinter;

    public StarWarsStatsApp(
        string requestUri,
        ISwapiAllPageReader<TTarget> swapiAllPageReader,
        IObjectsPrinter<TTarget> objectsPrinter)
    {
        this.requestUri = requestUri;
        this.swapiAllPageReader = swapiAllPageReader;
        this.objectsPrinter = objectsPrinter;
    }

    public async Task Run()
    {
        var objects = await swapiAllPageReader.ReadAll(requestUri);

        objectsPrinter.Print(objects);

        Console.WriteLine("The statistics of which property would you like to see?");
        Console.WriteLine("population");
        Console.WriteLine("diameter");
        Console.WriteLine("surface water");

        var property = Console.ReadLine();

        var planets = (IEnumerable<Planet>?)objects;

        if (property == "population")
        {
            var maxPopulationPlanet = planets.MaxBy(p => p.Population);
            var minPopulationPlanet = planets.MinBy(p => p.Population);

            Console.WriteLine($"Max {property} is {maxPopulationPlanet.Population} (planet: {maxPopulationPlanet.Name})");
            Console.WriteLine($"Min {property} is {minPopulationPlanet.Population} (planet: {minPopulationPlanet.Name})");
        }
        else if (property == "diameter")
        {
            var maxDiameterPlanet = planets.MaxBy(p => p.Diameter);
            var minDiameterPlanet = planets.MinBy(p => p.Diameter);

            Console.WriteLine($"Max {property} is {maxDiameterPlanet.Diameter} (planet: {maxDiameterPlanet.Name})");
            Console.WriteLine($"Min {property} is {minDiameterPlanet.Diameter} (planet: {minDiameterPlanet.Name})");
        }
        else if (property == "surface water")
        {
            var maxSurfaceWaterPlanet = planets.MaxBy(p => p.SurfaceWater);
            var minSurfaceWaterPlanet = planets.MinBy(p => p.SurfaceWater);

            Console.WriteLine($"Max {property} is {maxSurfaceWaterPlanet.SurfaceWater} (planet: {maxSurfaceWaterPlanet.Name})");
            Console.WriteLine($"Min {property} is {minSurfaceWaterPlanet.SurfaceWater} (planet: {minSurfaceWaterPlanet.Name})");
        }
        else
        {
            Console.WriteLine("Unknown property");
        }

        Console.WriteLine("Press any key to close.");
        Console.ReadKey();
    }
}


