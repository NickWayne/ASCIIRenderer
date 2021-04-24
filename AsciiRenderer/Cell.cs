using System;

namespace AsciiRenderer
{
    public class Cell
    {
        public int X { get; set; }

        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        public char Character { get; set; }


        public double CharacterWeight { get; set; }

        public Cell(int x, int y)
        {
            X = x;
            Y = y;
        }

        public char GetCharacter(bool isBackgroundBlack)
        {
            //string characters = " ■"; /*Dotted */
            //string characters = " █"; /*Solid*/
            //string characters = " .'`^\",:; Il!i >< ~+_ -?][}{1)(|\\/tfjrxnuvczXYUJCLQ0OZmwqpdbkhao*#MW&8%B@$";
            string characters = " .:-=+*#%█";
            double charWeight = CharacterWeight;
            if (isBackgroundBlack)
            {
                charWeight = 1 - charWeight;
            }
            int index = Math.Clamp((int) (charWeight * (characters.Length - 1)), 0, characters.Length - 1);
            return characters[index];
        }
    }
}