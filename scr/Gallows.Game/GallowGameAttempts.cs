using System.Collections.Generic;
using System.Linq;

namespace Gallows.Game
{
    public class GallowGameAttempts
    {
        public IDictionary<char, int[]> Attempts;

        public GallowGameAttempts()
        {
            this.Attempts = new Dictionary<char, int[]>();
        }

        public void Manage(char letter, IEnumerable<int> index)
         {
            if (this.Attempts.ContainsKey(letter))
                throw new GameLetterException(Gallows.Game.Properties.Resources.Message_Exception);

            this.Attempts.Add(letter, index.ToArray());
        }

        public IEnumerable<KeyValuePair<char, int[]>> GetWrongLetters()
        {
            return this.Attempts.Where(c => c.Value[0] == -1);
        }


        public IEnumerable<KeyValuePair<char, int[]>> GetCorrectLetters()
        {
            return this.Attempts.Where(c => c.Value != new int[] { -1 });
        }

    }
}
