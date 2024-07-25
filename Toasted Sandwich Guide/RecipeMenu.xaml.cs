using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Xml.Serialization;
using POE2024;

namespace ToastedSandwichGuide
{
    /// <summary>
    /// Interaction logic for RecipeMenu.xaml
    /// </summary>
    /// 
    // Background image: Designed by vectorpocket / Freepik, https://www.freepik.com/free-vector/cartoon-illustration-cozy-modern-kitchen-with-dinner-table-household-appliances_2890963.htm
    public partial class RecipeMenu : Window
    {
        private List<Recipe> recipes = new List<Recipe>();
        private List<string> recipeNames = new List<string>();
        private List<Ingredient> ingredients = new List<Ingredient>();
        private List<Step> steps = new List<Step>();

        public RecipeMenu()
        {
            InitializeComponent();
            showBookMenu();
        }

        private void showBookMenu()
        {
            RecipeNameLabel.Visibility = Visibility.Collapsed;
            recipeNameTextBox.Visibility = Visibility.Collapsed;
            NumberOfSteps.Visibility = Visibility.Collapsed;
            NumberOfStepsTextBox.Visibility = Visibility.Collapsed;
            NumberOfIngredients.Visibility = Visibility.Collapsed;
            NumberOfIngredientsTextBox.Visibility = Visibility.Collapsed;
            AddNumIngredientsAndNumSteps.Visibility = Visibility.Collapsed;
            ScrollDisplay.Visibility = Visibility.Collapsed;
            SaveIngredientsAndSteps.Visibility = Visibility.Collapsed;
            RecipeDisplay.Visibility = Visibility.Collapsed;
            SearchForRecipeNameButton.Visibility = Visibility.Collapsed;
            SearchRecipeButton.Visibility = Visibility.Collapsed;
            ViewRecipesButton.Visibility = Visibility.Collapsed;
            Scale.Visibility = Visibility.Collapsed;
            ScaleRecipeLabel.Visibility = Visibility.Collapsed;
            if (recipes.Count == 0)
            {
                SearchRecipeButton.Visibility = Visibility.Collapsed;
                ViewRecipesButton.Visibility = Visibility.Collapsed;
                ScaleRecipeButton.Visibility = Visibility.Collapsed;
            }
            else
            {
                SearchRecipeButton.Visibility = Visibility.Visible;
                ViewRecipesButton.Visibility = Visibility.Visible;
                ScaleRecipeButton.Visibility = Visibility.Visible;
            }
        }

        private void Close(object sender, RoutedEventArgs e)
        {
           System.Windows.Application.Current.Shutdown();
        }

        // Scale a recipe
        private void ScaleRecipe_Click(object sender, RoutedEventArgs e)
        {
            RecipeDisplay.Visibility = Visibility.Collapsed;
            RecipeNameLabel.Visibility = Visibility.Visible;
            recipeNameTextBox.Visibility = Visibility.Visible;
            Scale.Visibility = Visibility.Visible;
            ScaleRecipeLabel.Visibility = Visibility.Visible;
            NumberOfIngredientsTextBox.Visibility = Visibility.Visible;
            NumberOfIngredients.Visibility = Visibility.Visible;
            NumberOfIngredients.Content = "Scale Factor: ";
        }

        private void ScaleRecipe(string factor, string name)
        {
            Double.TryParse(factor, out double scaleFactor);
            if (name.Equals(null))
            {
                MessageBox.Show("Please enter a recipe name");
            }
            else
            {
                foreach(Recipe recipe in recipes)
                {
                    recipe.ScaleRecipe(scaleFactor);
                }
            }
        }

        // Showing recipes or a specific recipe

        private void ViewRecipesNames(object sender, RoutedEventArgs e)
        {
            RecipeDisplay.Text = ""; // Clear any previous text 
            RecipeDisplay.Visibility = Visibility.Visible;
            foreach (Recipe recipe in recipes)
            {
                RecipeDisplay.Text += recipe.GetRecipeName();
            }
        }

