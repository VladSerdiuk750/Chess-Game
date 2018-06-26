using System.Collections.Generic;

namespace Chess
{
    // Main class for chess
    public class Chess
    {
        #region Fields and Properties

        Board _board;
        Moves _moves;
        List<FigureMoving> _figureMovings;

        // Field for saving Fen
        public string Fen { get; private set; }
        public bool IsCheck { get { return _board.IsCheck(); } }

        #endregion

        #region Constructors

        public Chess(string fen = "rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1")
        {
            this.Fen = fen;
            _board = new Board(fen);
            _moves = new Moves(_board);
        }

        private Chess(Board board)
        {
            this._board = board;
            Fen = board.Fen;
            _moves = new Moves(board);
        }

        #endregion

        #region Move

        public Chess Move(string move) // Pe2e4         Pe7e8Q
        {
            var fm = new FigureMoving(move);

            if (_moves.CanMove(fm) == false)
                return this;
            if (_board.IsCheckAfterMove(fm) == true)
                return this;
            Board nextBoard = _board.Move(fm);
            var nextChess = new Chess(nextBoard);
            return nextChess;
        }

        #endregion

        #region Get figure at

        // For getting figure from coordinates
        public char GetFigureAt(int x, int y)
        {
            var square = new Square(x, y);
            Figure figure = _board.GetFigureAt(square);
            return (figure != Figure.none) ? (char)figure : '.';
        }

        #endregion

        #region Get and find all moves

        public ICollection<string> GetAllMoves()
        {
            FindAllMoves();
            var listOfMoves = new List<string>();
            _figureMovings.ForEach(x => listOfMoves.Add(x.ToString()));
            return (listOfMoves as ICollection<string>);
        }

        private void FindAllMoves()
        {
            _figureMovings = new List<FigureMoving>();
            foreach (FigureOnSquare fs in _board.YieldFigures())
            {
                foreach (Square to in Square.YieldSquares())
                {
                    var fm = new FigureMoving(fs, to);
                    if (_moves.CanMove(fm) == true)
                        if(_board.IsCheckAfterMove(fm) == false)
                            _figureMovings.Add(fm);
                }
            } 
        }

        #endregion
    }
}
