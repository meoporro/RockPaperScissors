﻿using System;
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
        public static IPlayer CreatePlayer(SupportedPlayers selectedPlayerType)
        {
            switch (selectedPlayerType)
            {
                case SupportedPlayers.HumanPlayer:
                    return new HumanPlayer();

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
        
    }
}
