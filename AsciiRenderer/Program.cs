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
            var height = Console.WindowHeight;
            var width = Console.WindowWidth;
            Console.WindowHeight +=  1;
            Console.WindowWidth +=  1;
            //Console.BackgroundColor = ConsoleColor.Green;
            //Console.ForegroundColor = ConsoleColor.Black;

            var physicsSettings = new PhysicsSettings(false, false, false);

            var display = new Display(width, height, physicsSettings)
            {
                IsBackgroundInverted = true
            };
            display.CreateCellsBoard();
            display.CreateShapes(20, 5, 1, 10);

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
