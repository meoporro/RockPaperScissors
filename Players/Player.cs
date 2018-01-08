using System;
using System.Collections.Generic;

namespace Players
{
    public enum SupportedPlayer
    {
        Null,
        HumanPlayer,
        ComputerPlayer,
        StrategicComputerPlayer
    }

    public abstract class Player : IPlayer
    {
        public string Name { get; }
        
        protected Player(string name)
        {
            Name = name;
        }

        public static IPlayer CreatePlayer(SupportedPlayer selectedPlayerType, string name)
        {
            switch (selectedPlayerType)
            {
                case SupportedPlayer.Null:
                    throw new ArgumentNullException();

                case SupportedPlayer.HumanPlayer:
                    return new HumanPlayer(name);

                case SupportedPlayer.ComputerPlayer:
                    return new ComputerPlayer();

                case SupportedPlayer.StrategicComputerPlayer:
                    return new StrategicComputerPlayer();

                default:
                    throw new ArgumentException();
            }
        }

        public static IPlayer CreatePlayer(SupportedPlayer selectedPlayerType, int value)
        {
            switch (selectedPlayerType)
            {
                case SupportedPlayer.ComputerPlayer:
                    return new ComputerPlayer(value);

                case SupportedPlayer.StrategicComputerPlayer:
                    return new StrategicComputerPlayer(value);

                case SupportedPlayer.HumanPlayer:
                default:
                    throw new ArgumentException();
            }
        }

        public abstract int SelectMove(List<string> supportedMoves, int turn);
    }
}
