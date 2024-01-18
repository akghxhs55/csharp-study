using CookieCookbook.Ingredients;

namespace CookieCookbook.Recipes;

public interface IRecipeUserInteraction
{
    void DisplayAllRecipes(IEnumerable<Recipe> recipes);
    void DisplayCreateRecipePrompt();
    IEnumerable<Ingredient> ReadIngredientsFromUser();
    void DisplayAddedRecipe(Recipe recipe);
    void DisplayNoIngredientsError();
    void Exit();
}
