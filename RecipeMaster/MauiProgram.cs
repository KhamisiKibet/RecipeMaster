using Microsoft.Extensions.Logging;
using CommunityToolkit.Maui;
using Microsoft.Extensions.DependencyInjection;
using RecipeMaster.Views;
using CommunityToolkit.Maui.Core;
using RecipeMaster.Services;

[assembly: XamlCompilation(XamlCompilationOptions.Skip)]
namespace RecipeMaster;
public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder.UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                fonts.AddFont("Font Awesome 6 Free-Regular-400.otf", "FAR");
                fonts.AddFont("Font Awesome 6 Free-Solid-900.otf", "FAS");
                fonts.AddFont("Font Awesome 6 Brands-Regular-400.otf", "FAB");
            })
            .UseMauiCommunityToolkit();
#if DEBUG
        builder.Logging.AddDebug();
#endif

        builder.Services.AddSingleton<App>();
        builder.Services.AddSingleton<IRecipeService, RecipeService>();
        builder.Services.AddSingleton<IEnvironment, RecipeMaster.Platforms.Environment>();
        builder.Services.AddSingleton<Toast, RecipeMaster.Platforms.Toaster>();
        builder.Services.AddSingleton<Theme>();

        builder.Services.AddTransient<AddRecipeViewModel>();
        builder.Services.AddTransient<RecipeViewModel>();


        builder.Services.AddTransient<AddRecipePage>();
        builder.Services.AddTransient<MainPage>();
        builder.Services.AddTransient<SettingsPage>();
        builder.Services.AddTransient<RecipeDetailPage>();
        builder.Services.AddTransient<EditRecipePage>();

        return builder.Build();
    }
}