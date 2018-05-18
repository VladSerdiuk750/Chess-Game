using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    class Board
    {
        private string _fen;
        private int _moveNumber;
        private Color _moveColor;
        Figure[,] figures;

        public string Fen
        {
            get { return _fen; }
            private set { _fen = value; }
        }
        public Color MoveColor
        {
            get { return _moveColor; }
            private set { _moveColor = value; }
        }       
        public int MoveNumber
        {
            get { return _moveNumber; }
            private set { _moveNumber = value; }
        }

        public Board(string fen)
        {
            Fen = fen;
            figures = new Figure[8, 8];
            Init();
        }

        // Helping method for initialization
        private void Init()
        {
            SetFigureAt(new Square("a1"), Figure.whiteKing);
            SetFigureAt(new Square("h8"), Figure.blackKing);
            MoveColor = Color.White;
        }

        // For retrieving figure at some square
        public Figure GetFigureAt(Square square)
        {
            if (square.OnBoard())
                return figures[square.X, square.Y];
            return Figure.none;
        }

        // For setting figure at some square
        private void SetFigureAt(Square square, Figure figure)
        {
            if (square.OnBoard())
               figures[square.X, square.Y] = figure;
        }

        // For realize moving
        public Board Move(FigureMoving figureMoving)
        {
            var next = new Board(Fen);
            next.SetFigureAt(figureMoving.From, Figure.none);
            next.SetFigureAt(figureMoving.To, figureMoving.Promotion == Figure.none ? figureMoving.Figure : figureMoving.Promotion);
            if (MoveColor == Color.Black)
                next.MoveNumber++;
            next.MoveColor = MoveColor.FlipColor();
            return next;
        }
    }
}
