using NUnit.Framework;
using System.Linq;
using System.Collections.Generic;

namespace Gallows.Game.Tests
{
    [TestFixture]
    public class WordTest
    {
        [Test]
        public void Can_I_Create_A_Word()
        {
            //Arrange / Act
            var word = new Word("mad");

            //Assert
            Assert.That(word.ToString(), Is.EqualTo("mad"));
        }

        [Test]
        public void Can_I_Verify_Letter_a_In_Word_When_Letter_Contains()
        {
            //Arrange
            var word = new Word("mad");

            //Act
            var result = word.Contains('a');
           
            //Assert
            Assert.That(result, Is.True);
        }


        [Test]
        public void Can_I_Verify_Letter_A_In_Word_When_Letter_Contains()
        {
            //Arrange
            var word = new Word("mad");

            //Act
            var result = word.Contains('A');

            //Assert
            Assert.That(result, Is.True);
        }

        [Test]
        public void Can_I_Get_IndexOf_Letter_That_Contains()
        {
            //Arrange
            var word = new Word("mad");

            //Act
            var result = word.IndexOfLetter('a');

            //Assert
            Assert.That(result, Is.EqualTo(new int[] { 1 }));
        }

        [Test]
        public void Can_I_Get_IndexOf_Letters_A()
        {
            //Arrange
            var word = new Word("arara");

            //Act
            var result = word.IndexOfLetter('a');

            //Assert
            Assert.That(result, Is.EqualTo(new int[] { 0, 2, 4 }));
        }

        [Test]
        public void Can_I_Verify_Letter_x_In_Word_When_Letter_Does_Not_Contains()
        {
            //Arrange
            var word = new Word("mad");

            //Act
            var result = word.Contains('x');

            //Assert
            Assert.That(result, Is.False);
        }

        [Test]
        public void Can_I_Get_A_Ghost_Word()
        {
            //Arrange
            var word = new Word("mad");

            //Act
            var result = word.GhostWord();

            //Assert
            Assert.That(result, Is.EqualTo("???"));
        }

        [Test]
        public void Can_I_Get_Another_Ghost_Word()
        {
            //Arrange
            var word = new Word("interface");

            //Act
            var result = word.GhostWord();

            //Assert
            Assert.That(result, Is.EqualTo("?????????"));
        }


    }
}
