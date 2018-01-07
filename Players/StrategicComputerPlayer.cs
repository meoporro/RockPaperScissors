using System;
using System.Collections.Generic;
using System.Linq;

namespace Players
{
    public class StrategicComputerPlayer : ComputerPlayer
    {
        private static int StrategicComputerPlayerCounter = 1;
        private int PreviousMove;

        internal StrategicComputerPlayer() : base("StrategicBot" + StrategicComputerPlayerCounter++.ToString())
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
            Console.WriteLine("\n" + Name + " selects " + supportedMoves[CurrentMove]);
            return CurrentMove;
        }

        public override void Reset()
        {
            PreviousMove = -1;
        }
    }
}
