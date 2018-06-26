using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ChessTest
{
    [TestClass]
    public class QueenTest
    {
        [TestMethod]
        public void MoveUpValid()
        {
            // -- Arrange
            var expected = new Chess.Chess("rnbqkbnr/pppppppp/11111111/11111111/111Q1111/11111111/11111111/11111111 b - - 0 1");
            // -- Act
            var actual = new Chess.Chess("rnbqkbnr/pppppppp/11111111/11111111/11111111/11111111/11111111/111Q1111 w - - 0 1").Move("Qd1d4");
            // -- Assert
            Assert.AreEqual(actual.Fen, expected.Fen);
        }

        [TestMethod]
        public void MoveDownValid()
        {
            // -- Arrange
            var expected = new Chess.Chess("rnbqkbnr/pppppppp/11111111/11111111/11111111/11111111/11111111/111Q1111 b - - 0 1");
            // -- Act
            var actual = new Chess.Chess("rnbqkbnr/pppppppp/11111111/11111111/111Q1111/11111111/11111111/11111111 w - - 0 1").Move("Qd4d1");
            // -- Assert
            Assert.AreEqual(actual.Fen, expected.Fen);
        }

        [TestMethod]
        public void MoveRightValid()
        {
            // -- Arrange
            var expected = new Chess.Chess("rnbqkbnr/pppppppp/11111111/11111111/11111111/11111111/11111111/1111111Q b - - 0 1");
            // -- Act
            var actual = new Chess.Chess("rnbqkbnr/pppppppp/11111111/11111111/11111111/11111111/11111111/111Q1111 w - - 0 1").Move("Qd1h1");
            // -- Assert
            Assert.AreEqual(actual.Fen, expected.Fen);
        }

        [TestMethod]
        public void MoveLeftValid()
        {
            // -- Arrange
            var expected = new Chess.Chess("rnbqkbnr/pppppppp/11111111/11111111/11111111/11111111/11111111/Q1111111 b - - 0 1");
            // -- Act
            var actual = new Chess.Chess("rnbqkbnr/pppppppp/11111111/11111111/11111111/11111111/11111111/111Q1111 w - - 0 1").Move("Qd1a1");
            // -- Assert
            Assert.AreEqual(actual.Fen, expected.Fen);
        }
    }
}
