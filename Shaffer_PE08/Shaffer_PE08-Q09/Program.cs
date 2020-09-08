using System;

namespace Shaffer_PE08_Q09
{
    // Class: Program
    // Author: Nicholas Shaffer
    // Date: 09/08/2020
    // Purpose: Place double quotes around each word in a string
    class Program
    {
        // Method: Main
        // Purpose: Ask the user for a string and place double-quotes around each word of that string
        static void Main(string[] args)
        {
            // Iniitialize the input string
            string input = "";

            // Initialize the updated string
            string newInput = "";

            // Ask the user for a string
            Console.WriteLine("Please enter a string");
            input = Console.ReadLine();

            // Split the string at the spaces and send each word into an array
            string[] words = input.Split(' ');

            // Construct the new string
            for (int i = 0; i < words.Length; i++)
            {
                newInput += "\"\"" + words[i] + "\"\"";

                // Re-Add the spaces between words, but skip the last word so there isn't a space at the end
                if(i != words.Length - 1)
                {
                    newInput += " ";
                }
            }

            // Print the updaded string to the console
            Console.WriteLine("\nI fixed it for you:\n" + newInput + "\n");
        }
    }
}
