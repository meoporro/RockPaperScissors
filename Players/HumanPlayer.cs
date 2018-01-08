using System;
using System.Collections.Generic;
using System.Linq;

namespace Players
{
    public class HumanPlayer : Player
    {
        internal HumanPlayer(string name) : base(name)
        {
        }

        public override int SelectMove(List<string> supportedMoves, int turn)
        {
            Console.WriteLine("\n" + Name + ", select move:");
            for (int moveIndex = 0; moveIndex < supportedMoves.Count(); moveIndex++)
            {
                Console.WriteLine(moveIndex + " - " + supportedMoves[moveIndex]);
            }

            int selectedMove = -1;
            while (!Int32.TryParse(Console.ReadLine(), out selectedMove) || selectedMove < 0 || selectedMove >= supportedMoves.Count)
            {
                Console.WriteLine("Please, select an admissible value.");
            }

            return selectedMove;
        }
    }
}
