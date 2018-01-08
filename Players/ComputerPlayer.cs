using System;
using System.Collections.Generic;

namespace Players
{
    public class ComputerPlayer : Player
    {
        protected Random RandomGenerator { get; }

        private static int _computerPlayerCounter = 1;

        internal ComputerPlayer() : base("Bot" + _computerPlayerCounter++)
        {
            RandomGenerator = new Random();
        }

        protected ComputerPlayer(string name) : base(name)
        {
            RandomGenerator = new Random();
        }

        internal ComputerPlayer(int value) : base("Bot" + _computerPlayerCounter++)
        {
            RandomGenerator = new DefaultRandom(value);
        }

        public override int SelectMove(List<string> supportedMoves, int turn)
        {
            int selectedMove = RandomGenerator.Next(supportedMoves.Count);
            Console.WriteLine("\n" + Name + " selects " + supportedMoves[selectedMove]);
            return selectedMove;
        }

        private class DefaultRandom : Random
        {
            private int _defaultValue;

            public DefaultRandom(int defaultValue)
            {
                _defaultValue = defaultValue;
            }

            public override int Next(int foo)
            {
                return _defaultValue;
            }
        }
    }
}
