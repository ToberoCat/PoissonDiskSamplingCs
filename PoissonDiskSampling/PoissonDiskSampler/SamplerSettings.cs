using System;
using System.Collections.Generic;

namespace PoissonDiskSampling.PoissonDiskSampler
{
    [Serializable]
    public class SamplerSettings
    {
        public Vector2 _noise;

        public bool _useNoise;

        public SamplerSettings(Vector2 size, List<float> possibleRadius)
        {
            Size = size;
            PossibleRadius = possibleRadius;
        }

        public Vector2 Size { get; }

        public bool UseNoise => _useNoise;

        public Vector2 Noise => _noise;

        public List<float> PossibleRadius { get; }

        public SamplerSettings SetNoise(bool use, float min = 0, float max = 1)
        {
            _useNoise = use;
            _noise = new Vector2(min, max);
            return this;
        }
    }
}