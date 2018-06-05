using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    // Main class for chess
    public class Chess
    {
        // Field for saving Fen
        public string Fen { get; private set; }
        Board board;
        Moves moves;
        List<FigureMoving> figureMovings;

        // Constructor
        public Chess(string fen = "rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1")
        {
            this.Fen = fen;
            board = new Board(fen);
            moves = new Moves(board);
        }

        Chess(Board board)
        {
            this.board = board;
            Fen = board.Fen;
            moves = new Moves(board);
        }

        // Method for moving
        public Chess Move(string move) // Pe2e4         Pe7e8Q
        {
            var figureMoving = new FigureMoving(move);
            if (!moves.CanMove(figureMoving))
                return this;
            if (board.IsCheckAfterMove(figureMoving))
                return this;
            Board nextBoard = board.Move(figureMoving);
            return new Chess(nextBoard);
        }

        // For getting figure from coordinates
        public char GetFigureAt(int x, int y)
        {
            var square = new Square(x, y);
            Figure figure = board.GetFigureAt(square);
            return figure == Figure.none ? '.' : (char)figure;
        }


        void FindAllMoves()
        {
            figureMovings = new List<FigureMoving>();
            foreach (FigureOnSquare fs in board.YieldFigures())
            {
                foreach (Square to in Square.YieldSquares())
                {
                    FigureMoving figureMoving = new FigureMoving(fs, to);
                    if (moves.CanMove(figureMoving))
                        if(!board.IsCheckAfterMove(figureMoving))
                            figureMovings.Add(figureMoving);
                }
            } 
        }

        public ICollection<string> GetAllMoves()
        {
            FindAllMoves();
            List<string> list = new List<string>();
            foreach (FigureMoving fm in figureMovings)
            {
                list.Add(fm.ToString());
            }
            return list;
        }

        public bool IsCheck() => board.IsCheck();
    }
}
