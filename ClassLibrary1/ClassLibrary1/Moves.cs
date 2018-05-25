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

        private bool CanFigureMove()
        {
            switch (figureMoving.Figure)
            {
                case Figure.whiteKing: 
                case Figure.blackKing:
                    return CanKingMove();
                case Figure.whiteQueen:
                case Figure.blackQueen:
                    return false;
                case Figure.whiteRook:
                case Figure.blackRook:
                    return false;
                case Figure.whiteBishop:
                case Figure.blackBishop:
                    return false;
                case Figure.whiteKnight: 
                case Figure.blackKnight:
                    return CanKnightMove();
                case Figure.whitePawn:
                case Figure.blackPawn:
                    return false;
                default: return false;
            }
        }

        private bool CanKnightMove()
        {
            if (figureMoving.AbsDeltaX == 1 && figureMoving.AbsDeltaY == 2) return true;
            if (figureMoving.AbsDeltaX == 2 && figureMoving.AbsDeltaY == 1) return true;
            return false;
        }

        private bool CanKingMove()
        {
            if (figureMoving.AbsDeltaX <= 1 && figureMoving.AbsDeltaY <= 1)
                return true;
            return false;
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
    }
}
