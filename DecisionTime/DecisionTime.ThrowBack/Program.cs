using DecisionTime.Core;
using System;
using static System.Console;

namespace DecisionTime.ThrowBack
{
    class Program
    {
        private static string entry = string.Empty;
        private static Game game = null;

        static void Main(string[] args)
        {
           
            while (entry != "x")
            {
                Clear();
                DisplayHeader();
                SolicitInput("Do You Want an Easy or Normal Game?", "Enter 1 for Easy, 2 for Normal");

                if (entry == "1")
                {
                    PrintOutput("You Picked Easy!! We shall be gentle.");
                    game = SetupGame(GameLevel.Easy);

                    DisplayDistrictStats(game);

                    SolicitInput("Would You Like To Meet Your Constituents?", "Type y or n");

                    if (entry == "x")
                    {
                        PrintOutput("Running away, are you??");
                        break;
                    }

                    MeetingThePeople();
                }
                else if (entry == "2")
                {
                    WriteLine("You Picked Normal!! You must be fun at parties.");
                    game = SetupGame(GameLevel.Normal);

                    DisplayDistrictStats(game);

                    SolicitInput("Would You Like To Meet Your Constituents?", "Type Y or N");

                    if (entry == "x")
                    {
                        PrintOutput("Running away, are you??");
                        break;
                    }

                    MeetingThePeople();
                }
                else if (entry == "x")
                {
                    WriteLine("You've chosen to exit. Goodbye, Scardy-Cat!");
                    break;
                }
                else
                {
                    WriteLine("That was not a valid choice--shall we try again?");
                }

                ReadLine();
            }

            
            ReadLine();
        }

        private static void MeetingThePeople()
        {
            
            if (entry == "y" || entry == "Y")
            {
                Clear();
                DisplayHeader();
                PrintOutput("Aw yis, pressing the flesh, meeting and greeting, fishing for votes!");

                var citizens = game.Districts[0].Citizens;

                foreach (var citizen in citizens)
                {
                    Write("Someone approaches: ");
                    PrintOutput($"\"Hello Councilor, my name is {citizen.Name} and I generally feel {citizen.CurrentAttitude} of your work.\"");
                }
            }
            else if (entry == "n" || entry == "N")
            {
                PrintOutput("...you are aware how the political process works, right?");
            }
            else
            {
                PrintOutput("We need to do some error handling...");
            }

            WriteLine("That's about all we have for now...press any key to start over!");
        }

        private static void PrintOutput(params string[] outputLines)
        {
            foreach (var line in outputLines)
            {
                WriteLine(line);
            }

            WriteLine();
        }

        private static void SolicitInput(string messagePrompt, string optionsMessage)
        {
            WriteLine(messagePrompt);
            Write($"{optionsMessage}: ");
            entry = ReadLine();
            WriteLine();
        }

        private static Game SetupGame(GameLevel difficulty)
        {
            Game game = new Game(difficulty);
            return game;
        }

        private static void DisplayDistrictStats(Game game)
        {
            Clear();
            DisplayHeader();
            WriteLine($"Your district has {game.Districts[0].Citizens.Count} Citizens, and their overall attitude toward you is {game.Districts[0].CurrentAttitude}.");
            WriteLine();
            WriteLine();
        }

        private static void DisplayHeader()
        {
            Console.WriteLine("****************************************");
            Console.WriteLine("*      The apocalpyse happened!!!      *");
            Console.WriteLine("*      You Are a District Rep!!!!      *");
            Console.WriteLine("*   You Got Some Decisions To Make!!   *");
            Console.WriteLine("*                                      *");
            Console.WriteLine("*   Press 'x' at any prompt to exit!   *");
            Console.WriteLine("****************************************");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
        }
    }
}
