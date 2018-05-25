using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    struct Square
    {
        // var for returning empty isn't existing Square
        public static Square none = new Square(-1, 1);

        // Properties location
        public int X { get; private set; }
        public int Y { get; private set; }

        // Constructor for defining by coordinates
        public Square(int x, int y)
        {
            X = x;
            Y = y;
        }

        // Constructor for defining by part of fen
        public Square(string e2)
        {
            if (e2.Length == 2 &&
               e2[0] >= 'a' && e2[0] <= 'h' &&
               e2[1] >= '1' && e2[1] <= '8')
            {
                X = e2[0] - 'a';
                Y = e2[1] - '1';
            }
            else
                this = none;
        }

        // Method for checking existing this Square on board
        public bool OnBoard()
        {
            return X >= 0 && X < 8 && 
                   Y >= 0 && Y < 8;
        }

        public static bool operator ==(Square a, Square b) => a.X == b.X && a.Y == b.Y;
        public static bool operator !=(Square a, Square b) => !(a == b);
    }
}
