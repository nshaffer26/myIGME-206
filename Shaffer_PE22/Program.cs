using System;
using System.Collections.Generic;

using Newtonsoft.Json;
using System.IO;
using System.Net;
using System.Web;
using System.Timers;

// Author: Nicholas Shaffer
// Date: 10/31/2020
namespace Shaffer_PE22
{
    class TriviaResult
    {
        public string category;
        public string type;
        public string difficulty;
        public string question;
        public string correct_answer;
        public List<string> incorrect_answers;
        public List<string> choices;
        public List<string> randChoices;
    }
    class Trivia
    {
        public int response_code;
        public List<TriviaResult> results;
    }

    //{"response_code":0,
    //   "results":[{"category":"General Knowledge","type":"multiple","difficulty":"easy",
    //            "question":"Which best selling toy of 1983 caused hysteria, resulting in riots breaking out in stores?",
    //    "correct_answer":"Cabbage Patch Kids","incorrect_answers":["Transformers","Care Bears","Rubik&rsquo;s Cube"]
    //}]}

    static class Program
    {
        enum dir
        {
            north,
            south,
            east,
            west,
            none
        }
        enum room
        {
            A, B, C, D, E, F, G, H
        }

        static dir[,] mDirGraph = new dir[,]
        {
            //A            B            C            D            E            F            G            H
            { dir.north  , dir.south  , dir.none   , dir.none   , dir.none   , dir.none   , dir.none   , dir.none  },  //A
            { dir.none   , dir.none   , dir.south  , dir.east   , dir.none   , dir.none   , dir.none   , dir.none  },  //B
            { dir.none   , dir.north  , dir.none   , dir.none   , dir.none   , dir.none   , dir.none   , dir.south },  //C
            { dir.none   , dir.west   , dir.south  , dir.none   , dir.north  , dir.east   , dir.none   , dir.none  },  //D
            { dir.none   , dir.none   , dir.none   , dir.none   , dir.none   , dir.south  , dir.none   , dir.none  },  //E
            { dir.none   , dir.none   , dir.none   , dir.none   , dir.none   , dir.none   , dir.east   , dir.none  },  //F
            { dir.none   , dir.none   , dir.none   , dir.none   , dir.north  , dir.none   , dir.none   , dir.south },  //G
            { dir.none   , dir.none   , dir.none   , dir.none   , dir.none   , dir.none   , dir.none   , dir.none  }   //H
        };
        static int[,] mCostGraph = new int[,]
        {
            //A      B    C    D    E    F    G    H
            { 0,     2,   -1,  -1,  -1,  -1,  -1,  -1 }, //A
            { -1,    -1,  2,   3,   -1,  -1,  -1,  -1 }, //B
            { -1,    2,   -1,  -1,  -1,  -1,  -1,  20 }, //C
            { -1,    3,   5,   -1,  2,   4,   -1,  -1 }, //D
            { -1,    -1,  -1,  -1,  -1,  3,   -1,  -1 }, //E
            { -1,    -1,  -1,  -1,  -1,  -1,  1,   -1 }, //F
            { -1,    -1,  -1,  -1,  0,   -1,  -1,  2  }, //G
            { -1,    -1,  -1,  -1,  -1,  -1,  -1,  -1 }  //H
        };

        static dir[][] lDirGraph = new dir[][]
        {
            new dir[] { dir.north, dir.south, dir.east },           //A
            new dir[] { dir.south, dir.east },                      //B
            new dir[] { dir.north, dir.south },                     //C
            new dir[] { dir.north, dir.south, dir.east, dir.west }, //D
            new dir[] { dir.south },                                //E
            new dir[] { dir.east },                                 //F
            new dir[] { dir.north, dir.south },                     //G
            null                                                    //H
        };
        static room[][] lRoomGraph = new room[][]
        {
            new room[] { room.A, room.B, room.A },         //A
            new room[] { room.C, room.D },                 //B
            new room[] { room.B, room.H },                 //C
            new room[] { room.E, room.C, room.F, room.B }, //D
            new room[] { room.F },                         //E
            new room[] { room.G },                         //F
            new room[] { room.E, room.H },                 //G
            null                                           //H
        };
        static int[][] lCostGraph = new int[][]
        {
            new int[] { 0, 2, 0 },      //A
            new int[] { 2, 3 },         //B
            new int[] { 2, 20 },        //C
            new int[] { 2, 5, 4, 3 },   //D
            new int[] { 3 },            //E
            new int[] { 1 },            //F
            new int[] { 0, 2 },         //G
            null                        //H
        };

        // Boolean for if the user ran out of time answering a question
        static bool outOfTime = false;

        // timeOutTimer Timer
        static Timer timer;

