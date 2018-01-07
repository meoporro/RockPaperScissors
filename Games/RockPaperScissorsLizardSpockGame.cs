using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Games
{
    public class RockPaperScissorsLizardSpockGame : Game
    {
        private static List<string> _SupportedMoves = new List<string>()
        {
            "Paper", "Lizard", "Scissors", "Spock", "Rock"
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
            throw new NotImplementedException();
        }
    }
}
