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

            int count = 0;
            foreach (var recipe in recipes)
            {
                count++;
                Console.WriteLine($"*****{count}*****");
                Console.WriteLine(recipe);
                Console.WriteLine();
            }
        }
    }
    public void DisplayCreateRecipePrompt()
    {
        Console.WriteLine("Create a new cookie recipe! Avaliable ingredients are:");

        foreach (var ingredient in _ingredientRegister.All)
        {
            Console.WriteLine(ingredient);
        }
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
