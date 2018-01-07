using Players;
using System.Collections.Generic;

namespace Games
{
    public interface IGame
    {
        List<string> SupportedMoves { get; }

        int Play(IPlayer player1, IPlayer player2);

        int DetermineTurnResult(int player1Move, int player2Move);
    }

}
