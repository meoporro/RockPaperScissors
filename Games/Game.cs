﻿using Players;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Games
{
    public enum SupportedGames
    {
        Null = 0,
        RockPaperScissors,
        RockPaperScissorsLizardSpock
    }

    public abstract class Game : IGame
    {
        private int NumberOfTurns { get; set; }

        protected Game(int numberOfTurns)
        {
            NumberOfTurns = numberOfTurns;
        }

        public abstract List<string> SupportedMoves
        {
            get;
        }

        public int Play(IPlayer player1, IPlayer player2)
        {
            int Player1Wins = 0;
            int Player2Wins = 1;
            for (int Turn = 0; Turn < NumberOfTurns; Turn++)
            {
                Console.WriteLine("Turn " + Turn);
                int TurnResult = DetermineTurnResult(player1.SelectMove(SupportedMoves), player2.SelectMove(SupportedMoves));

                if (TurnResult == 0)
                {
                    Console.WriteLine("It's a draw!");
                    continue;
                }
                Console.WriteLine("\n" + (TurnResult == 1 ? player1.Name : player2.Name) + " wins the turn!");

                if (TurnResult == 1) Player1Wins++;
                else Player2Wins++;

                if (Math.Max(Player1Wins, Player1Wins) == NumberOfTurns / 2 + 1) break;
            }

            if (Player1Wins > Player2Wins) return 1;
            else if (Player1Wins < Player2Wins) return 2;
            else return 0;
        }

        public abstract int DetermineTurnResult(int player1Move, int player2Move);

        public static IGame CreateGame(SupportedGames selectedGame, int numberOfTurns)
        {
            switch (selectedGame)
            {
                case SupportedGames.RockPaperScissors:
                    return new RockPaperScissorsGame(numberOfTurns);

                case SupportedGames.RockPaperScissorsLizardSpock:
                    return new RockPaperScissorsLizardSpockGame(numberOfTurns);

                default:
                    throw new ArgumentException();
            }
        }
    }
}
