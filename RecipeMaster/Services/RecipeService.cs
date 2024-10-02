using SQLite;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Maui.Storage; // For FileSystem
using RecipeMaster.Models;

namespace RecipeMaster.Services
{
    public class RecipeService : IRecipeService
    {
        private SQLiteAsyncConnection _db;

        // Initialize the database connection
        private async Task Init()
        {
            if (_db != null)
                return;

            var databasePath = Path.Combine(FileSystem.AppDataDirectory, "RecipeMaster.db3");
            _db = new SQLiteAsyncConnection(databasePath);
            await _db.CreateTableAsync<Recipe>();
        }

        // Add a recipe
        public async Task AddRecipe(Recipe recipe)
        {
            await Init();
            await _db.InsertAsync(recipe);
        }

        // Remove a recipe by ID
        public async Task RemoveRecipe(int id)
        {
            await Init();
            await _db.DeleteAsync<Recipe>(id);
        }

        // Get all recipes
        public async Task<IEnumerable<Recipe>> GetRecipes()
        {
            await Init();
            return await _db.Table<Recipe>().ToListAsync();
        }

        // Get a recipe by ID
        public async Task<Recipe> GetRecipe(int id)
        {
            await Init();
            return await _db.Table<Recipe>()
                .FirstOrDefaultAsync(r => r.Id == id);
        }

        // Update a recipe
        public async Task UpdateRecipe(Recipe recipe)
        {
            await Init();
            await _db.UpdateAsync(recipe);
        }
    }
}
