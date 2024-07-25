using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POE2024
{
    class Step
    {
        // Step class is defined.
        // This class is used to store the steps of a recipe.

        string description;

        public Step(string description) // Overloaded constructor.
        {
            this.description = description;
        }

        // Only accessors used from Step.

        public string GetDescription()
        {
            return description;
        }
    }
}
