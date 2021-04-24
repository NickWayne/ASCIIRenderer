using System;
using System.Linq;
using System.Text;
using System.Threading;

namespace AsciiRenderer
{
    class Program
    {
        static void Main(string[] args)
        {
            var display = new Display(28, 102);
            display.CreateCellsBoard();
            while (true)
            {
                GameLoop(display);
            }
        }

        public static void GameLoop(Display display)
        {
            display.RenderBoard();
            Thread.Sleep(20);
            display.UpdateBoard();
        }
    }
}