        static void Main(string[] args)
        {
            // Current player health
            int HP = 1;

            //Current plaer room
            room curRoom = room.A;

            // Reasons for losing health
            // Player has at least 2 HP
            List<KeyValuePair<string, int>> Lose1HPFlavorText = new List<KeyValuePair<string, int>>();
            Lose1HPFlavorText.Add(new KeyValuePair<string,int>("You stub your toe.", 1));
            Lose1HPFlavorText.Add(new KeyValuePair<string,int>("A mouse suddenly scurries in front of you, catching you by surprise and making you jump.", 1));
            Lose1HPFlavorText.Add(new KeyValuePair<string,int>("You realize you're very tired when a quick brown fox jumps over a lazy dog. Now your head hurts.", 1));
            // Player has at least 3 HP
            List<KeyValuePair<string, int>> Lose2HPFlavorText = new List<KeyValuePair<string, int>>();
            Lose2HPFlavorText.Add(new KeyValuePair<string, int>("You tripped over a rock, how clumsy!", 2));
            Lose2HPFlavorText.Add(new KeyValuePair<string, int>("You hurt yourself in your confusion!", 2));
            Lose2HPFlavorText.Add(new KeyValuePair<string, int>("You take damage from somewhere because you just do.", 2));
            // Player has at least 3 HP
            List<KeyValuePair<string, int>> Lose3HPFlavorText = new List<KeyValuePair<string, int>>();
            Lose3HPFlavorText.Add(new KeyValuePair<string, int>("You were attacked by a bat!", 3));
            Lose3HPFlavorText.Add(new KeyValuePair<string, int>("You're too hungry to be stuck in this maze. You see a biscuit and chomp down, discovering it was actually a rock.", 3));
            Lose3HPFlavorText.Add(new KeyValuePair<string, int>("You have died of dysentery. Not really though, because this isn't The Oregon Trail.", 3));
            // Player has 4 or more health
            List<KeyValuePair<string, int>> Lose4HPFlavorText = new List<KeyValuePair<string, int>>();
            Lose4HPFlavorText.Add(new KeyValuePair<string, int>("You've been in this maze too long and feel yourself going mad.", 4));

            // Room descriptions
            Dictionary<room, string> roomDescriptions = new Dictionary<room, string>();
            roomDescriptions[room.A] = "You are in an abandoned dungeon with stone bricks lining the walls. There are skeletons chained to the walls behind closed cells.";
            roomDescriptions[room.B] = "You are in a bland room with white walls and a white floor. The ceiling is bright green.";
            roomDescriptions[room.C] = "You are in a cave with stalactites looming above you precariously.";
            roomDescriptions[room.D] = "You are in a dark grove filled with trees and a small well in a clearing in the center.";
            roomDescriptions[room.E] = "You are in an empty padded room. The floor and walls are soft and pillow-like.";
            roomDescriptions[room.F] = "You are in a flower garden filled with daisies and marigolds. There is a single, potted poppie in the center of the room.";
            roomDescriptions[room.G] = "You are in a grand parlor with walls lined with bookshelves. There is a fireplace on one wall, and a bust of a man in the corner next to an armchair.";
            roomDescriptions[room.H] = "You are in a horrifying room filled with clown masks and porcelain dolls. There is a jack-in-the box placed neatly in the center of the room on a pedestal. It pops open and you startle awake. That was a weird dream, but you think you might have won!";

            while (HP > 0)
            {
                Console.WriteLine(roomDescriptions[curRoom]);

                // If the player is at the end, break from the while loop
                if(curRoom.Equals(room.H))
                {
                    break;
                }

                Console.WriteLine("There are exits to the:");
                List<KeyValuePair<dir, int>> possibleExits = new List<KeyValuePair<dir, int>>();
                for (int i = 0; i < mCostGraph.GetLength(1); i++)
                {
                    if(mCostGraph[(int)curRoom,i] != -1 && HP > mCostGraph[(int)curRoom, i])
                    {
                        // If the cost isn't -1 and the player has more HP than the cost to use the exit, the player can see that exit
                        // Add the direction and cost to the list of possible exits
                        possibleExits.Add(new KeyValuePair<dir,int>(mDirGraph[(int)curRoom, i], mCostGraph[(int)curRoom, i]));
                        Console.WriteLine(mDirGraph[(int)curRoom, i].ToString().ToUpper());
                    }
                }
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"You have {HP} HP.");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine();

                Console.WriteLine("Would you like to:");
                Console.WriteLine("\t1. Wager some HP on a trivia question");
                if(possibleExits.Count > 0)
                {
                    // A player can only see this choice only if they have enough HP to see at least one exit
                    Console.WriteLine("\t2. Choose an exit");
                }

                invalidChoice:

                Console.Write("Your choice: ");
                string choice = Console.ReadLine();
                if(choice == "1")
                {
                    Console.WriteLine("You chose to answer a trivia question.");
                    Console.WriteLine();

                    invalidWager:

                    // Get the player's wager
                    int wageredHP = 1;
                    Console.Write($"How much HP would you like to wager? ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"You have {HP} HP.");
                    Console.ForegroundColor = ConsoleColor.White;
                    try
                    {
                        wageredHP = int.Parse(Console.ReadLine());

                        if(wageredHP > HP)
                        {
                            // The wagered amount of HP is greater than the player's current HP
                            Console.WriteLine("Invalid wager. You cannot wager more HP than you have.");
                            goto invalidWager;
                        }
                    }
                    catch
                    {
                        Console.WriteLine("Invalid wager. You must enter an integer.");
                        goto invalidWager;
                    }
                    Console.WriteLine($"You are wagering {wageredHP} HP.");
                    Console.WriteLine();

                    // Ask them the question
                    Trivia trivia = getQuestion();
                    Console.WriteLine("You have 15 seconds to answer the following:");
                    Console.WriteLine(trivia.results[0].question);
                    for(int i = 0; i < trivia.results[0].randChoices.Count; i++)
                    {
                        // Start choices at 1 instead of 0
                        Console.WriteLine($"\t{i + 1}. {trivia.results[0].randChoices[i]}");
                    }

                    while (!outOfTime)
                    {
                        // Create a timer for 15 seconds and add an elapsed event to it
                        timer = new Timer(15000);
                        timer.Elapsed += new ElapsedEventHandler(TimesUp);
                        timer.Start();

                        invalidAnswer:

                        // Get the player's answer
                        int answer = -1;
                        Console.Write("Your answer: ");
                        try
                        {
                            answer = int.Parse(Console.ReadLine());

                            if (!outOfTime && answer < 0 || answer > trivia.results[0].randChoices.Count)
                            {
                                // The chosen answer is outside of the choices given
                                Console.WriteLine("Invalid answer.");
                                goto invalidAnswer;
                            }
                        }
                        catch
                        {
                            if (!outOfTime)
                            {
                                Console.WriteLine("Invalid answer. You must enter an integer.");
                                goto invalidAnswer;
                            }
                        }
                        Console.WriteLine();

                        timer.Stop();

                        // Did they get it right? Answer - 1 because choices start at 1
                        if ((answer - 1) == trivia.results[0].randChoices.IndexOf(trivia.results[0].correct_answer) && !outOfTime)
                        {
                            // Correct answer within 15 seconds
                            HP += wageredHP;
                            Console.WriteLine($"You got it right! ");
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.WriteLine($"You gained {wageredHP} HP.");
                            Console.ForegroundColor = ConsoleColor.White;

                            // Exit the timer loop
                            outOfTime = true;
                        }
                        else if ((answer - 1) != trivia.results[0].randChoices.IndexOf(trivia.results[0].correct_answer) && !outOfTime)
                        {
                            // Incorrect answer within 15 seconds
                            HP -= wageredHP;
                            Console.Write($"Sorry, that's incorrect! ");
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine($"You lost {wageredHP} HP.");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine($"The correct answer was {trivia.results[0].correct_answer}.");

                            // Exit the timer loop
                            outOfTime = true;
                        }
                        else
                        {
                            // Out of time
                            HP -= wageredHP;
                            Console.Write($"Sorry, you ran out of time! ");
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine($"You lost {wageredHP} HP.");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine($"The correct answer was {trivia.results[0].correct_answer}.");

                            // Exit the timer loop
                            outOfTime = true;
                        }
                    }

                    // Reset timer
                    outOfTime = false;
                }
                else if(choice == "2" && possibleExits.Count > 0)
                {
                    Console.WriteLine("You chose to leave via an exit.");
                    Console.WriteLine();

                    // Print the available answers
                    Console.WriteLine("The available exits are as follows:");
                    for(int i = 0; i < possibleExits.Count; i++)
                    {
                        // Start choices at 1 instead of 0
                        Console.WriteLine($"\t{i + 1}. {possibleExits[i].Key.ToString().ToUpper()} - The cost of this path is {possibleExits[i].Value} HP");
                    }
                    
                    invalidExit:
                    
                    Console.Write("Your choice: ");

                    // Get the player's chosen exit
                    int exit = -1;
                    try
                    {
                        exit = int.Parse(Console.ReadLine());

                        if (exit < 1 || exit > possibleExits.Count)
                        {
                            // The user's choice is outside of the choices given (1 to possibleExits + 1)
                            Console.WriteLine("Invalid choice.");
                            goto invalidExit;
                        }
                    }
                    catch
                    {
                        Console.WriteLine("Invalid choice. You must enter an integer.");
                        goto invalidExit;
                    }

                    dir chosenExit = possibleExits[exit - 1].Key;
                    int chosenCost = possibleExits[exit - 1].Value;
                    for (int i = 0; i < mDirGraph.GetLength(1); i++)
                    {
                        // Find the chosen exit in the list of exits from the current room
                        if(chosenExit == mDirGraph[(int)curRoom, i])
                        {
                            // Set this room to the new current room
                            curRoom = (room)i;

                            // Subtract the cost of the exit from the player's HP
                            HP -= chosenCost;
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine($"You lost {chosenCost} HP.");
                            Console.ForegroundColor = ConsoleColor.White;
                            break;
                        }
                    }

                    // Player is randomly attacked upon entering a new room
                    List<KeyValuePair<string, int>> possibleAttacks = new List<KeyValuePair<string, int>>();
                    if(HP > 1)
                    {
                        // Player can lose at least 1 HP
                        possibleAttacks.AddRange(Lose1HPFlavorText);
                    }
                    if (HP > 2)
                    {
                        // Player can lose at least 2 HP
                        possibleAttacks.AddRange(Lose2HPFlavorText);
                    }
                    if (HP > 3)
                    {
                        // Player can lose at least 3 HP
                        possibleAttacks.AddRange(Lose3HPFlavorText);
                    }
                    if (HP > 4)
                    {
                        // Player can lose at least 4 HP
                        possibleAttacks.AddRange(Lose4HPFlavorText);
                    }

                    // Chose and tell the user of the random attack if their HP is greater than 1, and they arent' entering room A or H
                    if (HP > 1 && !curRoom.Equals(room.A) && !curRoom.Equals(room.H))
                    {
                        Random rand = new Random();
                        KeyValuePair<string, int> randomAttack = possibleAttacks[rand.Next(0, possibleAttacks.Count)];

                        Console.WriteLine();
                        Console.WriteLine(randomAttack.Key);

                        // Subtract the random amount of HP
                        HP -= randomAttack.Value;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"You lost {randomAttack.Value} HP.");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                }
                else
                {
                    // The user didn't enter a 1 or 2, or they entered 2 without having had that choice
                    Console.WriteLine("Invalid choice.");
                    goto invalidChoice;
                }

                Console.WriteLine();
                Console.WriteLine("--------------------------      --------------------------      --------------------------");
                Console.WriteLine();
            }

            if(HP == 0)
            {
                Console.WriteLine("Game over! You ran out of health!");
            }
            Console.WriteLine("Thanks for playing!");
            Console.WriteLine();
        }

