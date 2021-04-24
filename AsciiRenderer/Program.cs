using System;
using System.Threading;

namespace AsciiRenderer
{
    class Program
    {
        static void Main(string[] args)
        {
            var random = new Random();

            var height = Console.WindowHeight - 1;
            var width = Console.WindowWidth - 1;

            var display = new Display(width, height)
            {
                IsBackgroundBlack = false
            };
            display.CreateCellsBoard();
            display.CreateShapes(6);
            

            while (true)
            {
                GameLoop(display);
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
