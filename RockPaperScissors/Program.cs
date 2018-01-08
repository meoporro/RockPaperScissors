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

            var supportedPlayerList = Enum.GetValues(typeof(SupportedPlayer)).Cast<SupportedPlayer>().ToList();

            IPlayer player1 = CreatePlayer(1, supportedPlayerList);

            IPlayer player2 = CreatePlayer(2, supportedPlayerList);

            bool playAgain = true;
            while(playAgain)
            {
                Console.WriteLine("\n" + "Which game do you want to play?");
                var supportedGamesList = Enum.GetValues(typeof(SupportedGame)).Cast<SupportedGame>().ToList();
                foreach (SupportedGame supportedGame in supportedGamesList)
                {
                    if (supportedGame == SupportedGame.Null) continue;
                    Console.WriteLine((int)supportedGame + " - " + supportedGame.ToString());
                }
                int selectedGameType = -1;
                while (!Int32.TryParse(Console.ReadLine(), out selectedGameType) || selectedGameType < 0 || selectedGameType >= supportedGamesList.Count)
                {
                    Console.WriteLine("Please, select an admissible value.");
                }

                // Add code to allow the user to decide how many turns to play.
                int numberOfTurns = 3;
                IGame gameToPlay = Game.CreateGame((SupportedGame)selectedGameType, numberOfTurns);

                Console.WriteLine("\n" + "Game " + player1.Name + " vs " + player2.Name + " started!");

                int gameResult = gameToPlay.Play(player1, player2);

                if (gameResult == 0)
                {
                    Console.WriteLine("\n" + "The game ended with a draw!");
                }
                else
                {
                    Console.WriteLine("\n" + (gameResult == 1 ? player1.Name : player2.Name) + " wins the Game!");
                }

                Console.WriteLine("\n" + "Do you want to play another game? y/n");

                string playAgainInput = Console.ReadLine().ToLower();
                while (playAgainInput != "y" && playAgainInput != "n")
                {
                    Console.WriteLine("Please type \"y\" or \"n\".");
                    playAgainInput = Console.ReadLine().ToLower();
                }

                if (playAgainInput == "n") playAgain = false;
            }

            Console.WriteLine("\n" + "Bye!");
            Console.ReadLine();
        }

        private static IPlayer CreatePlayer(int playerNumber, List<SupportedPlayer> supportedPlayers)
        {
            Console.WriteLine("\n" + "Select Player" + playerNumber + " type:");
            foreach (SupportedPlayer supportedPlayer in supportedPlayers)
            {
                if (supportedPlayer == SupportedPlayer.Null) continue;
                Console.WriteLine((int)supportedPlayer + " - " + supportedPlayer.ToString());
            }

            int selectedPlayerType = -1;
            while (!Int32.TryParse(Console.ReadLine(), out selectedPlayerType) || selectedPlayerType < 0 || selectedPlayerType >= supportedPlayers.Count)
            {
                Console.WriteLine("Please, select an admissible value.");
            }

            string playerName = "";
            if (selectedPlayerType == (int)SupportedPlayer.HumanPlayer)
            {
                Console.WriteLine("What is your name?");
                playerName = Console.ReadLine();
            }

            return Player.CreatePlayer((SupportedPlayer)selectedPlayerType, playerName);
        }
    }
}
