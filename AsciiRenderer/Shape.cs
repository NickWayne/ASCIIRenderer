namespace AsciiRenderer
{
    public interface IShape
    {
        bool IsIntersecting(int cellX, int cellY);
        void Update();
        void UpdateDimmensions(int width, int height);
        bool IsIntersectingCircle(IShape circle2);
    }
}
