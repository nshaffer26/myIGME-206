using System;

namespace Shaffer_PE09_Q03
{
    // Class: Program
    // Author: Nicholas Shaffer
    // Date: 9/9/2020
    // Purpose: Use a delegate function to impersonate the Console.ReadLine() function when asking for user input
    class Program
    {
        delegate string ReadLine();

        // Method: Main
        // Purpose: Define a variable of my delegate type and set it equal
        static void Main(string[] args)
        {
            ReadLine line;
            line = new ReadLine(Console.ReadLine);
        }
    }
}
