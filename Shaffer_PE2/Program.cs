using System;

//Do you mind if I renamed the project?
namespace Shaffer_PE2
{
    // Class Program
    // Author: David Schuh
    // Purpose: Bug squashing exercise
    // Restrictions: None
    class Program
    {
        // Method: Main
        // Purpose: Loop through the numbers 1 through 10
        // Output N/(N-1) for all 10 numbers
        // and list all numbers processed
        // Restrictions: None
        static void Main(string[] args)
        {
            // declare int counter
            // ------ START FIX ------
            // Must have a semicolon
            //int i = 0
            int i = 0;
            // ------ END FIX ------

            // declare string to hold all numbers
            string allNumbers = null;

            // loop through the numbers 1 through 10
            // ------ START FIX ------
            // Will not reach 10
            //for (i = 1; i < 10; ++i) {
            for (i = 1; i <= 10; ++i)
            {
            // ------ END FIX ------

                // declare string to hold all numbers
                // ------ START FIX ------
                // Wrong scope
                //string allNumbers = null;
                // Moved to line 27
                // ------ END FIX ------

                // output explanation of calculation
                // ------ START FIX ------
                // String not formatted correctly
                //Console.Write(i + "/" + i - 1 + " = ");
                Console.Write(i + "/" + (i - 1) + " = ");
                // ------ END FIX ------

                // output the calculation based on the numbers
                // ------ START FIX ------
                // Divide by zero error when i = 1
                //Console.WriteLine(i / (i - 1));
                try
                {
                    Console.WriteLine(i / (i - 1));
                }
                catch
                {
                    Console.WriteLine("Undefined");
                }
                // ------ END FIX ------

                // concatenate each number to allNumbers
                allNumbers += i + " ";

                // increment the counter
                // ------ START FIX ------
                // Counter already incremented in for loop
                //i = i + 1;
                // Code removed
                // ------ END FIX ------
            }
            // output all numbers which have been processed
            // ------ START FIX ------
            // Incorrect concatenation
            //Console.WriteLine("These numbers have been processed: " allNumbers);
            Console.WriteLine("These numbers have been processed: " + allNumbers);
            // ------ END FIX ------
        }
    }
}