using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shaffer_PE08_Q08
{
    // Class: Program
    // Author: Nicholas Shaffer
    // Date: 9/07/2020
    // Purpose: Accept a string and replace all occurrences of the string "no" with "yes"
    class Program
    {
        // Method: Main
        // Purpose: Ask the user for a string, and replace all instances of " no " with " yes "
        static void Main(string[] args)
        {
            // Initialize a string for the user input
            string input = "";

            // The value we are looking to replace
            string oldVal = "no";

            // The value that will do the replacing
            string newVal = "yes";

            // The string with the replaced values
            string replacedInput = "";

            // Ask the user for a string and set it equal to input
            Console.WriteLine("Please input a string");
            input = Console.ReadLine();

            // Replace all instances of oldVal with newVal, including within other words
            replacedInput = input.Replace(oldVal, newVal);

            // Write the new value to the console
            Console.WriteLine("\nI think this sounds better:\n" + replacedInput + "\n");
        }
    }
}
