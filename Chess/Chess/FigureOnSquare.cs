using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    class FigureOnSquare
    {
        #region Properties
        // Properties for binding Figure and Square
        public Figure Figure { get; private set; }
        public Square Square { get; private set; }
        #endregion
        #region Constructor
        // Constructor for populating properties 
        public FigureOnSquare(Figure figure, Square square)
        {
            Figure = figure;
            Square = square;
        }
        #endregion
    }
}
