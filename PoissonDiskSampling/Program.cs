using System;
using System.Collections.Generic;
using PoissonDiskSampling.PoissonDiskSampler;

namespace PoissonDiskSampling
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var sampler = new Sampler(new SamplerSettings(new Vector2(1000, 1000), new List<float>
            {
                1.2f, 2.3f
            }).SetNoise(true));

            var circles = sampler.SamplePoints(1000);

            Console.WriteLine("Points in total: " + circles.Count);
            for (var i = 0; i < circles.Count; i++) Console.WriteLine("Point " + (i + 1) + ": " + circles[i]);
        }
    }
}