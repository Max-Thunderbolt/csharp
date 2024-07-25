using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POE2024
{
    class Recipe
    {
        // Recipe class is defined. 
        // This class is used to store the data of recipes.

        string recipeName;
        int netCaloriesForRecipe;
        List<Step> steps = new List<Step>();
        List<Ingredient> ingredients = new List<Ingredient>();

        public Recipe() { } // Default constructor.

        public Recipe(string recipeName, List<Step> stepList, List<Ingredient> ingredientsList) // Overloaded constructor.
        {
            this.recipeName = recipeName;
            // Copy the list of steps and ingredients to the recipe.
            foreach (Step step in stepList)
            {
                steps.Add(step);
            }
            foreach (Ingredient ingredient in ingredientsList)
            {
                ingredients.Add(ingredient);
            }
        }

        // All accessors and mutators used from Recipe.
        public string GetRecipeName()
        {
            return recipeName;
        }

        public List<Step> getSteps()
        {
            return steps; 
        }

        public List<Ingredient> getIngredients()
        {
            return ingredients;
        }

        public void SetRecipeName(string recipeName)
        {
            this.recipeName = recipeName;
        }

        public void ClearRecipe()
        {
            // Clear the recipe by setting all the values to their default values.
            recipeName = "";
            steps.Clear();
            ingredients.Clear();
        }

        public void ScaleRecipe(double scale)
        {
            /*  This method scales the recipe by the given scale factor.
                It multiplies the quantity of each ingredient by the scale factor.
            */
            foreach (Ingredient ingredient in ingredients)
            {
                ingredient.SetQuantity(ingredient.GetQuantity() * scale);
            }
        }

        public string toString() // toString method just to make printing easier to work with later.
        {
            string ret = "Recipe name: " + recipeName +
                "\nNumber of ingredients: " + ingredients.Count() +
                "\nNumber of steps: " + steps.Count() +
                "\nCalories: " + CalculateNetCaloriesForRecipe() + 
                "\n\nIngredients: \n";

            foreach (Ingredient ingredient in ingredients) // Adding every ingredient to the string.
            {
                ret += ingredient.toString() + "\n";
            }

            ret += "\nSteps: \n";

            foreach (Step step in steps) // Adding all the steps to the string.
            {
                ret += step.GetDescription() + "\n";
            }

            return ret; // Return the string.
        }

        // Add methods to add steps, ingredients and recipes.
        public void AddStep(Step step)
        {
            steps.Add(step);
        }

        public void AddIngredient(Ingredient ingredient)
        {
            ingredients.Add(ingredient);
        }

        CalorieDelegate calorieWarningMessage = (calories) =>
        {
            if (calories > 300)
                Console.WriteLine("Warning!!! Recipe is over 300 calories.");
            return calories;
        };
        delegate int CalorieDelegate(int calories);



        // Calculate the net calories for the recipe.
        public int CalculateNetCaloriesForRecipe()
        {
            int count = 0;
            foreach (Ingredient ingredient in ingredients)
            {
                count += ingredient.GetCalories();
            }
            int netCalories = count;
            return calorieWarningMessage(count);
        }


        // Capture all the ingredients required for the recipe. (Repreciated) 
        public List<Ingredient> captureIngredients()
        {       
            Console.WriteLine("Enter the number of ingredients");
            string input = Console.ReadLine();
            int numIngredients = 0;
            try
            {
                if (input == null || input == "")
                {
                    throw new RecipeExceptions.incorrectDataReceived("Number of ingredients must not be blank!");
                } 

                // check that input only has numbers / isn't blank
                if (!input.All(char.IsDigit) || input == null || input == "")
                {
                    throw new RecipeExceptions.incorrectDataReceived("Number of ingredients must be a numerical number.");
                    Console.WriteLine("Enter the number of ingredients");
                    input = Console.ReadLine();
                }
                else
                {
                    numIngredients = Convert.ToInt32(input);
                }


                if (numIngredients > 0)
                {
                    List<Ingredient> temp = new List<Ingredient>();
                    for (int i = 0; i < numIngredients; i++)
                    {
                        Console.WriteLine("Enter the name of the ingredient");
                        string ingredientName = Console.ReadLine();
                        Console.WriteLine("Enter the measurement of the ingredient");
                        string measurement = Console.ReadLine();
                        Console.WriteLine("Enter the quantity of the ingredient");
                        double quantity = Convert.ToDouble(Console.ReadLine());
                        Console.WriteLine("Enter the number of calories this ingredient contains");
                        int calories = Convert.ToInt32(Console.ReadLine());
                        /*
                         * This code was used for part I & II.
                        Ingredient ingredient = new Ingredient(ingredientName, measurement, quantity, calories);
                        ingredients.Add(ingredient
                        */
                    }
                    return ingredients;
                }

            }
            catch (RecipeExceptions.incorrectDataReceived e)
            {
                Console.WriteLine(e.Message);
            }
            return null;
        }

        public List<Step> captureSteps()
        {
            Console.WriteLine("Enter the number of steps");
            string input = Console.ReadLine();
            int numSteps = 0;
            try
            {
                if (input == null || input == "")
                {
                    throw new RecipeExceptions.incorrectDataReceived("Number of steps must not be blank!");
                }

                // check that input only has numbers / isn't blank
                if (!input.All(char.IsDigit) || input == null || input == "")
                {
                    throw new RecipeExceptions.incorrectDataReceived("Number of ingredients must be a numerical number.");
                    Console.WriteLine("Enter the number of ingredients");
                    input = Console.ReadLine();
                } 
                else
                {
                    numSteps = Convert.ToInt32(input);
                }

                if (numSteps > 0)
                {
                    List<Step> steps = new List<Step>();
                    for (int i = 0; i < numSteps; i++)
                    {

                        Console.WriteLine("Enter the description of the step " + (i + 1));
                        string description = Console.ReadLine();
                        Step temp = new Step(description);
                        steps.Add(temp);
                    }

                    return steps;
                }
            }
            catch (RecipeExceptions.incorrectDataReceived e)
            {
                Console.WriteLine(e.Message);
            }
            return null;
        }
    }
}