        private void displayRecipeDetails(string recipeName)
        {
            string recipeBuilder; 
            if (recipes.Count > 0)
            {
                // Recipe name
                recipeBuilder = "Recipe Name: ";
                var selectedRecipe = new Recipe();
                foreach(Recipe recipe in recipes)
                {
                    if (recipe.GetRecipeName().Equals(recipeName))
                    {
                        selectedRecipe = recipe;
                    }
                }
                recipeBuilder += selectedRecipe.GetRecipeName();

                // Ingredients
                recipeBuilder += "\nIngredients: \n";
                double totalCalories = 0;

                foreach (var ingredient in selectedRecipe.getIngredients())
                {
                    recipeBuilder += $"{ingredient.GetQuantity()} {ingredient.GetMeasurement()} of {ingredient.GetName()} \n[Calories: {ingredient.GetCalories()}\t Food Group: {ingredient.GetFoodGroup()}]";
                   
                    totalCalories += ingredient.GetCalories();
                }
                recipeBuilder += $"Total Calories: {totalCalories}";
                
                // Steps
                recipeBuilder += "\nSteps: ";
                int count = 1;
                foreach (var step in selectedRecipe.getSteps())
                {
                    recipeBuilder += $"{count}) {step.GetDescription()}";
                    count++;
                }

                // Calorie warning
                if (totalCalories > 300)
                {
                    recipeBuilder += $"YOU HAVE EXCEEDED YOUR CALORIE INTAKE OF 300!!!\nConsuming large amounts of calories can be harmful to your health\nPlease try scaling the recipe by 0,5";
                }
                else
                {
                    recipeBuilder += $"\nThis recipe is under 300 calories, which is a healthy calorie limit for a meal. Eating meals under 300 calories can aid in weight loss, and can also improve mental health.";
                }
                RecipeDisplay.Text = recipeBuilder;
            }
            else
            {
                // No record found 
                recipeBuilder = "No recipes found in recipe book.";
                RecipeDisplay.Text = recipeBuilder;
            }
        }

        private void SearchRecipe_Click(object sender, RoutedEventArgs e)
        {
            SearchRecipe(recipeNameTextBox.Text);
        }

        private void SearchRecipe(string recipeName)
        {
            if (recipeNameTextBox.Text == "")
            {
                MessageBox.Show("Please enter a recipe name");
            }
            else
            {
                RecipeDisplay.Text = ""; // Clear previous text

                // Hide and show UI elements
                RecipeDisplay.Visibility = Visibility.Visible;
                RecipeNameLabel.Visibility = Visibility.Collapsed;
                recipeNameTextBox.Visibility = Visibility.Collapsed;
                SearchForRecipeNameButton.Visibility = Visibility.Collapsed;

                // Display recipe details
                displayRecipeDetails(recipeNameTextBox.Text);
            } 
        }

        // Creating a recipe 
        private void AddRecipe_Click(object sender, RoutedEventArgs e)
        {
            // Hide and show UI elements
            RecipeNameLabel.Visibility = Visibility.Visible;
            recipeNameTextBox.Visibility = Visibility.Visible;
            NumberOfSteps.Visibility = Visibility.Visible;
            NumberOfStepsTextBox.Visibility = Visibility.Visible;
            NumberOfIngredients.Visibility = Visibility.Visible;
            NumberOfIngredientsTextBox.Visibility = Visibility.Visible;
            AddNumIngredientsAndNumSteps.Visibility = Visibility.Visible;
            RecipeDisplay.Visibility = Visibility.Collapsed;
        }

        private Ingredient AddIngredients()
        {
            //create a panel --> add boxes --> input
            StackPanel ingredPanel = new StackPanel()
            {
                Orientation = Orientation.Horizontal,
                Margin = new Thickness(0, 0, 0, 10)
            };

            TextBox textboxIngredName = new TextBox() { Width = 100 };
            TextBox textboxQuantity = new TextBox() { Width = 100 };
            TextBox textboxUnit = new TextBox() { Width = 100 };
            TextBox textboxCalories = new TextBox() { Width = 100 };
            ComboBox comboFoodGroup = new ComboBox() { Width = 100 };
            comboFoodGroup.Items.Add("Vegetables");
            comboFoodGroup.Items.Add("Fruits");
            comboFoodGroup.Items.Add("Grains");
            comboFoodGroup.Items.Add("Protein Foods");
            comboFoodGroup.Items.Add("Dairy");
            comboFoodGroup.Items.Add("Oils and Solid Fats");
            comboFoodGroup.Items.Add("Added Sugars");
            comboFoodGroup.Items.Add("Beverages");

            ingredPanel.Children.Add(new TextBlock()
            { Name = "IngredientName", Text = "Ingredient Name: ", VerticalAlignment = VerticalAlignment.Center });
            ingredPanel.Children.Add(textboxIngredName);

            ingredPanel.Children.Add(new TextBlock()
            { Text = "Quantity: ", VerticalAlignment = VerticalAlignment.Center });
            ingredPanel.Children.Add(textboxQuantity);

            ingredPanel.Children.Add(new TextBlock()
            { Text = "Unit: ", VerticalAlignment = VerticalAlignment.Center });
            ingredPanel.Children.Add(textboxUnit);

            ingredPanel.Children.Add(new TextBlock()
            { Text = "Calories: ", VerticalAlignment = VerticalAlignment.Center });
            ingredPanel.Children.Add(textboxCalories);

            ingredPanel.Children.Add(new TextBlock()
            { Text = "Food Group: ", VerticalAlignment = VerticalAlignment.Center });
            ingredPanel.Children.Add(comboFoodGroup);
            Double.TryParse(textboxQuantity.Text, out double quantity);
            int.TryParse(textboxCalories.Text, out int calories);
            pnlDisplay.Children.Add(ingredPanel);
            return new Ingredient(textboxIngredName.Text, textboxUnit.Text, quantity, calories, comboFoodGroup);
        }

