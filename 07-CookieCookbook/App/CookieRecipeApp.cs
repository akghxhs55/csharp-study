using CookieCookbook.Recipes;

namespace CookieCookbook.App;

public class CookieRecipeApp
{
    private readonly IRecipeRepository _recipeRepository;
    private readonly IRecipeUserInteraction _recipeConsoleUserInteraction;

    public CookieRecipeApp(IRecipeRepository recipeRepository, IRecipeUserInteraction recipeConsoleUserInteraction)
    {
        _recipeRepository = recipeRepository;
        _recipeConsoleUserInteraction = recipeConsoleUserInteraction;
    }

    public void Run(string filepath)
    {
        var allRecipes = _recipeRepository.Read(filepath);

        _recipeConsoleUserInteraction.DisplayAllRecipes(allRecipes);
        
        _recipeConsoleUserInteraction.DisplayCreateRecipePrompt();
        var ingredients = _recipeConsoleUserInteraction.ReadIngredientsFromUser();

        if (ingredients.Count() > 0)
        {
            var recipe = new Recipe(ingredients);
            _recipeConsoleUserInteraction.DisplayAddedRecipe(recipe);
            allRecipes.Add(recipe);
            _recipeRepository.Write(filepath, allRecipes);
        }
        else
        {
            _recipeConsoleUserInteraction.DisplayNoIngredientsError();
        }

        _recipeConsoleUserInteraction.Exit();
    }
}
