using CookieCookbook.Ingredients;

namespace CookieCookbook.Recipes;

public class RecipeConsoleUserInteraction : IRecipeUserInteraction
{
    private readonly IngredientRegister _ingredientRegister;

    public RecipeConsoleUserInteraction(IngredientRegister ingredientRegister)
    {
        _ingredientRegister = ingredientRegister;
    }

    public void DisplayAllRecipes(IEnumerable<Recipe> recipes)
    {
        if (recipes.Count() > 0)
        {
            Console.WriteLine("Existing recipes are:" + Environment.NewLine);

            var recipesTexts = recipes
                .Select((recipe, index) =>
$@"*****{index + 1}*****
{recipe}");
            
            Console.WriteLine(string.Join(Environment.NewLine, recipesTexts));
            Console.WriteLine();
        }
    }
    public void DisplayCreateRecipePrompt()
    {
        Console.WriteLine("Create a new cookie recipe! Avaliable ingredients are:");

        Console.WriteLine(string.Join(Environment.NewLine, _ingredientRegister.All));
    }

    public IEnumerable<Ingredient> ReadIngredientsFromUser()
    {
        var ingredientsFromUser = new List<Ingredient>();
        bool shallContinue = true;
        while (shallContinue)
        {
            Console.WriteLine("Add an ingredient by its ID or type anything else if finished.");

            var input = Console.ReadLine()!;
            if (int.TryParse(input, out int ingredientId))
            {
                var ingredient = _ingredientRegister.GetById(ingredientId);
                if (ingredient is not null)
                {
                    ingredientsFromUser.Add(ingredient);
                }
            }
            else
            {
                shallContinue = false;
            }
        }

        return ingredientsFromUser;
    }

    public void DisplayAddedRecipe(Recipe recipe)
    {
        Console.WriteLine("Added recipe:");
        Console.WriteLine(recipe);
    }

    public void DisplayNoIngredientsError()
    {
        Console.WriteLine("No ingredients have been selected. Recipe will not be saved.");
    }

    public void Exit()
    {
        Console.WriteLine("Press any key to exit.");
        Console.ReadKey();
    }
}
