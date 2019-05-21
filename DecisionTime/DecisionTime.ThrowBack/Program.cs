using DecisionTime.Core;
using DecisionTime.ThrowBack.Helpers;
using System;
using static System.Console;

namespace DecisionTime.ThrowBack
{
    class Program
    {
        private static string entry = string.Empty;
        private static Game game = null;
        private static Round round = null;

        static void Main(string[] args)
        {
            while (entry != "x")
            {
                DisplayHeader();
                SetupGameRound();
                BeginRoundWithConsent();

                // turn loop
                while (entry != "x")
                {
                    Clear();
                    DisplayHeader();
                    DisplayDistrictStats();

                    // present decision

                    WriteLine("Press any key to end turn, or \'x\' to exit game");
                    entry = ReadLine();
                    round.EndTurn();
                    
                }

            }

            Clear();
            DisplayHeader();
            PrintOutput($"A fond farewell, {round.PlayerName} the Coward!");
            ReadLine();
        }

        private static void SetupGameRound()
        {
            SolicitInput("What is your name, Councilor?", "Type your name");
            var name = entry;

            SolicitInput("Do You Want an Easy or Normal Game?", "Enter 1 for Easy, 2 for Normal");
            var difficulty = InputParsers.IntToLevelName(entry);

            round = new Round(name, difficulty);
        }

        private static void BeginRoundWithConsent()
        {
            var response = DialogueHelper.WelcomeDialogueHelper(round.PlayerName, round.Game.Difficulty);

            PrintOutput(response);

            SolicitInput("Are you ready to begin?", "Press any key to start, \'x\' to exit");
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

        private static void DisplayDistrictStats()
        {
            Clear();
            DisplayHeader();
            WriteLine($"Turn #{round.Turn}:");
            WriteLine($"Your district has {round.Game.Districts[0].Citizens.Count} Citizens.");
            WriteLine($"Their overall attitude toward you is {round.Game.Districts[0].CurrentAttitude}.");
            WriteLine();
            WriteLine();
        }

        private static void DisplayHeader()
        {
            WriteLine("****************************************");
            WriteLine("*      The apocalpyse happened!!!      *");
            WriteLine("*      You Are a District Rep!!!!      *");
            WriteLine("*   You Got Some Decisions To Make!!   *");
            WriteLine("*                                      *");
            WriteLine("*   Press 'x' at any prompt to exit!   *");
            WriteLine("****************************************");
            WriteLine();
            WriteLine();
            WriteLine();
        }
    }
}
