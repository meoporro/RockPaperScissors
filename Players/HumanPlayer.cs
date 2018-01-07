using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            return Int32.Parse(Console.ReadLine());
        }
    }
}
