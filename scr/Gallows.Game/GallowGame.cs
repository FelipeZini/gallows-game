using System.Linq;
using System.Collections;
using System.Collections.Generic;
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
            return this.Attempts.Where(c => c.Value == new int[] { -1 });
        }


        public IEnumerable<KeyValuePair<char, int[]>> GetCorrectLetters()
        {
            return this.Attempts.Where(c => c.Value != new int[] { -1 });
        }

    }

    public class GallowGame
    {
        public GallowGame(Word word)
        {
            this.Word = word;
            _gallowGameAttempts = new GallowGameAttempts();
        }

        private GallowGameAttempts _gallowGameAttempts;
        public Word Word { get; set; }
        public string Tip { get; set; }
        public int MissCount { get; private set; }

        public void Try(char letter)
        {
            _gallowGameAttempts.Manage(letter, Word.IndexOfLetter(letter));

            if (!Word.Contains(letter))
                MissCount++;
        }

        public override string ToString()
        {
            var word = Word.GhostWord();

            foreach (var correctLetter in _gallowGameAttempts.GetCorrectLetters())
                foreach (var value in correctLetter.Value)
                    word = word.Remove(value, 1).Insert(value, correctLetter.Key.ToString());

            return word;

        }
    }
}
