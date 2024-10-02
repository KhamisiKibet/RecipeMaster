namespace RecipeMaster.Views;

public partial class MainPage : ContentPage
{
    public MainPage(RecipeViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}