        static Trivia getQuestion()
        {
            // Access API
            string url = null;
            string s = null;

            HttpWebRequest request;
            HttpWebResponse response;
            StreamReader reader;

            url = "https://opentdb.com/api.php?amount=1";

            request = (HttpWebRequest)WebRequest.Create(url);
            response = (HttpWebResponse)request.GetResponse();
            reader = new StreamReader(response.GetResponseStream());
            s = reader.ReadToEnd();
            reader.Close();

            // Generate trivia question
            Trivia trivia = JsonConvert.DeserializeObject<Trivia>(s);

            trivia.results[0].question = HttpUtility.HtmlDecode(trivia.results[0].question);
            trivia.results[0].correct_answer = HttpUtility.HtmlDecode(trivia.results[0].correct_answer);

            // Gather all possible answer choices
            trivia.results[0].choices = new List<string>();
            trivia.results[0].choices.Add(trivia.results[0].correct_answer);
            for (int i = 0; i < trivia.results[0].incorrect_answers.Count; ++i)
            {
                trivia.results[0].incorrect_answers[i] = HttpUtility.HtmlDecode(trivia.results[0].incorrect_answers[i]);
                trivia.results[0].choices.Add(trivia.results[0].incorrect_answers[i]);
            }

            // Randomize choices
            trivia.results[0].randChoices = new List<string>();
            List<string> temp = new List<string>(trivia.results[0].choices);
            while (temp.Count > 0)
            {
                Random rand = new Random();
                int i = rand.Next(0, temp.Count);
                trivia.results[0].randChoices.Add(temp[i]);
                temp.RemoveAt(i);
            }

            return trivia;
        }

        static void TimesUp(object source, ElapsedEventArgs e)
        {
            Console.WriteLine();
            Console.WriteLine("Your time is up! Press Enter to continue.");

            // set the bTimeOut flag to quit the game
            outOfTime = true;

            // stop the timeOutTimer
            timer.Stop();
        }
    }
}
