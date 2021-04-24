namespace AsciiRenderer
{
    public interface IShape
    {
        bool IsIntersecting(int cellX, int cellY);
        void Update();
    }
}
