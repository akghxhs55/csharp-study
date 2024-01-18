using CookieCookbook.FileAccess;
using CookieCookbook.DataAccess;
using CookieCookbook.Ingredients;
using CookieCookbook.Recipes;
using CookieCookbook.App;


const FileFormat fileFormat = FileFormat.Json;
const string filename = "recipes";
var filepath = $"{filename}{fileFormat.GetFileExtension()}";

var ingredientRegister = new IngredientRegister();
IStringRepository stringRepository = fileFormat switch
{
    FileFormat.Txt => new StringTxtRepository(),
    FileFormat.Json => new StringJsonRepository(),
    _ => throw new NotImplementedException()
};

var recipeRepository = new RecipeRepository(stringRepository, ingredientRegister);
var recipeConsoleUserInteraction = new RecipeConsoleUserInteraction(ingredientRegister);

var cookieRecipeApp = new CookieRecipeApp(recipeRepository, recipeConsoleUserInteraction);
cookieRecipeApp.Run(filepath);
