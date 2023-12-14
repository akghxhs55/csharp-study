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
        var recipes = new List<Recipe>();

        foreach (var recipeString in recipeStrings)
        {
            var ingredientIds = recipeString.Split(Seperator);
            var ingredients = new List<Ingredient>();

            foreach (var ingredientId in ingredientIds)
            {
                if (int.TryParse(ingredientId, out int id))
                {
                    var ingredient = _ingredientRegister.GetById(id);
                    if (ingredient is not null)
                    {
                        ingredients.Add(ingredient);
                    }
                }
            }

            recipes.Add(new Recipe(ingredients));
        }

        return recipes;
    }

    public void Write(string filepath, IEnumerable<Recipe> recipes)
    {
        var recipeStrings = new List<string>();
        foreach (var recipe in recipes)
        {
            var ingredients = new List<string>();
            foreach (var ingredient in recipe.Ingredients)
            {
                ingredients.Add(ingredient.Id.ToString());
            }
            recipeStrings.Add(string.Join(Seperator, ingredients));
        }

        _stringRepository.Write(filepath, recipeStrings);
    }
}
