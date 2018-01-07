using System;
using System.Collections.Generic;

namespace Games
{
    public class RockPaperScissorsLizardSpockGame : Game
    {
        public static readonly List<string> _SupportedMoves = new List<string>
        {
            "Paper", "Lizard", "Scissors", "Rock", "Spock"
        };

        public override List<string> SupportedMoves
        {
            get
            {
                return _SupportedMoves;
            }
        }

        internal RockPaperScissorsLizardSpockGame(int numberOfTurns) : base(numberOfTurns)
        {
        }

        public override int DetermineTurnResult(int player1Move, int player2Move)
        {
            int circularIndexDistance = player1Move - player2Move + (player1Move >= player2Move ? 0 : _SupportedMoves.Count);
            switch (circularIndexDistance)
            {
                case 0:
                    return 0;
                case 1:
                case 2:
                    return 1;
                case 3:
                case 4:
                    return 2;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
