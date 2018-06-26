using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ChessTest
{
    [TestClass]
    public class CanMoveTestFromAndToCondition
    {
        [TestMethod]
        public void InvalidFromSquareTest()
        {
            // -- Arrange
            var expected = new Chess.Chess();
            // -- Act
            var actual = new Chess.Chess().Move("Pa9a4");
            // -- Assert
            Assert.AreEqual(actual.Fen, expected.Fen);
        }

        [TestMethod]
        public void InvalidToSquareTest()
        {
            // -- Arrange
            var expected = new Chess.Chess();
            // -- Act
            var actual = new Chess.Chess().Move("Pa2a9");
            // -- Assert
            Assert.AreEqual(actual.Fen, expected.Fen);
        }
    }
}
