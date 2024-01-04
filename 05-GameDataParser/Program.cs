using GameDataParser.DataAccess;
using GameDataParser.App;
using GameDataParser.UserInteraction;
using GameDataParser.Logger;

var userInteraction = new ConsoleUserInteraction(new GameDataFilenameValidator());

var app = new GameDataParserApp(
    userInteraction,
    new LocalFileReader(),
    new JsonGameDataDeserializer(userInteraction),
    new ConsoleGamesPrinter(userInteraction)
);

var logger = new Logger(
    "log.txt",
    new StringTxtRepository()
);

try
{
    app.Run();
}
catch (Exception ex)
{
    Console.WriteLine("Sorry! The application has experienced an unexpected error and will have to be closed.");
    logger.log(ex);
}
