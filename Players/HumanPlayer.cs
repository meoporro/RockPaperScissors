using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Players
{
    public class HumanPlayer : Player
    {
        public override int SelectMove(List<string> supportedMoves)
        {
            return Int32.Parse(Console.ReadLine());
        }
    }
}
