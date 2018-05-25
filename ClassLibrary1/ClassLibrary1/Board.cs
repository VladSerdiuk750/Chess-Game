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
            string[] parts = Fen.Split();
            if (parts.Length != 6) return;
            InitFigures(parts[0]);
            MoveColor = parts[1] == "b" ? Color.Black : Color.White;
            MoveNumber = int.Parse(parts[5]);   
        }

        private void InitFigures(string data)
        {
            for (int j = 8; j >= 2; j--)
            {
                data = data.Replace(j.ToString(), (j - 1).ToString() + "1");
            }
            data = data.Replace("1", ".");
            string[] lines = data.Split('/');
            for (int y = 7; y >= 0; y--)
            {
                for (int x = 0; x < 8; x++)
                {
                    figures[x, y] = lines[7 - y][x] == '.' ? Figure.none : 
                            (Figure)lines[7 - y][x];
                }
            }
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
            next.GenerateFen();
            return next;
        }

        private void GenerateFen()
        {
            Fen = FenFigures() + " " + (MoveColor == Color.White ? "w" : "b" + " - - 0 " + MoveNumber.ToString();
        }

        private string FenFigures()
        {
            var sb = new StringBuilder();
            for (int y = 7; y >= 0; y--)
            {
                for (int x = 0; x < 8; x++)
                {
                    sb.Append(figures[x, y] == Figure.none? '1':(char)figures[x,y]);
                }
                if(y>0)
                    sb.Append('/');
            }
            return sb.ToString();
        }
    }
}
