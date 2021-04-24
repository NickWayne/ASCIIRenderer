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
        public bool IsBackgroundBlack = true;

        public Display(int width, int height)
        {
            Width = width;
            Height = height;
            Console.CursorVisible = false;
        }

        public void CreateCellsBoard()
        {
            Cells = new List<List<Cell>>();
            var rand = new Random();
            for (int y = 0; y < Height; y++)
            {
                var cellRow = new List<Cell>();
                for (int x = 0; x < Width; x++)
                {
                    cellRow.Add(new Cell(x, y, 'a'));
                }
                Cells.Add(cellRow);
            }
        }

        public void CreateShapes(int number, double velocityMax)
        {
            var rand = new Random();
            for (int i = 0; i < number; i++)
            {
                var circle = new Circle(Width, Height, rand.Next(100), rand.Next(100), rand.Next(2, 5), rand.Next(2, 5))
                {
                    velocityX = rand.NextDouble() * velocityMax,
                    velocityY = rand.NextDouble() * velocityMax
                };
                shapes.Add(circle);
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
            foreach (var shape in shapes)
            {
                Circle shapeAsCircle = shape as Circle;
                if (shapeAsCircle != null) {
                    shapeAsCircle.UpdateFriendlyFire(shapes);
                }
            }

            foreach(var cellRow in Cells)
            {
                foreach (var cell in cellRow)
                {
                    cell.ToDisplay = shapes.Where(shape => shape.IsIntersecting(cell.X, cell.Y)).Any();
                }
            }
        }

        public void UpdateDimmensions(int width, int height)
        {
            Width = width;
            Height = height;
            foreach (var shape in shapes)
            {
                shape.UpdateDimmensions(width, height);
            }
        }

        public string ReadRow(List<Cell> cellRow)
        {
            return new string(cellRow.Select(cell => cell.getValue(IsBackgroundBlack)).ToArray());
        }

        public static double GenerateVelocity(double max)
        {
            var random = new Random();
            return random.NextDouble() * max;
        }
    }
}
