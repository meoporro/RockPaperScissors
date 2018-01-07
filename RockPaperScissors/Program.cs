using System;
using System.Collections.Generic;
using System.Linq;
using Games;
using Players;

namespace RockPaperScissors
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hi!");

            var SupportedPlayerList = Enum.GetValues(typeof(SupportedPlayers)).Cast<SupportedPlayers>().ToList();

            IPlayer Player1 = CreatePlayer(1, SupportedPlayerList);

            IPlayer Player2 = CreatePlayer(2, SupportedPlayerList);

            bool PlayAgain = true;
            while(PlayAgain)
            {
                Console.WriteLine("\n" + "Which game do you want to play?");
                var SupportedGamesList = Enum.GetValues(typeof(SupportedGames)).Cast<SupportedGames>().ToList();
                foreach (SupportedGames SupportedGame in SupportedGamesList)
                {
                    if (SupportedGame == SupportedGames.Null) continue;
                    Console.WriteLine((int)SupportedGame + " - " + SupportedGame.ToString());
                }
                int SelectedGameType = -1;
                while (!Int32.TryParse(Console.ReadLine(), out SelectedGameType) || SelectedGameType < 0 || SelectedGameType >= SupportedGamesList.Count)
                {
                    Console.WriteLine("Please, select an admissible value.");
                }

                int NumberOfTurns = 3;
                IGame GameToPlay = Game.CreateGame((SupportedGames)SelectedGameType, NumberOfTurns);

                Console.WriteLine("\n" + "Game " + Player1.Name + " vs " + Player2.Name + " started!");

                int GameResult = GameToPlay.Play(Player1, Player2);

                if (GameResult == 0)
                {
                    Console.WriteLine("The game ended with a draw!");
                }
                else
                {
                    Console.WriteLine("\n" + (GameResult == 1 ? Player1.Name : Player2.Name) + " wins the Game!");
                }

                Console.WriteLine("\n" + "Do you want to play another game? y/n");

                string PlayAgainInput = Console.ReadLine().ToLower();
                while (PlayAgainInput != "y" && PlayAgainInput != "n")
                {
                    Console.WriteLine("Please type \"y\" or \"n\".");
                    PlayAgainInput = Console.ReadLine().ToLower();
                }

                if (PlayAgainInput == "n") PlayAgain = false;
                Player1.Reset();
                Player2.Reset();
            }

            Console.WriteLine("\n" + "Bye!");
            Console.ReadLine();
        }

        private static IPlayer CreatePlayer(int playerNumber, List<SupportedPlayers> supportedPlayers)
        {
            Console.WriteLine("\n" + "Select Player" + playerNumber + " type:");
            foreach (SupportedPlayers SupportedPlayer in supportedPlayers)
            {
                if (SupportedPlayer == SupportedPlayers.Null) continue;
                Console.WriteLine((int)SupportedPlayer + " - " + SupportedPlayer.ToString());
            }

            int SelectedPlayerType = -1;
            while (!Int32.TryParse(Console.ReadLine(), out SelectedPlayerType) || SelectedPlayerType < 0 || SelectedPlayerType >= supportedPlayers.Count)
            {
                Console.WriteLine("Please, select an admissible value.");
            }

            string PlayerName = "";
            if (SelectedPlayerType == (int)SupportedPlayers.HumanPlayer)
            {
                Console.WriteLine("What is your name?");
                PlayerName = Console.ReadLine();
            }

            return Player.CreatePlayer((SupportedPlayers)SelectedPlayerType, PlayerName);
        }
    }
}
