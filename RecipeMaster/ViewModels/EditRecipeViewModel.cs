using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RecipeMaster.Models;
using RecipeMaster.Services;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Storage;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace RecipeMaster.ViewModels
{
    public partial class EditRecipeViewModel : ViewModelBase
    {
        private readonly IRecipeService _recipeService;

        public EditRecipeViewModel(Recipe recipe, IRecipeService recipeService)
        {
            _recipeService = recipeService;
            Recipe = recipe;

            // Load categories and tags (this should ideally be done asynchronously)
            LoadCategoriesAndTags();
        }

        public Recipe Recipe { get; set; }

        [ObservableProperty]
        string selectedImage;

        [ObservableProperty]
        List<Category> categories;

        [ObservableProperty]
        List<Tag> tags;

        [ObservableProperty]
        Category selectedCategory;

        [ObservableProperty]
        List<Tag> selectedTags;

        [RelayCommand]
        async Task Save()
        {
            if (Recipe == null)
                return;

            try
            {
                // Update recipe with selected category ID and tags
                Recipe.CategoryId = SelectedCategory.Id; // Use CategoryId for the recipe
                Recipe.Tags = string.Join(",", SelectedTags.Select(t => t.Name)); // Assuming comma-separated values

                // Update the recipe in the database
                await _recipeService.UpdateRecipe(Recipe);

                // Show success message
                await Application.Current.MainPage.DisplayAlert("Success", "Recipe updated successfully.", "OK");

                // Navigate back to the previous page
                await Shell.Current.GoToAsync("..");
            }
            catch (Exception ex)
            {
                // Handle the error
                await Application.Current.MainPage.DisplayAlert("Error", "An error occurred while updating the recipe.", "OK");
            }
        }


        [RelayCommand]
        async Task PickImage()
        {
            var status = await Permissions.RequestAsync<Permissions.StorageRead>();

            if (status != PermissionStatus.Granted)
            {
                await Application.Current.MainPage.DisplayAlert("Permission Denied", "Permission to access storage was not granted.", "OK");
                return;
            }

            var result = await FilePicker.PickAsync(new PickOptions
            {
                PickerTitle = "Please select an image",
                FileTypes = FilePickerFileType.Images
            });

            if (result != null)
            {
                Recipe.ImagePath = result.FullPath;
                SelectedImage = result.FullPath; // Use result.FileName or result.FullPath
                OnPropertyChanged(nameof(SelectedImage)); // Notify that SelectedImage has changed
            }
        }

        void LoadCategoriesAndTags()
        {
            // Initialize categories and tags (this should ideally be done asynchronously)
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

            // Initialize selected category and tags based on the recipe
            SelectedCategory = Categories.FirstOrDefault(c => c.Id == Recipe.CategoryId);
            SelectedTags = Tags.Where(t => Recipe.Tags.Split(',').Contains(t.Name)).ToList();
        }
    }
}
