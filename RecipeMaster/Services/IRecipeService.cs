using RecipeMaster.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RecipeMaster.Services
{
    public interface IRecipeService
    {
        Task AddRecipe(Recipe recipe); // Updated to accept the entire Recipe object
        Task<IEnumerable<Recipe>> GetRecipes(); // Adjusted method name for consistency
        Task<Recipe> GetRecipe(int id);
        Task RemoveRecipe(int id);
        Task UpdateRecipe(Recipe recipe);
    }
}
