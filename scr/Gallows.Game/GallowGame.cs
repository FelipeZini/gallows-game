using System.Linq;
using System.Collections.Generic;
namespace Gallows.Game
{
    public class GallowGame
    {
        public GallowGame(Word word)
        {
            this.Word = word;
            _attempts = new GameAttempts();
        }

        private GameAttempts _attempts;
        public Word Word { get; set; }

        public char[] MissedLetters { get; private set; }

        public void Try(char letter)
        {
            _attempts.Manage(letter, Word.IndexOfLetter(letter).ToList());
        }

        public override string ToString()
        {
            var word = Word.GhostWord();

            foreach (var correctLetter in _attempts.GetCorrectLetters())
                foreach (var value in correctLetter.Value)
                    word = word.Remove(value, 1).Insert(value, correctLetter.Key.ToString());

            return word;

        }

        public IEnumerable<char> GetMissedLetters()
        {
            var resultado = new List<char>();
            var wrongLetters = _attempts.GetWrongLetters().ToList();
            foreach (var wrongLetter in wrongLetters)
                resultado.Add(wrongLetter.Key);

            return resultado;
        }

        public int MissCount()
        {
            return this.GetMissedLetters().Count();
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
