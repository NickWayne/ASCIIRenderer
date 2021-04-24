using System;
using System.Collections.Generic;
using System.Linq;

namespace AsciiRenderer
{
    public class Display
    {
        public List<List<Cell>> Cells;
        public List<IShape> shapes = new List<IShape>();
        public int Width;
        public int Height;

        public Display(int width, int height)
        {
            Width = width;
            Height = height;
            Console.CursorVisible = false;
            shapes.Add(new Circle(width, height, 100, 100, 5));
        }

        public void CreateCellsBoard()
        {
            Cells = new List<List<Cell>>();
            var rand = new Random();
            for (int x = 0; x < Width; x++)
            {
                var cellRow = new List<Cell>();
                for (int y = 0; y < Height; y++)
                {
                    cellRow.Add(new Cell(x, y, (char)rand.Next('a', 'z')));
                }
                Cells.Add(cellRow);
            }
        }

        public void RenderBoard()
        {
            UpdateBoard();
            Console.SetCursorPosition(0, 0);
            foreach (var cellRow in Cells)
            {
                Console.WriteLine(ReadRow(cellRow));
            }
        }

        public void UpdateBoard()
        {
            foreach (var cellRow in Cells)
            {
                foreach (var shape in shapes)
                {
                    foreach (var  cell in cellRow)
                    {
                        cell.ToDisplay = !shape.IsIntersecting(cell.X, cell.Y);
                    }
                    shape.Move();
                }
            }
        }

        public static string ReadRow(List<Cell> cellRow)
        {
            return new string(cellRow.Select(cell => cell.getValue()).ToArray());
        }
    }
}
