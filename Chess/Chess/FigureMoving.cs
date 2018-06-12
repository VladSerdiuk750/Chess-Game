using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    class FigureMoving
    {
        #region Properties

        public Figure Figure { get; private set; }
        public Square From { get; private set; }
        public Square To { get; private set; }
        public Figure Promotion { get; private set; }

        #endregion

        #region Helpful values
        public int DeltaX { get { return To.X - From.X; } }
        public int DeltaY { get { return To.Y - From.Y; } }


        public int AbsDeltaX { get { return Math.Abs(DeltaX); } }
        public int AbsDeltaY { get { return Math.Abs(DeltaY); } }


        public int SignX { get { return Math.Sign(DeltaX); } }
        public int SignY { get { return Math.Sign(DeltaY); } }

        #endregion

        #region Constructors

        public FigureMoving(FigureOnSquare figureOnSquare, Square to, Figure promotion = Figure.none)
        {
            Figure = figureOnSquare.Figure;
            From = figureOnSquare.Square;
            To = to;
            Promotion = promotion;
        }
        
  
        public FigureMoving(string move)
        {
            Figure = (Figure)move[0];
            From = new Square(move.Substring(1, 2));
            To = new Square(move.Substring(3, 2));
            Promotion = (move.Length == 6) ? (Figure)move[5] : Figure.none; 
        }

        #endregion

        public override string ToString()
        {
            string text = (char)Figure + From.Name + To.Name;
            if (Promotion != Figure.none)
            {
                text += (char)Promotion;
            }
            return text;
        }
    }
}
