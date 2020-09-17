using System;

namespace Shaffer_UnitTest01_Q13
{
    // Employee struct for an employee's name and salary
    struct employee
    {
        public string sName;
        public double dSalary;
    }

    // Class: Program
    // Author: Nicholas Shaffer
    // Date: 9/16/2020
    // Purpose: Use a reference to raise a user's salary
    class Program
    {
        // An employee
        static employee e1;

        // Method: Main
        // Purpose: Ask the user for their name and congratulate them if they got a raise
        static void Main(string[] args)
        {
            // Set the employees starting salary
            e1.dSalary = 30000;

            // Did the employee receive a raise?
            bool receivedRaise = false;

            // Ask the employee for their name
            Console.WriteLine("Enter your name");
            e1.sName = Console.ReadLine();

            // Will they receive a raise?
            receivedRaise = GiveRaise(ref e1);

            // If the user received a raise, congratulate them and show their new salary
            if (receivedRaise)
            {
                Console.WriteLine($"\nCongratulations, {e1.sName}, you got a raise!");
                Console.WriteLine($"Your new salary is ${e1.dSalary}\n");
            }
            else
            {
                Console.WriteLine("\nThis is entirely unbiased and totally based on merit, therefore work harder to get a raise!\n");
            }
        }

        // Method: GiveRaise
        // Purpose: Give a raise to users named Nicholas
        // Return: Boolean for whether the user recieved a raise
        static bool GiveRaise(ref employee e1)
        {
            // If the user is named Nicholas, give them a raise and return true
            if (e1.sName.ToLower().Equals("nicholas"))
            {
                e1.dSalary += 19999.99;
                return true;
            }

            // Else return false
            return false;
        }
    }
}