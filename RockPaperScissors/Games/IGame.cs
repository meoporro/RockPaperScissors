using RockPaperScissors.Players;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissors.Games
{
    public interface IGame
    {
        void Play(IPlayer player1, IPlayer player2);
    }
}
