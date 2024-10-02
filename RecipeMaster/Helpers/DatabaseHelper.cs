using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;
using RecipeMaster.Models;

namespace RecipeMaster.Helpers;

public class DatabaseHelper
{
    private readonly SQLiteAsyncConnection _database;

    public DatabaseHelper(string dbPath)
    {
        _database = new SQLiteAsyncConnection(dbPath);
        _database.CreateTableAsync<Recipe>().Wait();
    }

    public Task<List<Recipe>> GetRecipesAsync()
    {
        return _database.Table<Recipe>().ToListAsync();
    }

    public Task<int> SaveRecipeAsync(Recipe recipe)
    {
        if (recipe.Id != 0)
        {
            return _database.UpdateAsync(recipe);
        }
        else
        {
            return _database.InsertAsync(recipe);
        }
    }

    public Task<int> DeleteRecipeAsync(Recipe recipe)
    {
        return _database.DeleteAsync(recipe);
    }
}
