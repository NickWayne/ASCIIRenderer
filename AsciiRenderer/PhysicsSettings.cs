namespace AsciiRenderer
{
    public class PhysicsSettings
    {
        public bool ShapeCollision { get; set; }
        public bool Gravity { get; set; }
        public bool Acceleration { get; set; }

        public PhysicsSettings(bool shapeCollision, bool gravity, bool acceleration)
        {
            ShapeCollision = shapeCollision;
            Gravity = gravity;
            Acceleration = acceleration;
        }

    }
}
