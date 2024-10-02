using MvvmHelpers;
using RecipeMaster.Models;
using RecipeMaster.Services;
using RecipeMaster.Views;
using System.Threading.Tasks;

namespace RecipeMaster.ViewModels;

public partial class RecipeViewModel : ViewModelBase
{
    public ObservableRangeCollection<Recipe> Recipe { get; set; }
    public ObservableRangeCollection<Grouping<string, Recipe>> RecipeGroups { get; }

    private readonly IRecipeService _recipeService;

    private bool _isBusy;

    public RecipeViewModel(IRecipeService recipeService)
    {
        Title = "Recipe";

        Recipe = new ObservableRangeCollection<Recipe>();
        RecipeGroups = new ObservableRangeCollection<Grouping<string, Recipe>>();
        _recipeService = recipeService;

        LoadMore();
    }

    [RelayCommand]
    public async Task Favorite(Recipe recipe)
    {
        if (recipe == null)
            return;

        // Toggle favorite status
        recipe.Favorite = !recipe.Favorite;

        try
        {
            // Update the recipe in the database
            await _recipeService.UpdateRecipe(recipe);

            // Show success message
            await Application.Current.MainPage.DisplayAlert("Success", $"Recipe '{recipe.Title}' favorite status updated.", "OK");
        }
        catch (Exception ex)
        {
            // Handle the error
            await Application.Current.MainPage.DisplayAlert("Error", "An error occurred while updating the recipe.", "OK");
        }

        Refresh();
    }

    [RelayCommand]
    public async Task EditRecipe(Recipe recipe)
    {
        if (recipe == null)
            return;

        // Navigate to edit page with the recipe and recipeService
        var editRecipePage = new EditRecipePage(recipe, _recipeService);
        await Shell.Current.Navigation.PushAsync(editRecipePage);

        Refresh();
    }



    [ObservableProperty]
    Recipe previouslySelected;
    [ObservableProperty]
    Recipe selectedRecipe;

    [RelayCommand]
    async Task Selected(Recipe recipe)
    {
        if (recipe == null)
            return;

        var viewModel = new RecipeDetailViewModel(_recipeService);
        await viewModel.LoadRecipe(recipe.Id);

        var recipeDetailPage = new RecipeDetailPage(viewModel);

        await AppShell.Current.Navigation.PushAsync(recipeDetailPage);
    }


    [RelayCommand]
    async Task Refresh()
    {
        IsBusy = true;

        Recipe.Clear();
        await LoadMore();

        IsBusy = false;
    }

    public bool IsBusy
    {
        get => _isBusy;
        set => SetProperty(ref _isBusy, value);
    }


    [RelayCommand]
    async Task LoadMore()
    {
        if (Recipe.Count >= 20)
            return;

        var recipes = await _recipeService.GetRecipes();
        Recipe.AddRange(recipes);

        RecipeGroups.Clear();
        var groupedRecipes = recipes.GroupBy(r => r.Description)
            .Select(g => new Grouping<string, Recipe>(g.Key, g));

        RecipeGroups.AddRange(groupedRecipes);
    }

    [RelayCommand]
    void DelayLoadMore()
    {
        LoadMore();
    }

    [RelayCommand]
    void Clear()
    {
        Recipe.Clear();
        RecipeGroups.Clear();
    }

    [RelayCommand]
    public async Task DeleteRecipe(Recipe recipe)
    {
        if (recipe == null)
            return;

        bool isConfirmed = await Application.Current.MainPage.DisplayAlert(
            "Confirm Delete",
            $"Are you sure you want to delete {recipe.Title}?",
            "Yes",
            "No");

        if (isConfirmed)
        {
            await _recipeService.RemoveRecipe(recipe.Id);
            Recipe.Remove(recipe);
            // Optionally, refresh or update the UI
            Refresh();
        }
    }
}
