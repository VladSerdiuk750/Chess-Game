using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    class FigureMoving
    {
        // Properties for moving figure
        public Figure Figure { get; private set; }
        public Square From { get; private set; }
        public Square To { get; private set; }
        public Figure Promotion { get; private set; }

        // Constructor for free creating by params
        public FigureMoving(FigureOnSquare figureOnSquare, Square to, Figure promotion = Figure.none)
        {
            Figure = figureOnSquare.Figure;
            From = figureOnSquare.Square;
            To = to;
            Promotion = promotion;
        }
        
        // Constructor for creating from fen
        public FigureMoving(string move)
        {
            Figure = (Figure)move[0];
            From = new Square(move.Substring(1, 2));
            To = new Square(move.Substring(3, 2));
            Promotion = move.Length == 6 ? (Figure)move[5] : Figure.none; 
        }

        public int DeltaX { get { return To.X - From.X; } }
        public int DeltaY { get { return To.Y - From.Y; } }


        public int AbsDeltaX { get { return Math.Abs(DeltaX); } }
        public int AbsDeltaY { get { return Math.Abs(DeltaY); } }


        public int AbsSignX { get { return Math.Sign(DeltaX); } }
        public int AbsSignY { get { return Math.Sign(DeltaY); } }
    }
}
