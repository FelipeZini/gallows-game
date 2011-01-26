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
            Assert.That(game.MissCount, Is.EqualTo(0));
        }

        [Test]
        public void When_I_Try_Some_Letter_That_Does_Not_Contains_MissCount_Increase_One()
        {
            //Arrange
            var game = new GallowGame(new Word("interface"));

            //Act
            game.Try('x');

            //Assert
            Assert.That(game.MissCount, Is.EqualTo(1));
        }


        [Test]
        public void When_Try_Letter_Already_Tried_Throws_Exception()
        {
            //Arrange
            var game = new GallowGame(new Word("interface"));

            //Act
            game.Try('x');

            //Assert
            Assert.That(() => { game.Try('x');
                                return true; }, 
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

    }
}
