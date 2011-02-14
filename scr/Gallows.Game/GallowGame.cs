using System.Linq;
using System.Collections.Generic;
namespace Gallows.Game
{
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

        public char[] MissedLetters { get; private set; }

        public void Try(char letter)
        {
            _gallowGameAttempts.Manage(letter, Word.IndexOfLetter(letter).ToList());

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

        public IEnumerable<char> GetMissedLetters()
        {
            var resultado = new List<char>();
            var wrongLetters = _gallowGameAttempts.GetWrongLetters().ToList();
            foreach (var wrongLetter in wrongLetters)
                resultado.Add(wrongLetter.Key);

            return resultado;
        }

        public GallowsGameState GetResult()
        {
            return 
                Word.Value == this.ToString() ? 
                    GallowsGameState.Win : 
                        this.GetMissedLetters().Count() == 7 ? 
                            GallowsGameState.Lose : GallowsGameState.Playing;
        }
    }

    public enum GallowsGameState
    {
        Win, Lose, Playing
    }
}
