using System;

namespace Shaffer_PE03
{
    // Class: Program
    // Author: Nicholas Shaffer
    // Date: 8/28/2020
    // Purpose: Compute the product of 4 integers given by a user
    class Program
    {
        // Const variable to determine how many integers to ask for
        const int ARR_SIZE = 4;

        // Method: Main
        // Purpose: Gather integers from user, compute product, and print result
        static void Main(string[] args)
        {
            // Array to hold integers gathered from user
            int[] nums = new int[ARR_SIZE];

            // Boolean to denote whether the user entered a valid integer
            bool isValidInt = false;

            // Print to the console the purpose of this program and warn user how many integers
            //  they'll need to enter
            Console.WriteLine($"This is a program to compute the product of {ARR_SIZE} integers");

            // Loop until all integers have been gathered from the user
            for(int i = 0; i < nums.Length; i++)
            {
                // Let the user know how many integers they have entered and how many are left
                Console.WriteLine($"Enter integer {i + 1} of {ARR_SIZE}");

                // do-while loop to make sure the user is entering a valid integer
                do
                {
                    try
                    {
                        // Try to convert string input to an integer
                        nums[i] = Convert.ToInt32(Console.ReadLine());
                        // If no error, the user entered a valid integer and can exit the loop
                        isValidInt = true;
                    }
                    catch
                    {
                        // Catch any errors and tell the user to enter an integer
                        Console.WriteLine("Please enter an integer");
                        isValidInt = false;
                    }
                }
                while (!isValidInt);
                
                // Need to set this back to false in order to ask for another integer
                isValidInt = false;
            }

            // Remind the user of the integers they entered
            Console.Write("The product of ");

            // Begin to compute the product, declare as first value in array
            int product = nums[0];

            // Loop to compute the product of the rest of the integers
            for(int i = 0; i < nums.Length; i++)
            {
                // Continue to remind user of the integers they entered
                Console.Write($" {nums[i]} ");

                // Need to skip the first index because it is already included in the product
                if(i != 0)
                {
                    // Continue to compute the product (product = product * nums[i])
                    product *= nums[i];
                }
            }

            // Print out the product and change the colors to distinguish the answer
            Console.WriteLine("is:");
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine(product + "\n\n");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