        private Step AddSteps()
        {
            // Create a panel --> add boxes --> input
            StackPanel stepPanel = new StackPanel()
            {
                Orientation = Orientation.Horizontal,
                Margin = new Thickness(0, 0, 0, 10)
            };

            TextBox textboxSteps = new TextBox() { Width = 500, Height = 20 };
            stepPanel.Children.Add(new TextBlock()
            {

                Text = "Step: ",

                VerticalAlignment = VerticalAlignment.Center

            });
            stepPanel.Children.Add(textboxSteps);       
            pnlDisplay.Children.Add(stepPanel);
            return new Step(textboxSteps.Text);
        }

        private void ShowRecipeNameField(object sender, RoutedEventArgs e)
        {
            RecipeDisplay.Visibility = Visibility.Collapsed;
            RecipeNameLabel.Visibility = Visibility.Visible;
            recipeNameTextBox.Visibility = Visibility.Visible;
            SearchForRecipeNameButton.Visibility = Visibility.Visible;
        }

        private void AddNumIngredientsAndSteps(object sender, RoutedEventArgs e)
        {
            if (NumberOfIngredientsTextBox.Text == "" || NumberOfStepsTextBox.Text == "")
            {
                MessageBox.Show("Please enter the number of ingredients and steps");
            }
            else
            {
                CreateRecipeFields();
            }
        }

        private void CreateRecipeFields()
        {
            // Show UI elements 
            ScrollDisplay.Visibility = Visibility.Visible;
            SaveIngredientsAndSteps.Visibility = Visibility.Visible;

            // Capture ingredients
            if (int.TryParse(NumberOfIngredientsTextBox.Text, out int numIngredients))
            {
                for (int i = 0; i < Convert.ToInt32(NumberOfIngredientsTextBox.Text); i++)
                {
                    ingredients.Add(AddIngredients());
                }
            }
            
            // Capture steps 
            if (int.TryParse(NumberOfStepsTextBox.Text, out int numSteps))
            {
                for (int i = 0; i < Convert.ToInt32(NumberOfStepsTextBox.Text); i++)
                {
                    steps.Add(AddSteps());
                }
            } 
        }

        private void AddNumIngredientsAndNumSteps_Click(object sender, RoutedEventArgs e)
        {
            ProcessRecipe();

            // Clear all fields after processing
            recipeNameTextBox.Text = "";
            NumberOfIngredientsTextBox.Text = "";
            NumberOfStepsTextBox.Text = "";
            pnlDisplay.Children.Clear();
        }

        private void ProcessRecipe()
        {
            /*
             * PROCCESSING
             * ~~~~~~~~~~~~
             * 1. process data from CreateRecipeFields 
             * 2. create temporary Recipe object, recipe.
             * 3. add recipe to recipes. 
             */

            string recipeName = recipeNameTextBox.Text;
            int numberOfSteps = Convert.ToInt32(NumberOfStepsTextBox.Text);
            int numberOfIngredients = Convert.ToInt32(NumberOfIngredientsTextBox.Text);

            // Adding ingredients and steps
            CreateRecipeFields();

            // Storing recipe
            Recipe recipe = new Recipe(recipeName, steps, ingredients);     
            recipes.Add(recipe);

            // Reset display
            showBookMenu();
        }

        private void recipeNameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
