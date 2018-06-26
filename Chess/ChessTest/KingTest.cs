using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ChessTest
{
    [TestClass]
    public class KingTest
    {
        [TestMethod]
        public void MoveisMoveOnlyOneSquareLeftOrRightInvalid()
        {
            // -- Arrange
            var expected = new Chess.Chess("rnbqkbnr/pppppppp/11111111/11111111/11111111/11111111/PPP111PP/1111K111 w - - 0 1");
            // -- Act
            var actual = new Chess.Chess("rnbqkbnr/pppppppp/11111111/11111111/11111111/11111111/PPP111PP/1111K111 w - - 0 1").Move("Ke1c1");
            // -- Assert
            Assert.AreEqual(actual.Fen, expected.Fen);
        }

        [TestMethod]
        public void MoveisMoveOnlyOneSquareUpInvalid()
        {
            // -- Arrange
            var expected = new Chess.Chess("rnbqkbnr/pppppppp/11111111/11111111/11111111/11111111/PPP111PP/1111K111 w - - 0 1");
            // -- Act
            var actual = new Chess.Chess("rnbqkbnr/pppppppp/11111111/11111111/11111111/11111111/PPP111PP/1111K111 w - - 0 1").Move("Ke1e3");
            // -- Assert
            Assert.AreEqual(actual.Fen, expected.Fen);
        }

        [TestMethod]
        public void MoveLeftValid()
        {
            // -- Arrange
            var expected = new Chess.Chess("rnbqkbnr/pppppppp/11111111/11111111/11111111/11111111/PPP111PP/111K1111 b - - 0 1");
            // -- Act
            var actual = new Chess.Chess("rnbqkbnr/pppppppp/11111111/11111111/11111111/11111111/PPP111PP/1111K111 w - - 0 1").Move("Ke1d1");
            // -- Assert
            Assert.AreEqual(actual.Fen, expected.Fen);
        }

        [TestMethod]
        public void MoveRightValid()
        {
            // -- Arrange
            var expected = new Chess.Chess("rnbqkbnr/pppppppp/11111111/11111111/11111111/11111111/PPP111PP/11111K11 b - - 0 1");
            // -- Act
            var actual = new Chess.Chess("rnbqkbnr/pppppppp/11111111/11111111/11111111/11111111/PPP111PP/1111K111 w - - 0 1").Move("Ke1f1");
            // -- Assert
            Assert.AreEqual(actual.Fen, expected.Fen);
        }

        [TestMethod]
        public void MoveUpValid()
        {
            // -- Arrange
            var expected = new Chess.Chess("rnbqkbnr/pppppppp/11111111/11111111/11111111/11111111/PPP1K1PP/11111111 b - - 0 1");
            // -- Act
            var actual = new Chess.Chess("rnbqkbnr/pppppppp/11111111/11111111/11111111/11111111/PPP111PP/1111K111 w - - 0 1").Move("Ke1e2");
            // -- Assert
            Assert.AreEqual(actual.Fen, expected.Fen);
        }

        [TestMethod]
        public void MoveDownValid()
        {
            // -- Arrange
            var expected = new Chess.Chess("rnbqkbnr/pppppppp/11111111/11111111/11111111/11111111/PPP111PP/1111K111 b - - 0 1");
            // -- Act
            var actual = new Chess.Chess("rnbqkbnr/pppppppp/11111111/11111111/11111111/11111111/PPP1K1PP/11111111 w - - 0 1").Move("Ke2e1");
            // -- Assert
            Assert.AreEqual(actual.Fen, expected.Fen);
        }
    }
}
