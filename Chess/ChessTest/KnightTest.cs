using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ChessTest
{
    [TestClass]
    public class KnightTest
    {
        [TestMethod]
        public void MoveValidX1Y2()
        {
            // -- Arrange
            var expected = new Chess.Chess("rnbqkbnr/pppppppp/11111111/11111111/11111111/N1111111/PPPPPPPP/R1BQKBNR b - - 0 1");
            // -- Act
            var actual = new Chess.Chess().Move("Nb1a3");
            // -- Assert
            Assert.AreEqual(actual.Fen, expected.Fen);
        }

        [TestMethod]
        public void MoveValidX2Y1()
        {
            // -- Arrange
            var expected = new Chess.Chess("rnbqkbnr/pppppppp/11111111/11111111/11N11111/11111111/PPPPPPPP/R1BQKBNR b - - 0 1");
            // -- Act
            var actual = new Chess.Chess("rnbqkbnr/pppppppp/11111111/11111111/11111111/N1111111/PPPPPPPP/R1BQKBNR w - - 0 1").Move("Na3c4");
            // -- Assert
            Assert.AreEqual(actual.Fen, expected.Fen);
        }

        [TestMethod]
        public void MoveInvalid()
        {
            // -- Arrange
            var expected = new Chess.Chess();
            // -- Act
            var actual = new Chess.Chess().Move("Nb1c2");
            // -- Assert
            Assert.AreEqual(actual.Fen, expected.Fen);
        }
    }
}
