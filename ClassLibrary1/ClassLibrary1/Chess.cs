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
        private string _fen;
        public string Fen
        {
            get { return _fen; }
            private set { _fen = value; }
        }
        Board board;

        // Constructor
        public Chess(string fen = "rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1")
        {
            this.Fen = fen;
            board = new Board(fen);
        }

        Chess(Board board)
        {
            this.board = board; 
        }

        // Method for moving
        public Chess Move(string move) // Pe2e4         Pe7e8Q
        {
            var figureMoving = new FigureMoving(move);
            var nextBoard = board.Move(figureMoving);
            return new Chess(nextBoard);
        }

        // For getting figure from coordinates
        public char GetFigureAt(int x, int y)
        {
            var square = new Square(x, y);
            Figure figure = board.GetFigureAt(square);
            return figure == Figure.none ? '.' : (char)figure;
        }
    }
}
