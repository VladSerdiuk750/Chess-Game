namespace Chess
{
    // Enumeration for colors
    enum Color
    {
        none,
        Black,
        White
    }
    
    // class for extention method to enumeration
    static class ColorExtentionMethods
    {
        // Extention method for enumeration to change the color
        public static Color FlipColor(this Color color)
        {
            if (color == Color.White) return Color.Black;
            if (color == Color.Black) return Color.White;
            return Color.none;
        }
    }
}
