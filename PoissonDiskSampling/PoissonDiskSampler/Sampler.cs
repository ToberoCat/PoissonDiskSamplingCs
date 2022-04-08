using System;
using System.Collections.Generic;

namespace PoissonDiskSampling.PoissonDiskSampler
{
    public struct Circle
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

    public class Sampler
    {
        public static readonly Random Random = new Random();

        private readonly SamplerSettings _settings;

        public Sampler(SamplerSettings settings)
        {
            _settings = settings;
        }

        public List<Circle> SamplePoints(int maxSamples)
        {
            var points = new List<Circle>();
            points.Add(new Circle(GetRadius(), _settings.Size.Divide(2)));

            for (var i = 0; i < maxSamples; i++)
            {
                var nextPoint = new Vector2(-1, -1);
                var nextRadius = GetRadius();
                while (!IsInBounds(nextPoint, nextRadius))
                {
                    nextRadius = GetRadius();
                    var lastCircle = points[points.Count - 1];
                    nextPoint = GetRandomPointAround(lastCircle.Point, lastCircle.Radius);
                    nextPoint = nextPoint.Add(nextPoint.Subtract(lastCircle.Point).Multiply(nextRadius));
                }

                // Trying to place the a point to the generated position
                var overlapping = false;
                foreach (var point in points)
                {
                    var dst = point.Point.Subtract(nextPoint).Sqrmagnitude;
                    if (dst < Math.Pow(point.Radius, 2))
                    {
                        overlapping = true;
                        break;
                    }
                }

                if (overlapping) continue;

                points.Add(new Circle(nextRadius, nextPoint));
            }

            return points;
        }

        private bool IsInBounds(Vector2 position, float radius)
        {
            var max = position.Add(radius);
            var min = position.Subtract(radius);

            var size = _settings.Size;

            return max.X <= size.X && max.Y <= size.Y && min.X >= 0 && min.Y >= 0;
        }

        private float GetRadius()
        {
            return _settings.PossibleRadius[Random.Next(0, _settings.PossibleRadius.Count)] + GetRadiusNoise();
        }

        private float GetRadiusNoise()
        {
            return !_settings._useNoise
                ? 0
                : (float) Random.NextDouble() * (_settings._noise.Y - _settings._noise.X) + _settings._noise.X;
        }

        private Vector2 GetRandomPointAround(Vector2 origin, float minRad)
        {
            var direction = new Vector2(Math.Sin(Random.Next(0, 360)), Math.Cos(Random.Next(0, 360))).Multiply(minRad);

            return origin.Add(direction).Clamp(new Vector2(0, 0), _settings.Size);
        }
    }
}