using System;
using System.Timers;

namespace Shaffer_UnitTest01_Q04
{
    // Class: Program
    // Author: Nicholas Shaffer
    // Date: 9/16/2020
    // Purpose: Ask the user 1 of 3 questions
    class Program
    {
        // The user ran out of time
        static bool outOfTime = false;

        // Create a timer
        static Timer timer;

        // Method: Main
        // Purpose: Ask the user their chosen question, and determine the correctness of their answer
        static void Main(string[] args)
        {
            // 2D array of questions and their answers
            string[,] questionAnswer = new string[3,2]
            {
                { "What is your favorite color?", "black" },
                { "What is the answer to life, the universe and everything?", "42" },
                { "What is the airspeed velocity of an unladen swallow?", "What do you mean? African or European swallow?" }
            };

        // If the user wants to play again
        start:

            // Initialize timer flag
            outOfTime = false;

            // Booleans for valid integer and valid range
            bool validInt = false;
            bool validRange = false;

            // Integer for user's choice
            int choice = -1;

            // String for user's answer
            string userAnswer = "";

            // Play again?
            string again = "";

            Console.WriteLine();

            // Ask the user which question they want
            do
            {
                Console.Write("Choose your question (1-3): ");

                try
                {
                    choice = Convert.ToInt32(Console.ReadLine());
                    validInt = true;
                }
                catch
                {
                    validInt = false;
                }

                // Did the user enter an integer within the range of possible values (1-3)
                if(choice < 1 || choice > 3)
                {
                    validRange = false;
                }
                else
                {
                    validRange = true;

                    // Array index starts at 0, so actual choice is choice-1
                    choice -= 1;
                }
            }
            while (!validInt || !validRange);

            // Ask the user the chosen question while they still have time
            while(!outOfTime)
            {
                Console.WriteLine("You have 5 seconds to answer the following question:");
                Console.WriteLine(questionAnswer[choice, 0]);

                // Create and start a timer
                timer = new Timer(5000);
                timer.Elapsed += delegate { TimesUp(questionAnswer[choice, 1]); };
                timer.Start();

                // Read the user's attempt
                userAnswer = Console.ReadLine();

                // Stop the timer
                timer.Stop();

                // Did they get it right?
                if(userAnswer.ToLower().Equals(questionAnswer[choice, 1]) && !outOfTime)
                {
                    // Got it right
                    Console.WriteLine("Well done!");

                    // Exit loop
                    outOfTime = true;
                }
                else
                {
                    if(!outOfTime)
                    {
                        // Got it wrong, tell them the answer
                        Console.WriteLine("Wrong! The answer is " + questionAnswer[choice, 1]);
                    }

                    // Exit loop
                    outOfTime = true;
                }
            }

            // Ask if the user wants to play again
            do
            {
                Console.Write("Play again? ");

                again = Console.ReadLine();

                if(again.ToLower().Equals("y") || again.ToLower().Equals("yes"))
                {
                    goto start;
                }
                else if(again.ToLower().Equals("n") || again.ToLower().Equals("no"))
                {
                    break;
                }
            }
            while (true);
        }

        // Method: TimesUp
        // Purpose: Elapsed Event for Timer object (user ran out of time)
        static void TimesUp(string answer)
        {
            Console.WriteLine("Time's up!");
            Console.WriteLine("The answer is: " + answer);
            Console.WriteLine("Please press enter.");

            outOfTime = true;
            timer.Stop();
        }
    }
}
