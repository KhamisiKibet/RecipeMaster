using MvvmHelpers;
using RecipeMaster.Models;
using RecipeMaster.Services;
using System.Threading.Tasks;

namespace RecipeMaster.ViewModels
{
    public class RecipeDetailViewModel : ViewModelBase
    {
        private readonly IRecipeService _recipeService;

        public RecipeDetailViewModel(IRecipeService recipeService)
        {
            _recipeService = recipeService;
        }

        private Recipe _recipe;
        public Recipe Recipe
        {
            get => _recipe;
            set => SetProperty(ref _recipe, value);
        }

        // Expose individual properties for binding
        public string Title => Recipe?.Title;
        public string Description => Recipe?.Description;
        public string Details => Recipe?.Details;
        public int CategoryId => Recipe?.CategoryId ?? 0;
        public string Category => CategoryMapper.GetCategoryName(CategoryId);
        public string ImagePath => Recipe?.ImagePath;
        public string Tags => Recipe?.Tags ?? "#No tags found";
        public bool Favorite => Recipe?.Favorite ?? false;


        public async Task LoadRecipe(int recipeId)
        {
            Recipe = await _recipeService.GetRecipe(recipeId);
            OnPropertyChanged(nameof(Title));
            OnPropertyChanged(nameof(Description));
            OnPropertyChanged(nameof(Details));
            OnPropertyChanged(nameof(ImagePath));
            OnPropertyChanged(nameof(Tags));
            OnPropertyChanged(nameof(Favorite));
        }

        public static class CategoryMapper
        {
            private static readonly Dictionary<int, string> Categories = new Dictionary<int, string>
    {
        { 1, "Drink" },
        { 2, "Meal" },
        { 3, "Course" },
        // Add more mappings as needed
    };

            public static string GetCategoryName(int categoryId)
            {
                return Categories.TryGetValue(categoryId, out var name) ? name : "Unknown";
            }
        }

    }
}
