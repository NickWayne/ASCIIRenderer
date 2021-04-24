using System;
using System.Threading;

namespace AsciiRenderer
{
    class Program
    {
        static void Main(string[] args)
        {
            //var height = Console.WindowHeight - 1;
            //var width = Console.WindowWidth - 1;

            var height = 56;
            var width = 186;
            Console.WindowHeight = height;
            Console.WindowWidth = width;
            Console.BackgroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.Black;

            var display = new Display(width, height)
            {
                IsBackgroundBlack = false
            };
            display.CreateCellsBoard();
            display.CreateShapes(15, 2);

            while (true)
            {
                GameLoop(display);
                if (display.Height != Console.WindowHeight - 1 || display.Width != Console.WindowWidth - 1)
                {
                    display.UpdateDimmensions(Console.WindowWidth, Console.WindowHeight);
                    display.CreateCellsBoard();
                }
            }
        }

        public static void GameLoop(Display display)
        {
            display.RenderBoard();
            Thread.Sleep(40);
            display.UpdateBoard();
        }
    }
}
