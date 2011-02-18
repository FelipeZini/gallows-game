using System.Collections.Generic;
using System.Linq;

namespace Gallows.Game
{
    public class GameAttempts
    {
        private GallowGame Game;
        private IDictionary<char, int[]> Attempts;

        public GameAttempts(GallowGame game)
        {
            this.Attempts = new Dictionary<char, int[]>();
            this.Game = game;
        }

        public void Manage(char letter, IEnumerable<int> index)
        {
            if (this.Attempts.ContainsKey(letter))
                throw new GameLetterException(Gallows.Game.Properties.Resources.Message_Exception);

            this.Attempts.Add(letter, index.ToArray());

            VerifyResult();
        }

        private void VerifyResult()
        {
            if (Game.GetResult() == GallowsGameState.Lose)
                throw new GameStateException("You lose!!!");

            if (Game.GetResult() == GallowsGameState.Win)
                throw new GameStateException("You won!!!");
        }

        public IEnumerable<KeyValuePair<char, int[]>> GetWrongLetters()
        {
            return this.Attempts.Where(c => c.Value[0] == -1);
        }


        public IEnumerable<KeyValuePair<char, int[]>> GetCorrectLetters()
        {
            return this.Attempts.Where(c => c.Value[0] != -1);
        }

    }
}
