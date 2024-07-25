using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POE2024
{
    class RecipeExceptions : Exception
    {
        // Custom exception class, this class will be used for all excpetions in the program.
        public class incorrectDataReceived : Exception
        {
            public incorrectDataReceived()
            {
            }
            public incorrectDataReceived(string message) : base(message)
            {
            }
            public incorrectDataReceived(string message, Exception inner) : base(message, inner)
            {
            }
        }
    }
}