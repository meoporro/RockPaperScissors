using System.Collections.Generic;

namespace Players
{
    public interface IPlayer
    {
        string Name { get; }

        int SelectMove(List<string> supportedMoves, int turnNumber);
    }

    public interface IStrategicPlayer
    {
        void Reset();
    }
}
