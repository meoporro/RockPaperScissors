using System;
using System.Collections.Generic;

namespace Players
{
    public class ComputerPlayer : Player
    {
        protected Random RandomGenerator;
        private static int ComputerPlayerCounter = 1;

        internal ComputerPlayer() : base("Bot" + ComputerPlayerCounter++)
        {
            RandomGenerator = new Random();
        }

        protected ComputerPlayer(string name) : base(name)
        {
            RandomGenerator = new Random();
        }

        internal ComputerPlayer(int value) : base("Bot" + ComputerPlayerCounter++)
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
