using System;

namespace AsciiRenderer
{
    public class Circle : IShape
    {
        public double x;
        public double y;
        public int width;
        public int height;
        public double velocityX;
        public double velocityY;
        public int radius;

        public Circle(int width, int height, int x, int y, int radius)
        {
            this.width = width;
            this.height = height;
            this.x = x;
            this.y = y;
            this.radius = radius;
            ChooseRandomVelocity();
        }

        public void Move()
        {
            bool toReturn = false;
            if (x + velocityX - radius < 0 || x + velocityX + radius > width)
            {
                x = (x + velocityX - radius < 0) ? radius : width - radius;
                velocityX = -velocityX;
                toReturn = true;
            }
            if (y + velocityY - radius < 0 || y + velocityY + radius > height)
            {
                y = (y + velocityY - radius < 0) ? radius : height - radius;
                velocityY = -velocityY;
                toReturn = true;
            }
            if (toReturn)
            {
                return;
            }
            else
            {
                x += velocityX;
                y += velocityY;
            }
        }

        public void ChooseRandomVelocity()
        {
            var random = new Random();
            velocityX = random.NextDouble();
            velocityY = random.NextDouble();
        }

        public bool IsIntersecting(int cellX, int cellY)
        {
            return ((cellX - x) * (cellX - x) +
            (cellY - y) * (cellY - y) <= radius * radius);
        }
    }
}
