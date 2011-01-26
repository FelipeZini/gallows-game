using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gallows.Game
{
    public class GameLetterException : ApplicationException
    {
        public GameLetterException(string message)
            : base(message)
        {

        }
    }
}
