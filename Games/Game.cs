using RockPaperScissors.Players;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissors.Games
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

        public void Play(IPlayer player1, IPlayer player2)
        {
            throw new NotImplementedException();
        }

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
