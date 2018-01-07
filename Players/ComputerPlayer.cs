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

        internal ComputerPlayer()
        {
            RandomGenerator = new Random();
        }

        internal ComputerPlayer(int value)
        {
            RandomGenerator = new DefaultRandom(value);
        }

        public override int SelectMove(List<string> supportedMoves)
        {
            return RandomGenerator.Next(supportedMoves.Count);
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
