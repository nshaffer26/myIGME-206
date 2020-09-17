using System;

// Note: Same as Shaffer_PE09-Q03
namespace Shaffer_UnitTest01_Q03
{
    // Class: Program
    // Author: Nicholas Shaffer
    // Date: 9/9/2020
    // Purpose: Use a delegate function to impersonate the Console.ReadLine() function when asking for user input
    class Program
    {
        // Define the delegate method data type
        delegate string DelegateReadLine();

        // Method: Main
        // Purpose: Define a variable of my delegate type and set it equal
        static void Main(string[] args)
        {
            // Declare a variable of type ReadLine 
            DelegateReadLine line;

            // Set the variable equal to the method I want to delegate, i.e., Console.ReadLine()
            line = new DelegateReadLine(Console.ReadLine);

            // Ask the user for a string
            Console.WriteLine("Enter a string");
            string input = line();

            // Put that thing back where it came from
            Console.WriteLine($"\n{input}\n");
        }
    }
}