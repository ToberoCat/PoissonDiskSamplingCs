namespace PoissonDiskSampling.PoissonDiskSampler
{
    public readonly struct Circle
    {
        public Circle(float radius, Vector2 point)
        {
            Radius = radius;
            Point = point;
        }

        public override string ToString()
        {
            return "Radius: " + Radius + "; Position: " + Point;
        }

        public float Radius { get; }

        public Vector2 Point { get; }
    }
}