using RecipeMaster.Models;
using RecipeMaster.Services;
using RecipeMaster.ViewModels;

namespace RecipeMaster.Views
{
    public partial class EditRecipePage : ContentPage
    {
        public EditRecipePage(Recipe recipe, IRecipeService recipeService)
        {
            InitializeComponent();
            BindingContext = new EditRecipeViewModel(recipe, recipeService);
        }
    }
}
