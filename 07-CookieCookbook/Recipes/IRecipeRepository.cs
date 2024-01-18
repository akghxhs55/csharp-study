namespace CookieCookbook.Recipes;

public interface IRecipeRepository
{
    List<Recipe> Read(string filepath);
    void Write(string filepath, IEnumerable<Recipe> recipes);
}
