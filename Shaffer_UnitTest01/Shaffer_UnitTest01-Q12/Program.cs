using System;

namespace Shaffer_UnitTest01_Q12
{
    // Class: Program
    // Author: Nicholas Shaffer
    // Date: 9/16/2020
    // Purpose: Use a reference to raise a user's salary
    class Program
    {
        // Method: Main
        // Purpose: Ask the user for their name and congratulate them if they got a raise
        static void Main(string[] args)
        {
            // The user's name
            string sName;

            // The user's starting salary
            double dSalary = 30000;

            // Did the user receive a raise?
            bool receivedRaise = false;

            // Ask the user for ther name
            Console.WriteLine("Enter your name");
            sName = Console.ReadLine();

            // Will they receive a raise?
            receivedRaise = GiveRaise(sName, ref dSalary);

            // If the user received a raise, congratulate them and show their new salary
            if(receivedRaise)
            {
                Console.WriteLine($"\nCongratulations, {sName}, you got a raise!");
                Console.WriteLine($"Your new salary is ${dSalary}\n");
            }
            else
            {
                Console.WriteLine("\nThis is entirely unbiased and totally based on merit, therefore work harder to get a raise!\n");
            }
        }

        // Method: GiveRaise
        // Purpose: Give a raise to users named Nicholas
        // Return: Boolean for whether the user recieved a raise
        static bool GiveRaise(string name, ref double salary)
        {
            // If the user is named Nicholas, give them a raise and return true
            if(name.Equals("Nicholas"))
            {
                salary += 19999.99;
                return true;
            }

            // Else return false
            return false;
        }
    }
}
