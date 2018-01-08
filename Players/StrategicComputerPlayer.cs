using System;
using System.Collections.Generic;
using System.Linq;

namespace Players
{
    public class StrategicComputerPlayer : ComputerPlayer, IStrategicPlayer
    {
        private static int _strategicComputerPlayerCounter = 1;
        private int _previousMove;

        internal StrategicComputerPlayer() : base("StrategicBot" + _strategicComputerPlayerCounter++.ToString())
        {
            _previousMove = -1;
        }

        internal StrategicComputerPlayer(int previousMove)
        {
            _previousMove = previousMove;
        }

        public override int SelectMove(List<string> supportedMoves, int turn)
        {
            if (turn == 0) Reset();

            int numberSupportedMoves = supportedMoves.Count();
            int currentMove = _previousMove == -1 ? RandomGenerator.Next(numberSupportedMoves) : (_previousMove + 1) % numberSupportedMoves;
            _previousMove = currentMove;
            Console.WriteLine("\n" + Name + " selects " + supportedMoves[currentMove]);
            return currentMove;
        }

        public void Reset()
        {
            _previousMove = -1;
        }
    }
}
