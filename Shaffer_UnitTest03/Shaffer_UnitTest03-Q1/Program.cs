using System;
using System.Text.RegularExpressions;

// Author: Nicholas Shaffer
// Date: 11/16/2020
namespace Shaffer_UnitTest03_Q1
{
    // Class: Program
    // Purpose: Prompt a user for a string and decide if it is a palindrome
    class Program
    {
        // Method: Main
        // Purpose: Prompt the user for a string, tell them how many letters are in it, return it in reverse
        //    order, and tell them if it is a palindrome
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a string:");

            // The user's string, including punctuation
            string input = Console.ReadLine();

            // Remove everything except alphabetic characters from the string using string regex
            Regex regex = new Regex("[^a-zA-Z]");
            string inputAlphOnly = regex.Replace(input, "");

            // Print out the number of alphabetic characters
            Console.WriteLine();
            Console.WriteLine($"Thank you! Your string has {inputAlphOnly.Length} alphabetic characters.");

            // Convert the string to a  char array, and then revers it and convert it back
            char[] inputReversedChar = input.ToCharArray();
            Array.Reverse(inputReversedChar);
            string inputReversedString = String.Concat(inputReversedChar);

            // Print out the reversed string
            Console.WriteLine();
            Console.WriteLine($"Reversed, your string is:\n{inputReversedString}");

            // Is this a palindrome? Remove all non alphabetic characters and ignore case to compare strings
            if(inputAlphOnly.ToLower().Equals(regex.Replace(inputReversedString, "").ToLower()))
            {
                // It is a palindrome
                Console.WriteLine("This is a palindrome");
            }
            else
            {
                // It isn't a palindrome
                Console.WriteLine("This isn't a palindrome");
            }
            Console.WriteLine();
        }
    }
}
