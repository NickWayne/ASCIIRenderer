using System;
using System.Collections.Generic;
using System.Linq;

namespace AsciiRenderer
{
    public class Display
    {
        public List<List<Cell>> Cells;
        public List<Shape> Shapes = new();
        public int Width;
        public int Height;
        public int CellWidth = 8;
        public int CellHeight = 8;
        public bool IsBackgroundInverted = true;
        public PhysicsSettings physicsSettings;

        public Display(int width, int height, PhysicsSettings physics)
        {
            Width = width;
            Height = height;
            physicsSettings = physics;
        }

        public void CreateCellsBoard()
        {
            Cells = new List<List<Cell>>();
            for (int y = 0; y < Height; y++)
            {
                var cellRow = new List<Cell>();
                for (int x = 0; x < Width; x++)
                {
                    cellRow.Add(new Cell(x, y));
                }
                Cells.Add(cellRow);
            }
        }

        public void CreateShapes(int number, double sizeMax, double velocityMax, double massMax)
        {
            var rand = new Random();
            for (int i = 0; i < number; i++)
            {
                var circle = new Circle(rand.Next((int) (Width - sizeMax)), rand.Next((int)(Height - sizeMax)), rand.NextDouble() * sizeMax + .5, rand.NextDouble() * massMax, physicsSettings)
                {
                    velocityX = rand.NextDouble() * velocityMax,
                    velocityY = rand.NextDouble() * velocityMax
                };
                Shapes.Add(circle);
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
            Shapes.ForEach(shape => shape.Update(Shapes, Width, Height));

            foreach(var cellRow in Cells)
            {
                foreach (var cell in cellRow)
                {
                    cell.CharacterWeight = Shapes.Max(shape => shape.ShapeOverlapAmount(cell.X, cell.Y, CellWidth, CellHeight));
                }
            }
        }

        public void UpdateDimmensions(int width, int height)
        {
            Width = width;
            Height = height;
            Console.CursorVisible = false;
        }

        public string ReadRow(List<Cell> cellRow)
        {
            return new string(cellRow.Select(cell => cell.GetCharacter(IsBackgroundInverted)).ToArray());
        }
    }
}
