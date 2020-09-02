using System;

namespace Shaffer_PE04_Q2
{
    // Class: Program
    // Author: Nicholas Shaffer
    // Date: 8/29/2020
    // Purpose: Ask the user for two numbers such that one is greater than 10 and the other is less than 10.
    class Program
    {
        // Method: Main
        // Purpose: Ask for and then print two integers, one of which is greater than 10 and the other less than 10
        static void Main(string[] args)
        {
            // Initialize two variables which will hold the user-entered integers
            int var1 = 0;
            int var2 = 0;

            // Ask the user for two integers following stated parameters
            Console.WriteLine("Enter two integers");

            // If either of these are false, the user has entered either a non-integer, or an integer not following
            // the given parameters
            bool intValue = false;
            bool validInts = false;

            // Continue to ask the user for two integers until they give some that follow the given parameters
            do
            {
                // Attempt to convert user-entered values into integers
                try
                {
                    // Convert and store user-input
                    var1 = Convert.ToInt32(Console.ReadLine());
                    var2 = Convert.ToInt32(Console.ReadLine());

                    // Valid integers where entered
                    intValue = true;

                    // Check to maker sure the user entered integers that follow parameters
                    if(!((var1 > 10) ^ (var2 > 10)))
                    {
                        // Invalid input, ask again
                        validInts = false;
                        Console.WriteLine($"You entered {var1} and {var2}. Enter two new integers");
                    }
                    else
                    {
                        // Valid input
                        validInts = true;
                    }
                }
                // Catch any errors
                catch
                {
                    // Non-Valid integers were entered
                    Console.WriteLine("You must enter two integers");
                    intValue = false;
                }
            }
            while(!intValue || !validInts);

            // Thank the user and remind them of the integers they entered
            Console.WriteLine($"\nThank you, you entered {var1} and {var2}\n");
        }
    }
}
