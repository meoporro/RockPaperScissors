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

        public override int SelectMove(List<string> supportedMoves)
        {
            Console.WriteLine("\n" + Name + ", select move:");
            for (int MoveIndex = 0; MoveIndex < supportedMoves.Count(); MoveIndex++)
            {
                Console.WriteLine(MoveIndex + " - " + supportedMoves[MoveIndex]);
            }

            int SelectedMove = -1;
            while (!Int32.TryParse(Console.ReadLine(), out SelectedMove) || SelectedMove < 0 || SelectedMove >= supportedMoves.Count)
            {
                Console.WriteLine("Please, select an admissible value.");
            }

            return SelectedMove;
        }
    }
}
