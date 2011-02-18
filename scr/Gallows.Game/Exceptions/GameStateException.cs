using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gallows.Game
{
    public class GameStateException : ApplicationException
    {
        public GameStateException(string message)
            : base(message)
        {

        }
    }
}
