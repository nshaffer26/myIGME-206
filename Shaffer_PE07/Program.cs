using System;
using System.IO;

namespace Shaffer_PE07
{
    // Class: Program
    // Author: David Schuh, Nicholas Shaffer
    // Date: 9/5/2020
    // Purpose: A Mad Libs game using predetermined narratives stored in a text file
    class Program
    {
        // Method: Main
        // Purpose: Gather information from the user to generate a complete story for the selected MadLib
        static void Main(string[] args)
        {
            int numLibs = 0;
            int cntr = 0;
            int nChoice = 0;

            string username = null;

            string finalMadLib = null;

            StreamReader input;

            // open the template file to count how many Mad Libs it contains
            input = new StreamReader("C:\\Users\\nshaf\\OneDrive\\Documents\\_RIT\\_School\\Year 1\\Semester 1\\IGME 206\\_GitHub\\_nshaffer26\\myIGME-206\\Shaffer_PE07\\Resources\\MadLibsTemplate.txt");

            string line = null;

            // read 1 line at a time (a line ends with '\n')
            while ((line = input.ReadLine()) != null)
            {
                ++numLibs;
            }

            // close it
            input.Close();

            // only allocate as many strings as there are Mad Libs
            string[] madLibs = new string[numLibs];

            // read the Mad Libs into the array of strings
            input = new StreamReader("C:\\Users\\nshaf\\OneDrive\\Documents\\_RIT\\_School\\Year 1\\Semester 1\\IGME 206\\_GitHub\\_nshaffer26\\myIGME-206\\Shaffer_PE07\\Resources\\MadLibsTemplate.txt");

            line = null;
            while ((line = input.ReadLine()) != null)
            {
                // set this array element to the current line of the template file
                madLibs[cntr] = line;

                // replace the "\\n" tag with the newline escape character
                madLibs[cntr] = madLibs[cntr].Replace("\\n", "\n");

                ++cntr;
            }

            input.Close();

            // Ask the user for their name
            Console.WriteLine("Please enter your name");
            username = Console.ReadLine();
            
            // Label for if the user wants to play the game, either for the first time or again
            playGame:

            // Boolean to hold if the user wants to play
            bool wantToPlay = false;

            // Boolean to hold if the user entered a valid response ("yes" or "no")
            bool validResp = false;

            // Integer to hold how many times the user was asked for a valid response
            int asked = 0;

            do
            {
                Console.WriteLine($"\nWould you like to play MadLibs? Enter \"yes\" or \"no\"");
                string response = Console.ReadLine();

                if (response.ToLower().Equals("yes"))
                {
                    validResp = true;
                    wantToPlay = true;
                }
                else if (response.ToLower().Equals("no"))
                {
                    validResp = true;
                    wantToPlay = false;
                }
                else
                {
                    validResp = false;
                    asked++;
                    if(asked < 3)
                    {
                        Console.WriteLine("Invalid input: Please enter \"yes\" or \"no\"");
                    }
                    else
                    {
                        Console.WriteLine($"{username}, I know you know that's not a \"yes\" or a \"no\"");
                    }
                }
            }
            while (!validResp);

            if(!wantToPlay)
            {
                goto skipGame;
            }

            // Boolean values to hold whether user enters a valid integer within a valid range, i.e, [0,numLibs)
            bool validInt = false;
            bool validRange = false;

            // prompt the user for which Mad Lib they want to play (nChoice)
            do
            {
                try
                {
                    Console.WriteLine($"\nWhich MadLib would you like? Enter an integer between 0 and {numLibs - 1} (inclusive)");
                    nChoice = Convert.ToInt32(Console.ReadLine());
                    validInt = true;
                }
                catch
                {
                    Console.WriteLine("Invalid input: Please enter an integer");
                    validInt = false;
                }

                if (nChoice >= 0 && nChoice < numLibs)
                {
                    validRange = true;
                }
                else
                {
                    Console.WriteLine($"Invalid input: Your choice must be between 0 and {numLibs - 1} (inclusive)");
                    validRange = false;
                }
            }
            while (!validInt || !validRange);

            // split the Mad Lib into separate words
            string[] words = madLibs[nChoice].Split(' ');

            foreach (string thisWord in words)
            {
                // The Mad Lib placeholders which are to be replaced by user input 
                // are formatted as {Kitchen_appliance}, for example

                // if this word is a placeholder
                if (thisWord.StartsWith("{"))
                // this is the same as: if( thisWord[0] == '{' )
                {
                    // we want to create the prompt: "Kitchen appliance: ", for example

                    // copy the word to a char array
                    char[] cWord = thisWord.ToCharArray();

                    // character array to hold the prompt
                    char[] promptWord = new char[thisWord.Length];

                    // we need 2 counters to create the prompt
                    // the dest counter is the current character we are inserting into the promptWord array
                    int dest = 0;

                    // the src counter looks at each character in the source array
                    for (int src = 0; src < cWord.Length; ++src)
                    {
                        // skip open and close tags and spaces
                        if (cWord[src] == '{' || cWord[src] == '}' || cWord[src] == ' ')
                        {
                            continue;
                        }

                        // convert _ to space
                        if (cWord[src] == '_')
                        {
                            cWord[src] = ' ';
                        }

                        promptWord[dest++] = cWord[src];
                    }

                    promptWord[dest] = (char)0;

                    // to convert a char array back to a string,
                    // use the char[] constructor: new string(char[])
                    string sPrompt = new string(promptWord);

                    // prompt the user for the replacement
                    Console.Write($"\nPlease enter a/an ");
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.WriteLine(sPrompt);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Black;
                    string response = Console.ReadLine();

                    // and append the user response to the finalMadLib string
                    finalMadLib += " " + response;
                }
                else
                {
                    finalMadLib += " " + thisWord;
                }
            }
            Console.WriteLine($"\n\nYour Result:\n{finalMadLib}");

            // Start over by asking the user if they want to play the game (again)
            finalMadLib = "";
            goto playGame;

            // The user does not want to play the game
            skipGame:
            Console.WriteLine("\nBye!\n");
        }
    }
}
