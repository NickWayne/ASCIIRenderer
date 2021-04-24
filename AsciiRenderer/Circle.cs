using System;
using System.Collections.Generic;

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
        public double mass;

        public Circle(int width, int height, int x, int y, int radius, double mass)
        {
            this.width = width;
            this.height = height;
            this.x = x;
            this.y = y;
            this.radius = radius;
            this.mass = mass;
        }

        public void Update()
        {
            bool toReturn = false;
            if (Math.Floor(x + velocityX - radius) < 0 || Math.Floor(x + velocityX + radius) > width)
            {
                x = (Math.Floor(x + velocityX - radius) < 0) ? radius : width - radius;
                velocityX = -velocityX;
                toReturn = true;
            }
            if (Math.Floor(y + velocityY - radius) < 0 || Math.Floor(y + velocityY + radius) > height)
            {
                y = (Math.Floor(y + velocityY - radius) < 0) ? radius : height - radius;
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

        public void UpdateFriendlyFire(List<IShape> shapes)
        {
            x += velocityX;
            y += velocityY;
            foreach (var shape in shapes)
            {
                
                if (IsIntersectingCircle(shape) && shape != this)
                {
                    //velocityX = -velocityX;
                    //velocityY = -velocityY;

                    //TODO: Update IShape to Shape parent class
                    Circle cast = shape as Circle;
                    if (cast != null)
                    {
                        velocityX = (velocityX * (mass - cast.mass) + (2 * cast.mass * cast.velocityX)) / (mass + cast.mass);
                        velocityY = (velocityY * (mass - cast.mass) + (2 * cast.mass * cast.velocityY)) / (mass + cast.mass);
                        cast.velocityX = (cast.velocityX * (cast.mass - mass) +(2 * mass * velocityX)) / (mass + cast.mass);
                        cast.velocityY = (cast.velocityY * (cast.mass - mass) +(2 * mass * velocityY)) / (mass + cast.mass);
                        x += velocityX;
                        y += velocityY;
                    }

                }
               
            }
            if (x < 0 || x > width)
            {
                x = x < 0 ? radius : width - radius;
                velocityX = -velocityX;
            }
            if (y < 0 || y > height)
            {
                y = y < 0 ? radius : height - radius;
                velocityY = -velocityY;
            }

        }

        public bool isIntersectingWalls() {

            return false;
        }

        public void UpdateDimmensions(int width, int height)
        {
            this.width = width;
            this.height = height;
        }

        public bool IsIntersecting(int cellX, int cellY)
        {
            return (cellX - x) * (cellX - x) + (cellY - y) * (cellY - y) <= radius * radius;
        }

        public bool IsIntersectingCircle(IShape circle2)
        {
            double slop = 1;
            Circle cast = circle2 as Circle;
            if (cast != null)
            {
                return ((cast.x - x) * (cast.x - x) + (cast.y - y) * (cast.y - y)) + slop <= (radius + cast.radius) * (radius + cast.radius);
            }
            return false;
        }
    }
}
