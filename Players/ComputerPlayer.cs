using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Players
{
    public class ComputerPlayer : Player
    {
        protected Random RandomGenerator;
        private int ComputerPlayerCounter = 1;

        internal ComputerPlayer()
        {
            _Name = "Bot" + ComputerPlayerCounter++;
            RandomGenerator = new Random();
        }

        internal ComputerPlayer(int value)
        {
            RandomGenerator = new DefaultRandom(value);
        }

        public override int SelectMove(List<string> supportedMoves)
        {
            int SelectedMove = RandomGenerator.Next(supportedMoves.Count);
            Console.WriteLine("\n" + Name + " selects " + supportedMoves[SelectedMove]);
            return SelectedMove;
        }

        protected class DefaultRandom : Random
        {
            public DefaultRandom(int defaultValue)
            {
                DefaultValue = defaultValue;
            }

            private int DefaultValue;
            public override int Next(int foo)
            {
                return DefaultValue;
            }
        }
    }
}
