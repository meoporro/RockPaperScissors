using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Players
{
    public interface IPlayer
    {
        string Name { get; }

        int SelectMove(List<string> supportedMoves);

        void Reset();
    }
}
