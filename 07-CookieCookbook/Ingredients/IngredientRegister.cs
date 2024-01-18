namespace CookieCookbook.Ingredients;

public class IngredientRegister
{
    public IEnumerable<Ingredient> All => new List<Ingredient>()
    {
            new WheatFlour(),
            new CoconutFlour(),
            new Butter(),
            new Chocolate(),
            new Sugar(),
            new Cardamom(),
            new Cinnamon(),
            new CocoaPowder(),
    };

    public Ingredient? GetById(int id)
    {
        var matchedIngredients = All.Where(ingredient => ingredient.Id == id);
        
        if (matchedIngredients.Count() > 1)
        {
            throw new Exception($"Multiple ingredients with id {id} found.");
        }
        else if (matchedIngredients.Count() == 0)
        {
            return null;
        }
        else
        {
            return matchedIngredients.First();
        }
    }
}
