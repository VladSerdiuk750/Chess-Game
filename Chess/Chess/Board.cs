using System;
using System.Collections.Generic;
using System.Text;

namespace Chess
{
    class Board
    {
        #region Fields and Properties

        Figure[,] _figures;

        public string Fen { get; private set; }
        public int MoveNumber { get; private set; }
        public Color MoveColor { get; private set; }

        #endregion

        #region Constructor

        public Board(string fen)
        {
            Fen = fen;
            _figures = new Figure[8, 8];
            Init();
        }

        #region Init
        // Helping method for initialization
        private void Init()
        {
            string[] parts = Fen.Split();
            if (parts.Length == 6) 
            {
                string figure = parts[0];
                InitFigures(figure);

                MoveColor = (parts[1] == "b") ? Color.Black : Color.White;

                string moveNumber = parts[5];
                ParseAndInitMoveNumber(moveNumber);
            }
        }

        #region InitFigures
        private void InitFigures(string data)
        {
            string[] lines = ValidationData(data);
            for (int x = 0; x < 8; x++)
                for (int y = 7; y >= 0; y--) _figures[x, y] = (lines[7 - y][x] == '.') ? Figure.none :
                                                                                        (Figure)lines[7 - y][x];
        }

        private string[] ValidationData(string data)
        {
            for (int j = 8; j >= 2; j--)
            {
                data = data.Replace(j.ToString(), (j - 1).ToString() + "1");
            }
            data = data.Replace("1", ".");
            return data.Split('/'); ;
        }

        #endregion InitFigures

        private void ParseAndInitMoveNumber(string moveNumber)
        {
            int moveNumberResult;
            MoveNumber = (int.TryParse(moveNumber, out moveNumberResult)) ? moveNumberResult :
                                                                throw new ArgumentException("Move number is invalid");
        }

        #endregion Init

        #endregion Constructor

        #region Get or Set Figure At

        // For retrieving figure at some square
        public Figure GetFigureAt(Square square) => square.OnBoard()? _figures[square.X, square.Y] : Figure.none;

        // For setting figure at some square
        private void SetFigureAt(Square square, Figure figure)
        {
            _figures[square.X, square.Y] = square.OnBoard() ? figure : throw new ArgumentException("Square out of the board");
        }

        #endregion

        #region Move

        // For realize moving
        public Board Move(FigureMoving fm)
        {
            var next = new Board(Fen);

            next.SetFigureAt(fm.From, Figure.none);
            next.SetFigureAt(fm.To, CheckingOnPromotion(fm));

            ChangingMoveNumberAndFlipColor(next);
            next.GenerateFen();
            return next;
        }

        private Figure CheckingOnPromotion(FigureMoving fm) => (fm.Promotion == Figure.none) ? fm.Figure : 
                                                                                               fm.Promotion;
        private void ChangingMoveNumberAndFlipColor(Board next)
        {
            if (MoveColor == Color.Black) next.MoveNumber++;
            next.MoveColor = MoveColor.FlipColor();
        }

        private void GenerateFen()
        {
            Fen = FenFigures() + " " + ((MoveColor == Color.White) ? "w" : "b") + " - - 0 " + MoveNumber.ToString();
        }

        private string FenFigures()
        {
            var sb = new StringBuilder();
            for (int y = 7; y >= 0; y--)
            {
                for (int x = 0; x < 8; x++)
                {
                    sb.Append((_figures[x, y] != Figure.none) ? (char)_figures[x, y] : '1');
                }
                if (y > 0)
                    sb.Append('/');
            }
            return sb.ToString();
        }

        #endregion

        #region Is Check

        public bool IsCheckAfterMove(FigureMoving fm)
        {
            Board after = Move(fm);
            Figure checkedKing = (MoveColor == Color.Black) ? Figure.whiteKing : Figure.blackKing;
            return after.CanEatKing(whereIsCheckedKing: FindCheckedKing(checkedKing));
        }

        public bool IsCheck()
        {
            var after = new Board(Fen);
            after.MoveColor = MoveColor.FlipColor();

            Figure checkedKing = (MoveColor == Color.Black) ? Figure.whiteKing : Figure.blackKing;
            Square whereIsCheckedKing = FindCheckedKing(checkedKing);
            return after.CanEatKing(whereIsCheckedKing);
        }

        private Square FindCheckedKing(Figure checkedKing)
        {
            foreach(Square square in Square.YieldSquares())
            {
                if (GetFigureAt(square) == checkedKing)
                    return square;
            }
            return Square.none;
        }


        private bool CanEatKing(Square whereIsCheckedKing)
        {
            Moves moves = new Moves(this);
            foreach (FigureOnSquare fs in YieldFigures())
            {
                FigureMoving fm = new FigureMoving(fs, whereIsCheckedKing);
                if(moves.CanMove(fm))
                    return true;
            }
            return false;
        }

        public IEnumerable<FigureOnSquare> YieldFigures()
        {
            foreach (Square square in Square.YieldSquares())
            {
                if (GetFigureAt(square).GetColor() == MoveColor) yield return new FigureOnSquare(GetFigureAt(square), square);
            }
        }

        #endregion`
    }
}
