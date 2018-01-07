using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Players
{
    public class StrategicComputerPlayer : ComputerPlayer
    {
        private int PreviousMove;

        internal StrategicComputerPlayer() : base()
        {
            PreviousMove = -1;
        }

        internal StrategicComputerPlayer(int previousMove)
        {
            PreviousMove = previousMove;
        }

        public override int SelectMove(List<string> supportedMoves)
        {
            int NumberSupportedMoves = supportedMoves.Count();
            int CurrentMove = PreviousMove == -1 ? RandomGenerator.Next(NumberSupportedMoves) : (PreviousMove + 1) % NumberSupportedMoves;
            PreviousMove = CurrentMove;
            return CurrentMove;
        }
    }
}
