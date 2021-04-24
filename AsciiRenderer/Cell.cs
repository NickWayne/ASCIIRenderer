using System;

namespace AsciiRenderer
{
    public class Cell
    {
        public int X;
        public int Y;
        public char Value;
        public bool ToDisplay;

        public Cell(int x, int y, char value)
        {
            X = x;
            Y = y;
            Value = value;
            ToDisplay = true;
        }
        public char getValue()
        {
            return ToDisplay ? Value : ' ';
        }
    }
}