using System.Collections.Generic;

namespace Players
{
    public interface IPlayer
    {
        string Name { get; }

        int SelectMove(List<string> supportedMoves);

        void Reset();
    }
}
