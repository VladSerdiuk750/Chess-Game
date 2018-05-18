using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chess;

namespace ChessDemo
{
    class Program
    {
        // Console project for testing
        static void Main(string[] args)
        {
            var chess = new Chess.Chess();
            while (true)
            {
                Console.WriteLine(chess.Fen);
                Console.WriteLine(ChessToAscii(chess));
                string move = Console.ReadLine();
                if (move == "") break;
                chess.Move(move);
            }
        }

        // For visualisation chess in console
        static string ChessToAscii(Chess.Chess chess)
        {
            string text = "  +-----------------+";
            for (int y = 7; y>=0;y--)
            {
                text += y + 1;
                text += " | ";
                for (int x = 0; x < 8; x++)
                {
                    text += chess.GetFigureAt(x, y) + " ";
                }
                text += "|\n";
            }
            text += "  +-----------------+";
            text += "    a b c d e f g h\n";
            return text;
        }
    }
}
