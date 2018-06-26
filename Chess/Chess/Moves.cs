using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    class Moves
    {
        #region Fields

        FigureMoving _fm;
        Board _board;

        #endregion

        #region Constructor

        public Moves(Board board)
        {
            this._board = board;
        }

        #endregion

        #region Can Move
        public bool CanMove(FigureMoving fm)
        {
            this._fm = fm;

            var From = CanMoveFrom(_fm.To.OnBoard());
            var To = CanMoveTo(_fm.To.OnBoard());
            var FigureMove = CanFigureMove();

            return From && To && FigureMove;
        }

        private bool CanMoveTo(bool isOnBoard)
        {
            var isDifferentSquares = _fm.From != _fm.To;
            var isRightColor = _board.GetFigureAt(_fm.To).GetColor() != _board.MoveColor;

            return isOnBoard && isDifferentSquares && isRightColor;     
        }

        private bool CanMoveFrom(bool isOnBoard)
        { 
            var isMoveColorRight = _fm.Figure.GetColor() == _board.MoveColor;

            return isOnBoard && isMoveColorRight;
                   
        }
       
        #region CanFigureMove
        private bool CanFigureMove()
        {
            switch (_fm.Figure)
            {
                case Figure.whiteKing: 
                case Figure.blackKing:
                    return CanKingMove();

                case Figure.whiteQueen:
                case Figure.blackQueen:
                    return CanQueenMove();

                case Figure.whiteRook:
                case Figure.blackRook:
                    return CanRookMove();

                case Figure.whiteBishop:
                case Figure.blackBishop:
                    return CanBishopMove();

                case Figure.whiteKnight: 
                case Figure.blackKnight:
                    return CanKnightMove();

                case Figure.whitePawn:
                case Figure.blackPawn:
                    return CanPawnMove();
                default: return false;
            }
        }

        private bool CanStraightMove()
        {
            Square at = _fm.From;
            do
            {
                at = new Square(at.X + _fm.SignX, at.Y + _fm.SignY);
                if (at == _fm.To)
                    return true;
            } while (at.OnBoard() &&
                     _board.GetFigureAt(at) == Figure.none);
            return false;
        }


        #region King
        private bool CanKingMove()
        {
            var isMoveOnlyOneSquare = _fm.AbsDeltaX <= 1 && _fm.AbsDeltaY <= 1;
            if (isMoveOnlyOneSquare)
                return true;
            return false;
        }
        #endregion

        #region Queen
        private bool CanQueenMove() => CanStraightMove();
        #endregion

        #region Rook
        private bool CanRookMove()
        {
            var isItDiagon = _fm.SignX == 0 || _fm.SignY == 0;
            return  isItDiagon && CanStraightMove();
        }
        #endregion
  
        #region Bishop
        private bool CanBishopMove()
        {
            var isItDiagon = _fm.SignX != 0 && _fm.SignY != 0;

            return isItDiagon && CanStraightMove();
        }
        #endregion

        #region Knight
        private bool CanKnightMove()
        {
            if (_fm.AbsDeltaX == 1 && _fm.AbsDeltaY == 2) return true;
            if (_fm.AbsDeltaX == 2 && _fm.AbsDeltaY == 1) return true;
            return false;
        }
        #endregion

        #region Pawn
        private bool CanPawnMove()
        {
            if (_fm.From.Y < 1 || _fm.From.Y > 6)
            {
                return false;
            }
            var stepY = (_fm.Figure.GetColor() == Color.White) ? 1 : -1;

            var CanGo = CanPawnGo(stepY);
            var CanJump = CanPawnJump(stepY);
            var CanEat = CanPawnEat(stepY);

            return CanGo || CanJump || CanEat;
        }

        private bool CanPawnGo(int stepY)
        {
            var isEmptyOnDestinationSquare = _board.GetFigureAt(_fm.To) == Figure.none;
            var isStraightMove = _fm.DeltaX == 0;
            var isMoveisOneSquare = _fm.DeltaY == stepY;
            
            return isEmptyOnDestinationSquare && isStraightMove && isMoveisOneSquare;
        }

        private bool CanPawnJump(int stepY)
        {
            var isEmptyOnDestinationSquare = _board.GetFigureAt(_fm.To) == Figure.none;
            var isStraightMove = _fm.DeltaX == 0;
            var isMoveTwoSquares = _fm.DeltaY == stepY * 2;
            var isPawnOnRightSquare = _fm.From.Y == 1 || _fm.From.Y == 6;
            var isEmptyOnTheNextSquare = _board.GetFigureAt(new Square(_fm.From.X, _fm.From.Y + stepY)) == Figure.none;

            return isEmptyOnDestinationSquare && isStraightMove && isMoveTwoSquares &&
                   isPawnOnRightSquare && isEmptyOnTheNextSquare;
        }

        private bool CanPawnEat(int stepY)
        {
            var isFigureOnDestinationSquare = _board.GetFigureAt(_fm.To) != Figure.none;
            var isMoveOnlyOneSquareLeftOrRight = _fm.AbsDeltaX == 1;
            var isStepEqualDeltaY = _fm.DeltaY == stepY;

            return isFigureOnDestinationSquare && isMoveOnlyOneSquareLeftOrRight && isStepEqualDeltaY;
        }
        #endregion

        #endregion

        #endregion
    }
}
    