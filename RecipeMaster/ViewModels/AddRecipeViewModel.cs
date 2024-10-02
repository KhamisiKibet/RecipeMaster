using System.Collections.Generic;
using System.Threading.Tasks;
using CommunityToolkit.Maui.Core;
using Microsoft.Maui.Controls;
using RecipeMaster.Models;
using RecipeMaster.Platforms;
using RecipeMaster.Services;

namespace RecipeMaster.ViewModels;

[QueryProperty(nameof(Title), nameof(Title))]
public partial class AddRecipeViewModel : ViewModelBase
{
    [ObservableProperty]
    string title;

    [ObservableProperty]
    string description;

    [ObservableProperty]
    string details;

    [ObservableProperty]
    string imagePath;

    [ObservableProperty]
    int selectedCategoryId;

    [ObservableProperty]
    List<string> selectedTags = new List<string>();

    [ObservableProperty]
    bool isFavorite;

    [ObservableProperty]
    DateTime dateAdded = DateTime.Now;

    [ObservableProperty]
    string selectedImage;

    [ObservableProperty]
    Category selectedCategory;


    public List<Category> Categories { get; set; }
    public List<Tag> Tags { get; set; }

    IRecipeService RecipeService;
    Toast toaster;

    public AddRecipeViewModel(IRecipeService recipeService, Toast toaster)
    {
        Title = "Add Recipe";
        RecipeService = recipeService;
        this.toaster = toaster;

        // Initialize categories and tags
        Categories = new List<Category>
        {
            new Category { Id = 1, Name = "Drinks" },
            new Category { Id = 2, Name = "Meals" },
            new Category { Id = 3, Name = "Courses" },
        };

        Tags = new List<Tag>
        {
            new Tag { Name = "Beverages" },
            new Tag { Name = "Smoothies" },
            new Tag { Name = "Cocktails" },
            new Tag { Name = "Mocktails" },
            new Tag { Name = "Breakfast" },
            new Tag { Name = "Lunch" },
            new Tag { Name = "Dinner" },
            new Tag { Name = "Brunch" },
            new Tag { Name = "Appetizers" },
            new Tag { Name = "Main Courses" },
            new Tag { Name = "Desserts" },
            new Tag { Name = "Side Dishes" },
            new Tag { Name = "Vegetarian" },
            new Tag { Name = "Vegan" },
            new Tag { Name = "Gluten-Free" },
            new Tag { Name = "Keto" },
            new Tag { Name = "Paleo" },
            new Tag { Name = "Low-Carb" },
            new Tag { Name = "Asian" },
            new Tag { Name = "Italian" },
            new Tag { Name = "Mexican" },
            new Tag { Name = "Indian" },
            new Tag { Name = "Mediterranean" },
            new Tag { Name = "American" },
            new Tag { Name = "Party" },
            new Tag { Name = "Holiday" },
            new Tag { Name = "Picnic" },
            new Tag { Name = "Barbecue" },
            new Tag { Name = "Comfort Food" },
            new Tag { Name = "Seafood" },
            new Tag { Name = "Poultry" },
            new Tag { Name = "Beef" },
            new Tag { Name = "Pork" },
            new Tag { Name = "Vegetables" },
            new Tag { Name = "Fruits" },
            new Tag { Name = "Baking" },
            new Tag { Name = "Grilling" },
            new Tag { Name = "Slow Cooking" },
            new Tag { Name = "Instant Pot" },
            new Tag { Name = "Stir-Frying" }
        };
    }

    [RelayCommand]
    async Task Save()
    {
        // Validate required fields
        if (string.IsNullOrWhiteSpace(Title))
        {
            toaster?.MakeToast("Recipe Name is required.");
            return;
        }

        if (string.IsNullOrWhiteSpace(Description))
        {
            toaster?.MakeToast("Description is required.");
            return;
        }

        if (SelectedCategoryId <= 0)
        {
            toaster?.MakeToast("Please select a category.");
            return;
        }

        if (string.IsNullOrWhiteSpace(ImagePath))
        {
            toaster?.MakeToast("Image is required.");
            return;
        }

        // Create the recipe object
        var recipe = new Recipe
        {
            Title = Title,
            Description = Description,
            Details = Details,
            ImagePath = ImagePath,
            CategoryId = SelectedCategoryId,
            Tags = string.Join(",", SelectedTags), // Assuming comma-separated values
            Favorite = IsFavorite,
            DateAdded = DateTime.Now.ToString("yyyy-MM-dd")
        };

        try
        {
            // Attempt to add the recipe
            await RecipeService.AddRecipe(recipe);

            // Show success message
            toaster?.MakeToast("Recipe added successfully!");

            // Clear the form fields
            ClearForm();

            // Navigate back to the previous page
            await Shell.Current.GoToAsync("..");
        }
        catch (Exception ex)
        {
            // Log the exception and show an error message
            // LogError(ex); // You might want to implement logging

            toaster?.MakeToast("An error occurred while saving the recipe. Please try again.");
        }
    }

    void ClearForm()
    {
        Title = string.Empty;
        Description = string.Empty;
        Details = string.Empty;
        ImagePath = string.Empty;
        SelectedCategoryId = 0;
        SelectedTags.Clear();
        IsFavorite = false;
    }

    [RelayCommand]
    async Task PickImage()
    {
        var status = await Permissions.RequestAsync<Permissions.StorageRead>();

        if (status != PermissionStatus.Granted)
        {
            // Show a toast message if permission is not granted
            toaster?.MakeToast("Permission to access storage was not granted.");
            return;
        }

        // Logic to pick image from gallery or camera
        var result = await FilePicker.PickAsync(new PickOptions
        {
            PickerTitle = "Please select an image",
            FileTypes = FilePickerFileType.Images
        });

        if (result != null)
        {
            ImagePath = result.FullPath; // Update ImagePath property
            SelectedImage = result.FullPath; // Use result.FileName or result.FullPath
        }
    }
}
