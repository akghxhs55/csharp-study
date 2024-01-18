using CookieCookbook.Ingredients;
using CookieCookbook.DataAccess;

namespace CookieCookbook.Recipes;

public class RecipeRepository : IRecipeRepository
{
    private static readonly string Seperator = ",";
    private readonly IStringRepository _stringRepository;
    private readonly IngredientRegister _ingredientRegister;

    public RecipeRepository(IStringRepository stringRepository, IngredientRegister ingredientRegister)
    {
        _stringRepository = stringRepository;
        _ingredientRegister = ingredientRegister;
    }

    public List<Recipe> Read(string filepath)
    {
        var recipeStrings = _stringRepository.Read(filepath);
        var recipes = recipeStrings
            .Select(recipeString => RecipeFromString(recipeString))
            .ToList();

        return recipes;
    }

    private Recipe RecipeFromString(string recipeString)
    {
        var ingredients = recipeString.Split(Seperator)
            .Where(ingredientId => int.TryParse(ingredientId, out int id))
            .Select(ingredientId => _ingredientRegister.GetById(int.Parse(ingredientId)))
            .Where(ingredient => ingredient is not null);

        return new Recipe(ingredients!);
    }

    public void Write(string filepath, IEnumerable<Recipe> recipes)
    {
        var recipeStrings = recipes
            .Select(recipe => {
                var allIds = recipe.Ingredients
                    .Select(ingredient => ingredient.Id.ToString());
                return string.Join(Seperator, allIds);
            })
            .ToList();

        _stringRepository.Write(filepath, recipeStrings);
    }
}
