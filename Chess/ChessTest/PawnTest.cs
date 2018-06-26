using System;
using System.Diagnostics;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ChessTest
{
    [TestClass]
    public class PawnTest
    {
        #region FromCondition

        [TestMethod]
        public void InvalidFromConditionLess()
        {
            // -- Arrange
            var expected = new Chess.Chess();
            // -- Act
            var actual = new Chess.Chess().Move("Pa1a3");
            // -- Assert
            Assert.AreEqual(actual.Fen, expected.Fen);
        }

        [TestMethod]
        public void InvalidFromConditionMore()
        {
            // -- Arrange
            var expected = new Chess.Chess("Pnbqkbnr/pppppppp/11111111/11111111/11111111/11111111/1PPPPPPP/RNBQKBNR b - - 0 1");
            // -- Act
            var actual = new Chess.Chess("Pnbqkbnr/pppppppp/11111111/11111111/11111111/11111111/1PPPPPPP/RNBQKBNR b - - 0 1").Move("Pa8a9");
            // -- Assert
            Assert.AreEqual(actual.Fen, expected.Fen);
        }

        #endregion

        #region Go And Jump Conditions

        [TestMethod]
        public void GoAndJumpIsEmptyOnDestinationSquareInvalid()
        {
            // -- Arrange
            var expected = new Chess.Chess("rnbqkbnr/1ppppppp/11111111/11111111/11111111/p1111111/PPPPPPPP/RNBQKBNR w - - 0 1");
            // -- Act
            var actual = new Chess.Chess("rnbqkbnr/1ppppppp/11111111/11111111/11111111/p1111111/PPPPPPPP/RNBQKBNR w - - 0 1").Move("Pa2a3");
            // -- Assert
            Assert.AreEqual(actual.Fen, expected.Fen);
        }

        [TestMethod]
        public void GoAndJumpisStraightMoveInvalid()
        {
            // -- Arrange
            var expected = new Chess.Chess();
            // -- Act
            var actual = new Chess.Chess().Move("Pa2b3");
            // -- Assert
            Assert.AreEqual(actual.Fen, expected.Fen);
        }

        #endregion

        #region Jump Conditions

        [TestMethod]
        public void JumpisPawnOnRightSquareWhiteInvalid()
        {
            // -- Arrange
            var expected = new Chess.Chess("rnbqkbnr/pppppppp/11111111/11111111/11111111/P1111111/1PPPPPPP/RNBQKBNR w - - 0 1");
            // -- Act
            var actual = new Chess.Chess("rnbqkbnr/pppppppp/11111111/11111111/11111111/P1111111/1PPPPPPP/RNBQKBNR w - - 0 1").Move("Pa3a5");
            // -- Assert
            Assert.AreEqual(actual.Fen, expected.Fen);
        }

        [TestMethod]
        public void JumpisPawnOnRightSquareBlackInvalid()
        {
            // -- Arrange
            var expected = new Chess.Chess("rnbqkbnr/1ppppppp/p1111111/11111111/11111111/11111111/PPPPPPPP/RNBQKBNR b - - 0 1");
            // -- Act
            var actual = new Chess.Chess("rnbqkbnr/1ppppppp/p1111111/11111111/11111111/11111111/PPPPPPPP/RNBQKBNR b - - 0 1").Move("pa7a5");
            // -- Assert
            Assert.AreEqual(actual.Fen, expected.Fen);
        }

        [TestMethod]
        public void JumpisEmptyOnTheNextSquareInvalid()
        {
            // -- Arrange
            var expected = new Chess.Chess("rnbqkbnr/1ppppppp/11111111/11111111/11111111/p1111111/PPPPPPPP/RNBQKBNR w - - 0 1");
            // -- Act
            var actual = new Chess.Chess("rnbqkbnr/1ppppppp/11111111/11111111/11111111/p1111111/PPPPPPPP/RNBQKBNR w - - 0 1").Move("Pa2a4");
            // -- Assert
            Assert.AreEqual(actual.Fen, expected.Fen);
        }

        #endregion

        #region Eat Conditions

        [TestMethod]
        public void EatIsEmptyOnDestinationSquareInvalid()
        {
            // -- Arrange
            var expected = new Chess.Chess();
            // -- Act
            var actual = new Chess.Chess().Move("Pa2b3");
            // -- Assert
            Assert.AreEqual(actual.Fen, expected.Fen);
        }

        [TestMethod]
        public void EatisMoveOnlyOneSquareLeftInvalid()
        {
            // -- Arrange
            var expected = new Chess.Chess();
            // -- Act
            var actual = new Chess.Chess().Move("Pc2a4");
            // -- Assert
            Assert.AreEqual(actual.Fen, expected.Fen);
        }

        [TestMethod]
        public void EatisMoveOnlyOneSquareRightInvalid()
        {
            // -- Arrange
            var expected = new Chess.Chess();
            // -- Act
            var actual = new Chess.Chess().Move("Pa2c4");
            // -- Assert
            Assert.AreEqual(actual.Fen, expected.Fen);
        }

        #endregion

        #region ValidMoves

        [TestMethod]
        public void GoPawnValid()
        {
            // -- Arrange
            var expected = new Chess.Chess("rnbqkbnr/pppppppp/11111111/11111111/11111111/P1111111/1PPPPPPP/RNBQKBNR b - - 0 1");
            // -- Act
            var actual = new Chess.Chess().Move("Pa2a3");
            // -- Assert
            Assert.AreEqual(actual.Fen, expected.Fen);
        }

        [TestMethod]
        public void JumpPawnValid()
        {
            // -- Arrange
            var expected = new Chess.Chess("rnbqkbnr/pppppppp/11111111/11111111/P1111111/11111111/1PPPPPPP/RNBQKBNR b - - 0 1");
            // -- Act
            var actual = new Chess.Chess().Move("Pa2a4");
            // -- Assert
            Assert.AreEqual(actual.Fen, expected.Fen);
        }

        [TestMethod]
        public void EatPawnValid()
        {
            // -- Arrange
            var expected = new Chess.Chess("rnbqkbnr/ppppppp1/11111111/11111111/11111111/1P111111/1PPPPPPP/RNBQKBNR b - - 0 1");
            // -- Act
            var actual = new Chess.Chess("rnbqkbnr/ppppppp1/11111111/11111111/11111111/1p111111/PPPPPPPP/RNBQKBNR w - - 0 1").Move("Pa2b3");
            // -- Assert
            Assert.AreEqual(actual.Fen, expected.Fen);
        }

        #endregion
    }
}
