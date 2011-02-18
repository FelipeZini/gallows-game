using System.Linq;
using NUnit.Framework;

namespace Gallows.Game.Tests
{
    [TestFixture]
    public class GallowGameTest
    {
        [Test]
        public void When_I_Try_Some_Letter_That_Contains_MissCount_Is_The_Same()
        {
            //Arrange
            var game = new GallowGame(new Word("interface"));

            //Act
            game.Try('a');

            //Assert
            Assert.That(game.MissCount(), Is.EqualTo(0));
        }

        [Test]
        public void When_I_Try_Some_Letter_That_Does_Not_Contains_MissCount_Increase_One()
        {
            //Arrange
            var game = new GallowGame(new Word("interface"));

            //Act
            game.Try('x');

            //Assert
            Assert.That(game.MissCount(), Is.EqualTo(1));
        }

        [Test]
        public void When_Try_Letter_Already_Tried_Throws_Exception()
        {
            //Arrange
            var game = new GallowGame(new Word("interface"));

            //Act
            game.Try('x');

            //Assert
            Assert.That(() =>
            {
                game.Try('x');
                return true;
            },
                                    Throws
                                      .Exception
                                      .TypeOf<GameLetterException>()
                                      .With.Message.EquivalentTo("Letter Already tried."));
        }

        [Test]
        public void When_Letter_Contains_Game_Returns_Word_Filled()
        {
            //Arrange
            var game = new GallowGame(new Word("interface"));

            //Act
            game.Try('a');

            //Assert
            Assert.That(game.ToString(), Is.EqualTo("??????a??"));
        }

        [Test]
        public void When_Word_Contains_Same_Letter_Two_Times_Return_Word_Filled()
        {
            //Arrange
            var game = new GallowGame(new Word("arara"));

            //Act
            game.Try('a');

            //Assert
            Assert.That(game.ToString(), Is.EqualTo("a?a?a"));

        }

        [Test]
        public void Game_Returns_Letter_Which_I_Missed()
        {
            //Arrange
            var game = new GallowGame(new Word("interface"));
            game.Try('m');
            game.Try('z');

            //Act
            var result = game.GetMissedLetters().ToList();

            //Assert
            Assert.That(result.ToArray(), Is.EqualTo(new char[] { 'm', 'z' }));
        }

        [Test]
        public void When_All_Letters_Are_Correct_I_Won()
        {
            //Arrange
            var game = new GallowGame(new Word("teste"));
            game.Try('t');
            game.Try('e');
            game.Try('s');

            //Act
            var result = game.GetResult();

            //Assert
            Assert.That(result, Is.EqualTo(GallowsGameState.Win));
        }

        [Test]
        public void While_Some_Letters_Were_Not_Discovered_I_Did_Not_Win()
        {
            //Arrange
            var game = new GallowGame(new Word("teste"));
            game.Try('t');
            game.Try('e');

            //Act
            var result = game.GetResult();

            //Assert
            Assert.That(result, Is.EqualTo(GallowsGameState.Playing));
        }

        [Test]
        public void If_I_Miss_Seven_Times_I_Lose()
        {
            //Arrange
            var game = new GallowGame(new Word("teste"));
            game.Try('h');
            game.Try('p');
            game.Try('x');
            game.Try('a');
            game.Try('b');
            game.Try('i');
            game.Try('o');

            //Act
            var result = game.GetResult();

            //Assert
            Assert.That(result, Is.EqualTo(GallowsGameState.Lose));
        }

        [Test]
        public void I_Cannot_Play_If_I_Won()
        {
            //Arrange
            var game = new GallowGame(new Word("teste"));
            game.Try('t');
            game.Try('e');
            game.Try('s');
   
            //Assert
            Assert.That(() =>
            {
                game.Try('x'); //Act
                return true;
            },
                                    Throws
                                      .Exception
                                      .TypeOf<GameStateException>()
                                      .With.Message.EquivalentTo("You have already won."));
        }

        [Test]
        public void I_Cannot_Play_If_I_Lose()
        {
            //Arrange
            var game = new GallowGame(new Word("teste"));
            game.Try('i');
            game.Try('u');
            game.Try('w');
            game.Try('q');
            game.Try('o');
            game.Try('p');
            game.Try('n');

            //Assert
            Assert.That(() =>
            {
                game.Try('x'); //Act
                return true;
            },
                                    Throws
                                      .Exception
                                      .TypeOf<GameStateException>()
                                      .With.Message.EquivalentTo("You have already lose."));
        }


    }
}
