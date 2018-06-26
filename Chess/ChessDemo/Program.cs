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
            var rand = new Random();
            List<string> list;
            var chess = new Chess.Chess();
            while (true)
            {
                list = (List<string>)chess.GetAllMoves();
                Console.WriteLine(chess.Fen);
                Print(ChessToAscii(chess));
                Console.WriteLine(chess.IsCheck ? "CHECK" : "-");
                foreach (string moves in chess.GetAllMoves())
                {
                    Console.Write(moves + "\t");
                }
                Console.Write("\n> ");
                string move = Console.ReadLine();
                if (move == "q") break;
                if (move == "") move = list[rand.Next(list.Count)];
                chess = chess.Move(move);
            }
        }

        // For visualisation chess in console
        static string ChessToAscii(Chess.Chess chess)
        {
            string text = "  +-----------------+\n";
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
            text += "  +-----------------+\n";
            text += "    a b c d e f g h\n";
            return text;
        }

        // For printing board in different colors
        static void Print(string text)
        {
            ConsoleColor oldForeColor = Console.ForegroundColor;
            foreach(char x in text)
            {
                if (x >= 'a' && x <= 'z')
                    Console.ForegroundColor = ConsoleColor.Red;
                else if (x >= 'A' && x <= 'Z')
                    Console.ForegroundColor = ConsoleColor.White;
                else
                    Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write(x);
            }
            Console.ForegroundColor = oldForeColor;
        }
    }
}
