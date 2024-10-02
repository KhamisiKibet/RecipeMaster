using Microsoft.Maui.Controls;
using RecipeMaster.ViewModels;

namespace RecipeMaster.Views
{
    public partial class RecipeDetailPage : ContentPage
    {
        public RecipeDetailPage()
        {
            InitializeComponent();
        }

        public RecipeDetailPage(RecipeDetailViewModel viewModel) : this()
        {
            BindingContext = viewModel;
        }
    }
}
