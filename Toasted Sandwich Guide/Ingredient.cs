using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace POE2024
{
    class Ingredient
    {
        // Ingredient class is defined.
        // Used to store the ingredients of a recipe.

        string name = "", measurement = ""; // Leave them as blank strings
        ComboBox foodGroup;
        double quantity, originalQuantity;
        int calories;

        public Ingredient(string name, string measurement, double quantity, int calories, ComboBox foodGroup) // Overloaded constructor.
        {
            this.name = name;
            this.measurement = measurement;
            this.quantity = quantity;
            this.calories = calories;
            this.foodGroup = foodGroup;
        }

        // All accessors and mutators used from Ingredient.
        public string GetName()
        {
            return name;
        }

        public string GetMeasurement()
        {
            return measurement;
        }

        public double GetQuantity()
        {
            return quantity;
        }

        public double getOriginalQuantity()
        {
            return originalQuantity;
        }

        public int GetCalories()
        {
            return calories;
        }

        public ComboBox GetFoodGroup()
        {
            return foodGroup;
        }

        public void SetQuantity(double quantity)
        {
            this.quantity = quantity;
        }

        public void setOriginalQuantity(double quantity)
        {
            originalQuantity = quantity;
        }

        public string toString() // toString method just to make printing easier to work with later.
        {
            return name + " " + quantity + " " + measurement + "\tFood Group: " + foodGroup + "\tCalories: " + calories + "\n";
        }
    }
}
