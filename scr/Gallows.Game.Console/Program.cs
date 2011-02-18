using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gallows.Game
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Gallows Game");
            Console.Write("Insert word to create a new game: ");
            var word = Console.ReadLine();

            GallowGame game = new GallowGame(new Word(word));
            Console.Clear();

            while (game.GetResult() == GallowsGameState.Playing)
            {
                Console.Write("Guess: ");
                string letter = Console.ReadLine();
                if (string.IsNullOrEmpty(letter)) continue;

                Console.WriteLine("You guess letter: {0}", letter[0]);

                try
                {
                    game.Try(letter[0]);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                Console.Write("Letters which you've been missed: ");
                game.GetMissedLetters().Each(c => Console.Write("{0} ", c));

                Console.WriteLine("\n{0}", game.ToString());
            }

            Console.WriteLine("\n\nPress a key to exit...");
            Console.ReadLine();
        }
    }

    public static class EnumerableExtension
    {
        public static void Each<T>(this IEnumerable<T> collection, Action<T> action)
        {
            foreach (var item in collection)
                action.Invoke(item);
        }
    }

}
