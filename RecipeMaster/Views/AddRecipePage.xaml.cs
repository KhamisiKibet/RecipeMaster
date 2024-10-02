using RecipeMaster.ViewModels;
using RecipeMaster.Models;

namespace RecipeMaster.Views;
public partial class AddRecipePage : ContentPage
{
    public AddRecipePage(AddRecipeViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }

    private void OnCategorySelected(object sender, EventArgs e)
    {
        if (BindingContext is AddRecipeViewModel vm && sender is Picker picker && picker.SelectedItem is Category selectedCategory)
        {
            vm.SelectedCategoryId = selectedCategory.Id;
        }
    }
}