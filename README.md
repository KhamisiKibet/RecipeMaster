# RecipeMaster

RecipeMaster is a dynamic and sleek mobile application designed for food enthusiasts to explore, create, and store their favorite recipes. Built using .NET MAUI, the app offers a beautiful user interface, easy navigation, and features to add, edit, and delete recipes.

## Table of Contents

1. [Overview](/#overview)
2. [Target Audience](/#target-audience)
3. [Goals and Objectives](/#goals-and-objectives)
4. [Features](/#features)
5. [Technical Details](/#technical-details)
6. [Project Structure](/#project-structure)
7. [UI/UX Design](/#uiux-design)
8. [MVC Implementations](/#mvc-implementations)
9. [Getting Started](/#getting-started)
10. [License](/#license)

## Overview

RecipeMaster allows users to easily browse, add, edit, and delete recipes, providing a seamless experience for managing their recipe collection. The app also supports both dark and light themes, enhancing user customization.

## Target Audience

The primary audience for RecipeMaster includes:
- Home chefs
- Food enthusiasts
- Anyone passionate about creating and organizing their recipes

## Goals and Objectives

The main goal of RecipeMaster is to develop a modern-looking app with a beautiful user interface. The main objectives are:

- Providing a seamless experience for users to manage their recipe collection.
- Offering features to add, edit, and delete recipes with ease.
- Implementing dark and light themes for user customization.
- Ensuring easy navigation and an engaging user experience.

## Features

1. **Home Screen**:
   - Displays a list of available recipes, each showing an image, title, and description.
   - Icons to mark recipes as favorites, edit, or delete.
   - A refresh button to update the recipe list.

2. **Add Recipe Screen**:
   - A form to input recipe details: title, description, ingredients, and preparation steps.

3. **Recipe Detail Page**:
   - Shows detailed information about a selected recipe: image, title, description, and preparation steps.

4. **Accounts Page**:
   - Displays static user account information.

5. **Side Drawer Menu**:
   - Home: Contains bottom navigation for Home, Add Recipe, and Account.
   - About Us: Displays static details about the app.
   - Contact Us: Provides static contact information.
   - Settings: Allows users to set app themes (dark and light).

## Technical Details

- **Framework**: .NET MAUI
- **Languages**: XAML for UI design, C# for business logic
- **Architecture**: MVVM (Model-View-ViewModel)
- **Operations**: CRUD (Create, Read, Update, Delete)

## Project Structure

The project is structured into several directories, each serving a specific purpose:

- **Main Project Files**:
  - `App.xaml` & `App.xaml.cs`: Application entry point and setup.
  - `AppShell.xaml` & `AppShell.xaml.cs`: Navigation and shell configuration.
  - `MauiProgram.cs`: Configuration for the .NET MAUI app.

- **Cells Directory**:
  - Contains XAML files for custom cell designs like `RecipeCard.xaml`.

- **Helpers Directory**:
  - Includes utility classes like `DatabaseHelper.cs` for database operations and `Theme.cs` for managing themes.

- **Models Directory**:
  - Defines data models including `Category.cs`, `Recipe.cs`, and `Tag.cs`.

- **ViewModels Directory**:
  - Contains view models for different pages to handle business logic and UI interaction.

- **Views Directory**:
  - Holds XAML files for the app’s user interface, such as `HomePage.xaml`, `AddRecipePage.xaml`, etc.

## UI/UX Design

RecipeMaster features a sleek and modern design with:

- A home screen that presents recipes in a visually appealing card format.
- Easy-to-navigate pages for adding and viewing recipes.
- A side drawer menu for accessing different sections of the app, ensuring a smooth user experience.
- Theme settings that allow users to switch between dark and light modes to suit their preferences.

## MVC Implementations

RecipeMaster uses the MVVM (Model-View-ViewModel) pattern, a core aspect of the MVC design architecture:

- **Model**: 
  - Represents the data layer of the app.
  - Defined in the `Models` directory, which includes classes such as `Recipe.cs`, `Category.cs`, and `Tag.cs`.

- **View**:
  - Represents the UI layer of the app.
  - Defined in the `Views` directory, which contains XAML files for each screen (e.g., `HomePage.xaml`, `RecipeDetailPage.xaml`, etc.).

- **ViewModel**:
  - Acts as a bridge between the Model and View, handling the business logic.
  - Defined in the `ViewModels` directory, with view models corresponding to each View (e.g., `HomeViewModel.cs`, `RecipeDetailViewModel.cs`).

## Getting Started

### Prerequisites

- Visual Studio 2022 or later with .NET MAUI workload installed.
- .NET SDK 6.0 or later.

### Installation

1. Clone the repository:
   ```bash
   git clone https://github.com/KhamisiKibet/recipemaster.git
   ```

2. Open the solution file (RecipeMaster.sln) in Visual Studio.

3. Restore NuGet packages.

4. Build and run the application.

### License
This project is licensed under the MIT License.

Video: https://youtube.com/shorts/TstxyWGw2t0?si=_OeB7HGsVZqMnk0A
