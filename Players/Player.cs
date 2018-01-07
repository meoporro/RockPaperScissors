using System;
using System.Collections.Generic;
using System.Text;

namespace Players
{
    public enum SupportedPlayers
    {
        Null = 0,
        HumanPlayer,
        ComputerPlayer,
        StrategicComputerPlayer
    }

    public abstract class Player : IPlayer
    {
        private string _Name;
        public string Name { get { return _Name; } }
        
        protected Player(string name)
        {
            _Name = name;
        }

        public static IPlayer CreatePlayer(SupportedPlayers selectedPlayerType, string name)
        {
            switch (selectedPlayerType)
            {
                case SupportedPlayers.HumanPlayer:
                    return new HumanPlayer(name);

                case SupportedPlayers.ComputerPlayer:
                    return new ComputerPlayer();

                case SupportedPlayers.StrategicComputerPlayer:
                    return new StrategicComputerPlayer();

                default:
                    throw new ArgumentException();
            }
        }

        public static IPlayer CreatePlayer(SupportedPlayers selectedPlayerType, int value)
        {
            switch (selectedPlayerType)
            {
                case SupportedPlayers.ComputerPlayer:
                    return new ComputerPlayer(value);

                case SupportedPlayers.StrategicComputerPlayer:
                    return new StrategicComputerPlayer(value);

                case SupportedPlayers.HumanPlayer:
                default:
                    throw new ArgumentException();
            }
        }


        public abstract int SelectMove(List<string> supportedMoves);
        
        public virtual void Reset()
        {
        }
    }
}
