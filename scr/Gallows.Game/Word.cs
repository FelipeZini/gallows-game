using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Gallows.Game
{
    public class Word
    {
        public Word(string value)
        {
            this.Value = value;
        }

        public string Value { get; set; }

        public override string ToString()
        {
            return this.Value;
        }

        public bool Contains(char letter)
        {
            return (this.Value.IndexOf(letter.ToString(), StringComparison.InvariantCultureIgnoreCase) >= 0);
        }

        public IEnumerable<int> IndexOfLetter(char letter)
        {

            var passou = false;

            for (int i = 0; i < Value.Length; i++)
                if (Value[i].Equals(letter))
                {
                    passou = true;
                    yield return i;
                    
                }

            if (!passou)
                yield return -1;
     
        }

        public string GhostWord()
        {
            return Regex.Replace(this.Value, @"\w", "?");
        }
    }
}
