using System;
using System.Threading;

namespace AsciiRenderer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            var height = 50;
            var width = 80;
            Console.WindowHeight = height + 1;
            Console.WindowWidth =  width + 1;
            //Console.BackgroundColor = ConsoleColor.Green;
            //Console.ForegroundColor = ConsoleColor.Black;

            var physicsSettings = new PhysicsSettings(false, false, false);

            var display = new Display(width, height, physicsSettings)
            {
                IsBackgroundInverted = false
            };
            display.CreateCellsBoard();
            display.CreateShapes(10, 5, 1, 1);

            while (true)
            {
                GameLoop(display);
                if (display.Height != Console.WindowHeight - 1 || display.Width != Console.WindowWidth - 1)
                {
                    Console.Clear();
                    Console.SetCursorPosition(0, 0);
                    display.UpdateDimmensions(Console.WindowWidth - 1, Console.WindowHeight - 1);
                    display.CreateCellsBoard();
                }
            }
        }

        public static void GameLoop(Display display)
        {
            display.RenderBoard();
            Thread.Sleep(10);
            display.UpdateBoard();
        }
    }
}
