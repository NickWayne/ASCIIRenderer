using System.Collections.Generic;

namespace AsciiRenderer
{
    public abstract class Shape
    {
        public double x = 0;
        public double y = 0;
        public double velocityX = 1;
        public double velocityY = -1;
        public double mass = 1;
        public PhysicsSettings physics;

        public Shape(double x, double y, double mass, PhysicsSettings physics)
        {
            this.x = x;
            this.y = y;
            this.mass = mass;
            this.physics = physics;
        }

        public abstract void Update(List<Shape> shapes, int width, int height);

        public abstract void BounceOffWalls(int width, int height);
        public abstract bool IsIntersectingCell(int cellX, int cellY);
        public abstract bool IsIntersectingShape(Shape shape);

        public abstract double ShapeOverlapAmount(int cellX, int cellY, int cellWidth, int cellHeight);

    }
}
