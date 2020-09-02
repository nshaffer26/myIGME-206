using System;
using System.CodeDom;

namespace Shaffer_PE06
{
    // Class: Program
    // Author: Nicholas Shaffer
    // Date: 9/1/2020
    // Purpose: A simple number guessing game
    class Program
    {
        // Method: Main
        // Purpose: Generate a random integer between 0 and 100 (inclusive) that a player will try to guess
        static void Main(string[] args)
        {
            Random rand = new Random();
            // Generate a random number between 0 inclusive and 101 exclusive
            int randomNumber = rand.Next(0, 101);

            // Integer to hold the total number of attempts a user gets, as well as how many they have left
            int totalAttempts = 8;
            int attempts = 8;

            // Integer to hold best score (lowest number of attempts in a session)
            int best = totalAttempts + 1;

            // Boolean to hold if the user wants to keep playing
            bool playAgain = true;

            // Integer to hold games played and games won respectively
            int gamesPlayed = 0;
            int gamesWon = 0;

            // Boolean to hold whether the user inputs a valid integer
            bool validInt = false;

            // Boolean to hold whether the user guesses within the range [0,100]
            bool validRange = false;

            // Tell the user their goal
            Console.WriteLine("I'm thinking of a number between 0 and 100 (inclusive). What is it?");
            Console.WriteLine($"You have {attempts} attempts to guess.");

            // Loop while the user still has attempts
            while (attempts > 0)
            {
                do
                {
                    try
                    {
                        // Integer to hold the user's guess
                        int guess = Convert.ToInt32(Console.ReadLine());

                        // Valid integers were given
                        validInt = true;

                        if (guess < 0 || guess > 100)
                        {
                            // The user entered an integer outside of the specified range
                            validRange = false;
                            Console.WriteLine("Invalid input! Please enter an integer between 0 and 100 (inclusive)!");
                        }
                        else
                        {
                            // The user entered a valid integer
                            validRange = true;
                            attempts--;

                            // The user has 0 attempts left, end the game
                            if (attempts == 0 && guess != randomNumber)
                            {
                                Console.WriteLine($"Sorry, you did not guess my number. It was {randomNumber}");
                                gamesPlayed++;
                                break;
                            }

                            // Now check for correctness and give feedback
                            if (guess < randomNumber)
                            {
                                Console.WriteLine($"Too low! Guess again, you have {attempts} attempt(s) left");
                            }
                            else if (guess > randomNumber)
                            {
                                Console.WriteLine($"Too high! Guess again, you have {attempts} attempt(s) left");
                            }
                            else
                            {
                                Console.WriteLine($"\nCongratulations, {guess} is correct! You guessed the right number in {totalAttempts-attempts} attempt(s)");
                                if (totalAttempts-attempts < best)
                                {
                                    best = totalAttempts - attempts;
                                }
                                Console.WriteLine($"Your best score is {best} attempt(s) this session");
                                attempts = 0;
                                gamesPlayed++;
                                gamesWon++;
                                break;
                            }
                        }
                    }
                    catch
                    {
                        Console.WriteLine("Invalid input! Please enter an integer!");
                        validInt = false;
                    }
                }
                while (!validInt || !validRange);

                if(attempts == 0)
                {
                    // Boolean that holds whether user entered valid input, i.e., "y" or "n"
                    bool validAns = false;

                    // Ask the user if they want to play again
                    do
                    {
                        Console.WriteLine("\nWould you like to play again? Enter \"y\" for yes or \"n\" for no");
                        string temp = Console.ReadLine();

                        if (temp.ToLower().Equals("y"))
                        {
                            validAns = true;

                            // -- Reset game -- //
                            // Reset attempts
                            attempts = totalAttempts;

                            // Find a new random number
                            rand = new Random();
                            // Generate a random number between 0 inclusive and 101 exclusive
                            randomNumber = rand.Next(0, 101);

                            // Tell the user their goal again
                            Console.WriteLine("\nI'm thinking of a number between 0 and 100 (inclusive). What is it?");
                            Console.WriteLine($"You have {attempts} attempts to guess.");
                        }
                        else if (temp.ToLower().Equals("n"))
                        {
                            validAns = true;

                            // Tell the user their score
                            Console.WriteLine($"\nI hope you had fun!\nYou won {gamesWon} out of {gamesPlayed} games");
                            if (best != totalAttempts + 1)
                            {
                                Console.WriteLine($"Your best score was {best} attempt(s)");
                            }
                            Console.WriteLine();
                        }
                        else
                        {
                            Console.WriteLine("Please enter \"y\" or \"n\"");
                            validAns = false;
                        }
                    }
                    while (!validAns);
                }
            }
        }
    }
}
