using CookieCookbook.Ingredients;

namespace CookieCookbook.Recipes;

public class Recipe
{
    public IEnumerable<Ingredient> Ingredients { get; }

    public Recipe(IEnumerable<Ingredient> ingredients)
    {
        Ingredients = ingredients;
    }

    public override string ToString()
    {
        var instructions = new List<string>();
        foreach (var ingredient in Ingredients)
        {
            instructions.Add($"{ingredient.Name}. {ingredient.PreparationInstructions}");
        }

        return string.Join(Environment.NewLine, instructions);
    }
}
