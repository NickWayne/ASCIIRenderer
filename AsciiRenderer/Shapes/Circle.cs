using System;
using System.Collections.Generic;

namespace AsciiRenderer
{
    public class Circle : Shape
    {
        public double radius;

        public Circle(double x, double y, double radius, double mass, PhysicsSettings physics) : base(x, y, mass, physics)
        {
            this.radius = radius;
        }

        public override void Update(List<Shape> shapes, int width, int height)
        {
            // Add Velocity
            x += velocityX;
            y += velocityY;
            foreach (var shape in shapes)
            {
                if (shape != this)
                {
                    if (physics.ShapeCollision)
                    {
                        IsIntersectingShape(shape);
                    }
                }
            }
            BounceOffWalls(width, height);
        }

        public override void BounceOffWalls(int width, int height) 
        {
            // Hitting left or right wall
            if (x - radius <= 0 || x + radius >= width)
            {
                x = x - radius < 0 ? radius : width - radius;
                velocityX = -velocityX;
            }

            // Hitting top or bottom wall
            if (y - radius <= 0 || y + radius >= height)
            {
                y = y - radius < 0 ? radius : height - radius;
                velocityY = -velocityY;
            }
        }

        public override bool IsIntersectingCell(int cellX, int cellY)
        {
            return (cellX - x) * (cellX - x) + (cellY - y) * (cellY - y) <= radius * radius;
        }

        public override double ShapeOverlapAmount(int cellX, int cellY)
        {
            var countOverlap = 0;
            int cellWidth = 10;
            int cellHeight = 10;
            double distance = Math.Pow(cellX - x, 2) + Math.Pow(cellY - y, 2);
            if (distance < Math.Pow(radius, 2))
            {
                for (double w = -cellWidth / 2; w < cellWidth / 2; w++)
                {
                    for (double h = -cellHeight / 2; h < cellHeight / 2; h++)
                    {
                        if (w == 0 || h == 0) distance = Math.Pow(cellX - x, 2) + Math.Pow(cellY - y, 2);
                        else distance = Math.Pow((cellX - x) + 1.0 / w, 2) + Math.Pow((cellY - y) + 1.0 / h, 2);

                        if (distance < Math.Pow(radius, 2))// Inside circle
                        {
                            countOverlap += 1;
                        }
                    }
                }
            }
            double overlapPercentage = (double)countOverlap / (cellWidth * cellHeight);
            return overlapPercentage;
        }

        public override bool IsIntersectingShape(Shape shape)
        {
            return shape switch
            {
                Circle s => IsIntersectingCircle(s),
                _ => throw new ArgumentException(
                          message: "shape is not a recognized shape",
                          paramName: nameof(shape)),
            };
        }

        public bool IsIntersectingCircle(Circle circle)
        {
            if (((circle.x - x) * (circle.x - x) + (circle.y - y) * (circle.y - y)) <= (radius + circle.radius) * (radius + circle.radius))
            {
                velocityX = (velocityX * (mass - circle.mass) +(2 * circle.mass * circle.velocityX)) / (mass + circle.mass);
                velocityY = (velocityY * (mass - circle.mass) +(2 * circle.mass * circle.velocityY)) / (mass + circle.mass);
                circle.velocityX = (circle.velocityX * (circle.mass - mass) +(2 * mass * velocityX)) / (mass + circle.mass);
                circle.velocityY = (circle.velocityY * (circle.mass - mass) +(2 * mass * velocityY)) / (mass + circle.mass);
                x += velocityX;
                y += velocityY;
                circle.x += circle.velocityX;
                circle.y += circle.velocityY;
                return true;
            }
            return false;
        }
    }
}
