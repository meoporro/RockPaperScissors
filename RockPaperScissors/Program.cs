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
            Console.WriteLine("Hi!\n");

            var SupportedPlayerList = Enum.GetValues(typeof(SupportedPlayers));

            Console.WriteLine("Select Player1 type:");
            foreach (SupportedPlayers SupportedPlayer in SupportedPlayerList)
            {
                if (SupportedPlayer == SupportedPlayers.Null) continue;
                Console.WriteLine((int)SupportedPlayer + " - " + SupportedPlayer.ToString());
            }
            int SelectedPlayer1Type = Int32.Parse(Console.ReadLine());

            Console.WriteLine();

            IPlayer Player1 = Player.CreatePlayer((SupportedPlayers)SelectedPlayer1Type);

            Console.WriteLine("\n" + "Select Player2 type:");
            foreach (SupportedPlayers SupportedPlayer in SupportedPlayerList)
            {
                if (SupportedPlayer == SupportedPlayers.Null) continue;
                Console.WriteLine((int)SupportedPlayer + " - " + SupportedPlayer.ToString());
            }
            int SelectedPlayer2Type = Int32.Parse(Console.ReadLine());

            Console.WriteLine();

            IPlayer Player2 = Player.CreatePlayer((SupportedPlayers)SelectedPlayer2Type);

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
    }
}
