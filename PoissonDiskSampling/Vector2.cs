using System;

namespace PoissonDiskSampling
{
    public class Vector2
    {
        public Vector2(float x, float y)
        {
            X = x;
            Y = y;
        }

        public Vector2(double x, double y)
        {
            X = (float) x;
            Y = (float) y;
        }

        public float Sqrmagnitude => X * X + Y * Y;

        public float X { get; set; }

        public float Y { get; set; }

        public float SumXY()
        {
            return X + Y;
        }

        public override string ToString()
        {
            return "(" + X + "; " + Y + ")";
        }

        public Vector2 Add(float value)
        {
            return new Vector2(X + value, Y + value);
        }

        public Vector2 Add(Vector2 vector)
        {
            return new Vector2(X + vector.X, Y + vector.Y);
        }

        public Vector2 Clamp(Vector2 min, Vector2 max)
        {
            return new Vector2(Math.Min(max.X, Math.Max(min.X, X)), Math.Min(max.Y, Math.Max(min.Y, Y)));
        }

        public Vector2 Subtract(float value)
        {
            return new Vector2(X - value, Y - value);
        }

        public Vector2 Subtract(Vector2 vector)
        {
            return new Vector2(X - vector.X, Y - vector.Y);
        }

        public Vector2 Multiply(float value)
        {
            return new Vector2(X * value, Y * value);
        }

        public Vector2 Divide(float value)
        {
            return new Vector2(X / value, Y / value);
        }
    }
}