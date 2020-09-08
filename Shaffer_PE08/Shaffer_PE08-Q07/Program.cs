using System;

namespace Shaffer_PE08_Q07
{
    // Class: Program
    // Author: Nicholas Shaffer
    // Date: 9/07/2020
    // Purpose: Accept a string from the user and output that string with the characters in reverse order
    class Program
    {
        // Method: Main
        // Purpose: Ask the user for a string, reverse the order of the characters in that string, and print the new string
        //  to the console
        static void Main(string[] args)
        {
            // Initialize an input string
            string input = "";

            // Initialize the reverse of the input string
            string revInput = "";

            // Ask the user for a string
            Console.WriteLine("Please enter a string");
            input = Console.ReadLine();

            // Copy the input into a char array
            char[] charInput = input.ToCharArray();

            // Reverse the order of the input
            for(int i = charInput.Length - 1; i >= 0; i--)
            {
                revInput += charInput[i];
            }

            // Tell the user what they entered and what it is reversed
            Console.Write("\nYou entered ");
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.White;
            Console.WriteLine(input);
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write("\nReversed, it is ");
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.White;
            Console.WriteLine(revInput + "\n");
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
        }
    }
}
