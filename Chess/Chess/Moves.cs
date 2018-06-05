using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    class Moves
    {
        FigureMoving figureMoving;
        Board board;


        public Moves(Board board)
        {
            this.board = board;
        }


        public bool CanMove(FigureMoving figureMoving)
        {
            this.figureMoving = figureMoving;
            return
                CanMoveFrom() &&
                CanMoveTo() &&
                CanFigureMove();
        }

        private bool CanMoveTo()
        {
            return figureMoving.To.OnBoard() &&
                figureMoving.From != figureMoving.To &&
                board.GetFigureAt(figureMoving.To).GetColor() != board.MoveColor;
        }


        private bool CanMoveFrom()
        {
            return figureMoving.From.OnBoard() &&
                   figureMoving.Figure.GetColor() == board.MoveColor;
        }

        private bool CanFigureMove()
        {
            switch (figureMoving.Figure)
            {
                case Figure.whiteKing: 
                case Figure.blackKing:
                    return CanKingMove();

                case Figure.whiteQueen:
                case Figure.blackQueen:
                    return CanStraightMove();

                case Figure.whiteRook:
                case Figure.blackRook:
                    return figureMoving.SignX == 0 || figureMoving.SignY == 0 &&
                        CanStraightMove();

                case Figure.whiteBishop:
                case Figure.blackBishop:
                    return figureMoving.SignX != 0 && figureMoving.SignY != 0 &&
                        CanStraightMove();


                case Figure.whiteKnight: 
                case Figure.blackKnight:
                    return CanKnightMove();

                case Figure.whitePawn:
                case Figure.blackPawn:
                    return CanPawnMove();
                default: return false;
            }
        }

        private bool CanPawnMove()
        {
            if (figureMoving.From.Y<1 ||figureMoving.From.Y >6)
            {
                return false;
            }
            int stepY = figureMoving.Figure.GetColor() == Color.White ? 1 : -1;
            return CanPawnGo(stepY) || CanPawnJump(stepY) || CanPawnEat(stepY)
        }

        private bool CanPawnEat(int stepY)
        {
            if (board.GetFigureAt(figureMoving.To) != Figure.none)
                if (figureMoving.AbsDeltaX == 1)
                    if (figureMoving.DeltaY == stepY)
                        return true;
            return false;
        }

        private bool CanPawnJump(int stepY)
        {
            if (board.GetFigureAt(figureMoving.To) == Figure.none)
                if (figureMoving.DeltaX == 0)
                    if (figureMoving.DeltaY == 2 * stepY)
                        if (figureMoving.From.Y == 1 || figureMoving.From.Y == 6)
                            if (board.GetFigureAt(new Square(figureMoving.From.X, figureMoving.From.Y + stepY)) == Figure.none)
                                return true;
            return false;
        }

        private bool CanPawnGo(int stepY)
        {
            if (board.GetFigureAt(figureMoving.To) == Figure.none)
                if (figureMoving.DeltaX == 0)
                    if (figureMoving.DeltaY == stepY)
                        return true;
            return false;
        }

        private bool CanStraightMove()
        {
            Square at = figureMoving.From;
            do
            {
                at = new Square(at.X + figureMoving.SignX, at.Y + figureMoving.SignY);
                if (at == figureMoving.To)
                    return true;
            } while (at.OnBoard() && 
                     board.GetFigureAt(at) == Figure.none);
            return false;
        }

        private bool CanKingMove()
        {
            if (figureMoving.AbsDeltaX <= 1 && figureMoving.AbsDeltaY <= 1)
                return true;
            return false;
        }


        private bool CanKnightMove()
        {
            if (figureMoving.AbsDeltaX == 1 && figureMoving.AbsDeltaY == 2) return true;
            if (figureMoving.AbsDeltaX == 2 && figureMoving.AbsDeltaY == 1) return true;
            return false;
        }
    }
}
