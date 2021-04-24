using System;

namespace AsciiRenderer
{
    public class Cell
    {
        public int X;
        public int Y;
        public char Value;
        public bool ToDisplay;
        public double characterWeight;

        public Cell(int x, int y, char value)
        {
            X = x;
            Y = y;
            Value = value;
            ToDisplay = true;
            characterWeight = 0;
        }
        public char getValue(bool IsBackgroundBlack)
        {
            string characters = " .:-=+*#%@";
            int index = Math.Clamp((int) (characterWeight * (characters.Length - 1)), 0, characters.Length - 1);
            return ToDisplay ^ IsBackgroundBlack ? characters[index] : ' ';
        }
    }
}