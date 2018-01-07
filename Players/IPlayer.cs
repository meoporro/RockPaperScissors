using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Players
{
    public interface IPlayer
    {
        int SelectMove(List<string> supportedMoves);
    }
}
