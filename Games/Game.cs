using Players;
using System;
using System.Collections.Generic;

namespace Games
{
    public enum SupportedGame
    {
        Null,
        RockPaperScissors,
        RockPaperScissorsLizardSpock
    }

    public abstract class Game : IGame
    {
        private readonly int _numberOfTurns;

        protected Game(int numberOfTurns)
        {
            _numberOfTurns = numberOfTurns;
        }

        public abstract List<string> SupportedMoves
        {
            get;
        }

        public int Play(IPlayer player1, IPlayer player2)
        {
            int player1Wins = 0;
            int player2Wins = 0;
            for (int turn = 0; turn < _numberOfTurns; turn++)
            {
                Console.WriteLine("\n" + "Turn " + (turn + 1));
                int turnResult = DetermineTurnResult(player1.SelectMove(SupportedMoves, turn), player2.SelectMove(SupportedMoves, turn));

                if (turnResult == 0)
                {
                    Console.WriteLine("\n" + "It's a draw!");
                }
                else
                {
                    Console.WriteLine("\n" + (turnResult == 1 ? player1.Name : player2.Name) + " wins the turn!");

                    if (turnResult == 1) player1Wins++;
                    else player2Wins++;
                }
                Console.WriteLine("\n" + "Current result: " +
                    ((player1Wins == player2Wins) ?
                        player1Wins + " even." :
                        player1.Name + " " + player1Wins + ", " + player2.Name + " " + player2Wins + "."));

                if (Math.Max(player1Wins, player2Wins) == _numberOfTurns / 2 + 1) break;
            }

            if (player1Wins > player2Wins) return 1;
            else if (player1Wins < player2Wins) return 2;
            else return 0;
        }

        public abstract int DetermineTurnResult(int player1Move, int player2Move);

        public static IGame CreateGame(SupportedGame selectedGame, int numberOfTurns)
        {
            switch (selectedGame)
            {
                case SupportedGame.Null:
                    throw new ArgumentNullException();

                case SupportedGame.RockPaperScissors:
                    return new RockPaperScissorsGame(numberOfTurns);

                case SupportedGame.RockPaperScissorsLizardSpock:
                    return new RockPaperScissorsLizardSpockGame(numberOfTurns);

                default:
                    throw new ArgumentException();
            }
        }
    }
}
