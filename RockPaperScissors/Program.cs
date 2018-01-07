using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

            Console.WriteLine("\n" + "Which game do you want to play?");
            foreach (SupportedGames SupportedGame in Enum.GetValues(typeof(SupportedGames)))
            {
                if (SupportedGame == SupportedGames.Null) continue;
                Console.WriteLine((int)SupportedGame + " - " + SupportedGame.ToString());
            }
            int SelectedGameType = Int32.Parse(Console.ReadLine());

            IGame GameToPlay = Game.CreateGame((SupportedGames)SelectedGameType, 3);

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
            int SelectedPlayerType = Int32.Parse(Console.ReadLine());

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
